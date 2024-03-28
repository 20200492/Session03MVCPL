using Session03MVCEDAL.Models;
using System.ComponentModel.DataAnnotations;
using System;

namespace Session03MVCPL.ViewModel
{
    public class EmployeeViewModel
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Max Length of Name is 50 Chars")]
        [MinLength(10, ErrorMessage = "Min Length of Name is 10 Chars")]
        public string Name { get; set; }
        [Range(22, 30)]
        public int Age { get; set; }

        //[RegularExpression(@"^\d+\s[A-z]+\s[A-z]+$")]
        public string Address { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        [Phone]
        //[DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Display(Name = "Hiring Date")]
        public DateTime HiringDate { get; set; }
        public Gender Gender { get; set; }
        public int? DepartmetId { get; set; }

        public Department Department { get; set; }
    }
}
