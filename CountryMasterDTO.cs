using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelspunVessel.DTO.Masters
{
    public class CountryMasterDTO
    {
        [Key]
        public int CountryId { get; set; }
     
        [Required(ErrorMessage = "Country Name is Required.")]
        [RegularExpression("^[a-zA-Z][a-zA-Z-0-9,@&()-+._ ]*$", ErrorMessage = "Enter valid country name.")]
        [MaxLength(100, ErrorMessage = "Country Name Max Size is 100.")]
        [StringLength(100)]
        [Remote("CheckDuplicateCountryName", "CountryMaster", HttpMethod = "POST", AdditionalFields = "CountryId", ErrorMessage = "Country Name is already exists. Please enter a different Country Name.")]
        public string CountryName { get; set; }
     
        [Required]
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
