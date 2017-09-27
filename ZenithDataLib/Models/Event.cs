using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithDataLib
{
    public class Event
    {
        public int EventId { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public string Username { get; set; }

        public DateTime CreationDate { get; set; }

        public bool IsActive { get; set; }




        [ForeignKey("ActivityCategory")]
        public int ActivityCategoryId { get; set; }

        public ActivityCategory ActivityCategory { get; set; }
    }
}
