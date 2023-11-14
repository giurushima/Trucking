using Microsoft.AspNetCore.Mvc;
using Trucking;
using System.ComponentModel.DataAnnotations;
using Trucking.Context;
using Microsoft.EntityFrameworkCore;
using Trucking.Entities;
using Trucking.Models.General;
using Trucking.Enums;
using Trucking.Models.Create;
using Trucking.Models.Update;

namespace Trucking.Controllers
{
    public class TruckersController : ControllerBase
    {
        public TruckersController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Trucker> GetTruckers()
        {
            return _context.Truckers;
        }

        [HttpGet("{id}")]
        public Trucker GetTrucker(int id)
        {
            return _context.Truckers.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost("{id}")]
        public ActionResult<TruckerDto> CreateTrucker(CreateTruckerDto trucker) {

            var newTrucker = new Trucker
            {
                Id = trucker.Id,
                CompleteName = trucker.CompleteName,
                TruckerType = trucker.TruckerType,
            };
            _context.Truckers.Add(newTrucker);
            _context.SaveChanges();

            return Ok(newTrucker);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrucker(int id, UpdateTruckerDto trucker)
        {
            var updatetrucker = _context.Truckers.FirstOrDefault(x => x.Id == id);

            updatetrucker.CompleteName = trucker.CompleteName;
            updatetrucker.TruckerType = trucker.TruckerType;

            _context.SaveChanges();

            var updatetruckerDto = new TruckerDto
            {
                Id = updatetrucker.Id,
                CompleteName = updatetrucker.CompleteName,
                TruckerType = updatetrucker.TruckerType,
            };

            return Ok(updatetruckerDto);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrucker(int id)
        {
            var deleteid = _context.Truckers.FirstOrDefault(x => x.Id == id);

            _context.Truckers.Remove(deleteid);

            await _context.SaveChangesAsync();

            return Ok(deleteid);
        }
    }
}