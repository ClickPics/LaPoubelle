using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZenithDataLib.Models;

namespace Zenith.Models
{
    public class ScheduleViewModel
    {
        public Dictionary<string, List<Event>> DaysAndEvents { get; set; }
    }
}