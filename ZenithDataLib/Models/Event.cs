using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithDataLib.Models
{
    public class Event
    {
        [Display(Name = "Event")]
        public int EventId { get; set; }

        [Display(Name = "Start Time")]
        public DateTime StartDateTime { get; set; }

        [Display(Name = "End Time")]
        public DateTime EndDateTime { get; set; }

        [Display(Name = "Created By")]
        public string Username { get; set; }

        [Display(Name = "Created On")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }




        [ForeignKey("ActivityCategory")]
        [Display(Name = "Activity Category")]
        public int ActivityCategoryId { get; set; }

        [Display(Name = "Activity Description")]
        public ActivityCategory ActivityCategory { get; set; }
    }
}
