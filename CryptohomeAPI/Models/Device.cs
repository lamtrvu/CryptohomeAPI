using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CryptohomeAPI.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Action> Actions { get; set; }
        public DeviceStatus CurrentStatus { get; set; }

    }

    public enum DeviceStatus
    {
        TurnOff,
        TurnOn
    }
}