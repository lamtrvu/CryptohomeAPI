using CryptohomeAPI.Data;
using CryptohomeAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Principal;
using static CryptohomeAPI.Models.ActionResult;

namespace CryptohomeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActionsController : ControllerBase
    {
        private ApplicationDbContext _dbContext;
        public ActionsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Authorize]
        [HttpPost(Name = "ActionPost")]
        public IActionResult Post([FromBody] Models.Action action)
        {
            try
            {
                Device device = _dbContext.Devices.First(dev => dev.Id == action.DeviceId);
                action.ActionTime = DateTime.Now;
                switch (action.Type)
                {
                    case ActionType.TurnOn:
                        device.CurrentStatus = DeviceStatus.TurnOn;
                        Console.WriteLine($"The device {device.Name} is turned on");
                        break;
                    case ActionType.TurnOff:
                        device.CurrentStatus = DeviceStatus.TurnOff;
                        Console.WriteLine($"The device {device.Name} is turned off");
                        break;
                    case ActionType.Undo:
                        if (device.CurrentStatus == DeviceStatus.TurnOn)
                        {
                            device.CurrentStatus = DeviceStatus.TurnOff;
                            Console.WriteLine($"The device {device.Name} is turned off");
                        }
                        else
                        {
                            device.CurrentStatus = DeviceStatus.TurnOn;
                            Console.WriteLine($"The device {device.Name} is turned on");
                        }
                        break;
                }
                _dbContext.Actions.Add(action);
                _dbContext.SaveChanges();
                return new JsonResult(new Models.ActionResult(ActionResultStatus.Success, string.Empty));
            }
            catch (Exception ex)
            {
                return new JsonResult(new Models.ActionResult(ActionResultStatus.Failure, ex.Message));
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetActionDetail(int id)
        {
            var actionResult = (from action in _dbContext.Actions
                                join user in _dbContext.Users on action.UserId equals user.Id
                                join device in _dbContext.Devices on action.DeviceId equals device.Id
                                where action.Id == id
                                select new
                                {
                                    Id = action.Id,
                                    ActionType = action.Type,
                                    ActionTime = action.ActionTime,
                                    UserName = user.Name,
                                    DeviceName = device.Name
                                }).FirstOrDefault();
            return Ok(actionResult);
        }

        [HttpGet(Name = "GenerateActions")]
        public IEnumerable<Models.Action> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Models.Action
            {
                Type = ActionTypes[Random.Shared.Next(ActionTypes.Length)],
                ActionTime = DateTime.Now.AddDays(index),
                DeviceId = Random.Shared.Next(0, 10),
                UserId = Random.Shared.Next(0, 10),
            })
            .ToArray();
        }
        private static readonly ActionType[] ActionTypes = new[]
        {
            ActionType.TurnOn,
            ActionType.TurnOff,
            ActionType.Undo
        };
    }
}
