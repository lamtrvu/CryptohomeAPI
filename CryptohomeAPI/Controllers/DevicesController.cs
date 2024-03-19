using CryptohomeAPI.Data;
using CryptohomeAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CryptohomeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevicesController : Controller
    {
        private ApplicationDbContext _dbContext;
        public DevicesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetDeviceDetail(int id)
        {
            var device = _dbContext.Devices.Find(id);
            if (device == null)
            {
                return NotFound();
            }
            return Ok(device);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] Models.Device device)
        {
            _dbContext.Devices.Add(device);
            _dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
