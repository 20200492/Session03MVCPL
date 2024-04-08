using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session03MVCEDAL.Models
{
    public class Department:ModelBase
    {
        //[Required(ErrorMessage = "Name Is Required Ya 7oda")] // This Error Message Is Written In ViewModel
        public string Code { get; set; }
        //[Required] // We Don't Write Data Annotation But We Write Fluent API
        public string Name { get; set; }
        public DateTime DateOfCreation { get; set; }
    }
}
