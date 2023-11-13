using Microsoft.AspNetCore.Mvc;
using Trucking.Models;
using Trucking;
using System.ComponentModel.DataAnnotations;

namespace Trucking.Controllers
{
    public class TruckersController : ControllerBase
    {
        [HttpGet]
        public Trucker GetTrucker(int id)
        {
            return _context.Truckers.FirstOrDefault(x => x.ID == id);
        }
        
    }
}
