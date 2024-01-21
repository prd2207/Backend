using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelspunVessel.DTO.Masters
{
    public class CustomerMasterDTO
    {
        [Key]
        public int CustomerID { get; set; }
        [StringLength(100)]
        [MinLength(1, ErrorMessage = "First name Minimum Character Size is 1")]
        [Required(ErrorMessage = "First Name is Required.")]
        [RegularExpression("^[a-zA-Z][a-zA-Z-0-9,@&()-+._' ]*$", ErrorMessage = "Enter valid first name.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [StringLength(100)]
        [MinLength(1,ErrorMessage = "Last name Minimum Character Size is 1")]
        [Required(ErrorMessage = "Last Name is Required.")]
        [RegularExpression("^[a-zA-Z][a-zA-Z-0-9,@&()-+._' ]*$", ErrorMessage = "Enter valid last name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Mobile Number")]
        [MaxLength(15, ErrorMessage = "Mobile Number Max Number Size is 15.")]
        [StringLength(15,MinimumLength =10, ErrorMessage = "Mobile Number Min Number Size is 10 And Max Number Size is 15.")]
        [RegularExpression("^[+0-9]*$", ErrorMessage = "Invalid Mobile Number.")]
        public string Mobile { get; set; }
        [StringLength(100)]
        [MinLength(1, ErrorMessage = "Customer name Minimum Character Size is 1")]
        [RegularExpression("^[a-zA-Z][a-zA-Z-0-9,@&()-+._' ]*$", ErrorMessage = "Enter valid customer name.")]
        [Required(ErrorMessage = "Customer Name is Required.")]
        [Display(Name = "Customer Name(Company Name)")]
        public string CustomerName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address is Required.")]
        [RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Please enter a valid Email Address.")]
        [MaxLength(320)]
        public string Email { get; set; }
        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country is Required.")]
        public int CountryId { get; set; }
        [NotMapped]
        public List<CountryMasterDDLDTO> lstcountry = new List<CountryMasterDDLDTO>();
        public string CountryName { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "City is Required.")]
        public int CityId { get; set; }
        [NotMapped]

        public List<CityMasterDDLDTO> lstCity = new List<CityMasterDDLDTO>();
        public string CityName { get; set; }
        [Required(ErrorMessage = "Postal Code is Required.")]
        [MinLength(1)]
        [MaxLength(10,ErrorMessage = "Postal Code Max Number Size is 10.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Postal Code must be Numeric.")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        [Display(Name = "Address Line1")]
        [MaxLength(250, ErrorMessage = "AddressLine1 Max Characters Size is 250.")]
        [RegularExpression("^[a-zA-Z-0-9,@&()-+._  /][a-zA-Z-0-9,@&()-+._  '/]*$", ErrorMessage = "Enter valid address line 1.")]
        [Required(ErrorMessage = "Address Line1 is Required.")]
        public string AddressLine1 { get; set; }
        [Display(Name = "Address Line2")]
        [MaxLength(250, ErrorMessage = "AddressLine2 Max Characters Size is 250.")]
        public string AddressLine2 { get; set; }
      
        [Display(Name ="Status")]
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
