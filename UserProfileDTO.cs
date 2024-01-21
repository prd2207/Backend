using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WelspunVessel.DTO
{
    public class UserProfileDTO
    {
        [Key]
        public long UserProfileID { get; set; }

        [Required]
        public long UserID { get; set; }

        [Required]
        public string Salutation { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z][a-zA-Z-0-9,@&()-+._ ]*$", ErrorMessage = "Enter valid first name.")]
        [StringLength(50, ErrorMessage = "The {0} must be minimum {2} and maximum {1} characters long.", MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [RegularExpression("^[a-zA-Z][a-zA-Z-0-9,@&()-+._ ]*$", ErrorMessage = "Enter valid middle name.")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 0)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z][a-zA-Z-0-9,@&()-+._ ]*$", ErrorMessage = "Enter valid last name.")]
        [StringLength(50, ErrorMessage = "The {0} must be minimum {2} and maximum {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Gender is Required.")]
        public string Gender { get; set; }
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        //[Remote("IsValidDateOfBirth", "Validation", HttpMethod = "POST", ErrorMessage = "Please provide a valid date of birth.")]
        public DateTime? BirthDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
       
        [NotMapped]
        public ImageMasterDTO ProfileImage { get; set; }
        [NotMapped]
        public bool IsProfileImageChange { get; set; }
    
    }

    public class DateAttribute : RangeAttribute
    {
        public DateAttribute()
          : base(typeof(DateTime), DateTime.Now.AddYears(-80).ToShortDateString(), DateTime.Now.AddYears(-18).ToShortDateString()) { }
    }
}