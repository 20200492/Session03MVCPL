﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Session03MVCEDAL.Models
{
    public enum Gender
    {
        [EnumMember(Value = "Male")]
        Male = 1,
        [EnumMember(Value = "Female")]
        Female = 2
    }
    public enum EmpType
    {
        FullTime = 1,
        PartTime = 2
    }
    public class Employee : ModelBase
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Max Length of Name is 50 Chars")]
        [MinLength(50, ErrorMessage = "Min Length of Name is 50 Chars")]
        public string Name { get; set; }
        [Range(22, 30)]
        public int Age { get; set; }

        [RegularExpression(@"^\d+\s[A-z]+\s[A-z]+$")]
        public string Address { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [EmailAddress] // For Validation
        [DataType(DataType.EmailAddress)] // For Formating
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        [Phone] // For Validation
        [DataType(DataType.PhoneNumber)] // For Formating
        //[DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Display(Name = "Hiring Date")]
        public DateTime HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmpType Type { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int? DepartmetId { get; set; }
        public Department Department { get; set; }

    }
}
