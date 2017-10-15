using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithDataLib.Models
{
    public class ActivityCategory
    {
        [Display(Name = "Activity Category")]
        public int ActivityCategoryId { get; set; }

        [Display(Name = "Activity Description")]
        public string ActivityDescription { get; set; }

        [Display(Name = "Created On")]
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
    
}
