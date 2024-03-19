using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptohomeAPI.Models
{
    public class Action
    {
        public int Id { get; set; }
        public ActionType Type { get; set; }
        public DateTime ActionTime { get; set; }
        public int DeviceId { get; set; }
        public int UserId { get; set; }
    }

    public enum ActionType
    {
        TurnOn,
        TurnOff,
        Undo
    }
}
