using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelspunVessel.DTO.Masters
{
   public class CompanyMasterDTO
    {
        [Key]
        public int CompanyId { get; set; }
        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Company Name is Required.")]
        [RegularExpression("^[a-zA-Z][a-zA-Z-0-9,@&()-+._' ]*$", ErrorMessage = "Enter Valid Company Name.")]
        [StringLength(100)]
        [Remote("CheckDuplicateCompanyName", "CompanyMaster", HttpMethod = "POST", AdditionalFields = "CompanyId", ErrorMessage = "Company Name is already exists. Please enter a different Company Name.")]
        public string CompanyName { get; set; }
        [RegularExpression("^[a-zA-Z][a-zA-Z-0-9,@&()-+._ ']*$", ErrorMessage = "Enter Valid Company Spokesperson Name.")]
        [MaxLength(250, ErrorMessage = "Company Spokesperson Max Character Size is 250.")]
        [Required(ErrorMessage = "Company Spokesperson is Required.")]
        [Display(Name = "Company Spokesperson")]
        public string CompanySpokesperson { get; set; }
    
        [Required(ErrorMessage = "Company Code is Required.")]
        [Display(Name = "Company Code")]
        [RegularExpression("^[a-zA-Z-0-9][a-zA-Z-0-9,@&()-+._']*$", ErrorMessage = "Enter Valid Company Code.")]
        [MaxLength(50, ErrorMessage = "Company Code Max Characters Size is 50.")]
        [Remote("CheckDuplicateCompanyCode", "CompanyMaster", HttpMethod = "POST", AdditionalFields = "CompanyId", ErrorMessage = "Company Code is already exists. Please enter a different Company Code.")]
        public string CompanyCode { get; set; }
        [Required]
        [Display(Name ="Status")]
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
