﻿using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using Trucking.Entities;
using Trucking.Models.Auth;
using Trucking.Services.Auth;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace Trucking.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IAuthenticationServices _customAuthenticationService;

        public AuthenticationController(IConfiguration config, IAuthenticationServices autenticacionService)
        {
            _config = config;
            this._customAuthenticationService = autenticacionService;
        }

        [HttpPost("authenticate")]
        public ActionResult<string> Autenticar(AuthenticationRequestBody authenticationRequestBody)
        {

            var user = ValidateCredentials(authenticationRequestBody);

            if (user is null)
                return Unauthorized();


            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"]));

            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);


            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.ID.ToString()));
            claimsForToken.Add(new Claim("given_name", user.Name));

            var jwtSecurityToken = new JwtSecurityToken(
              _config["Authentication:Issuer"],
              _config["Authentication:Audience"],
              claimsForToken,
              DateTime.UtcNow,
              DateTime.UtcNow.AddHours(1),
              credentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);
        }

        private User? ValidateCredentials(AuthenticationRequestBody authParams)
        {
            return _customAuthenticationService.ValidateUser(authParams);
        }
    }
}
