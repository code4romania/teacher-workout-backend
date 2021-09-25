using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherWorkout.Domain.Models.Inputs
{
    public class ThemeCreateInput
    {
        public string Title { get; set; }
        
        public string ThumbnailId { get; set; }
    }
}
