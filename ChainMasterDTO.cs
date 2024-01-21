using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WelspunVessel.DTO
{
    public class ChainMasterDTO
    {
        [Key]
        public int ChainID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [DisplayName("Chain Name")]
        [Remote("CheckDuplicateChainName", "ChainMaster", HttpMethod = "POST", AdditionalFields = "ChainID", ErrorMessage = "{0} already exists. Please enter a different name.")]
        public string ChainTitle { get; set; }

        [StringLength(2000)]
        [DisplayName("Chain Description")]
        public string ChainDescription { get; set; }
        
        [DisplayName("Is Active")]
        public bool Status { get; set; }

        [DisplayName("Is Deleted")]
        public bool IsDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? DeletedDate { get; set; }

        public int? DeletedBy { get; set; }

        public string ChainNumber { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Contact Name")]
        public string ContactName { get; set; }
        
        [RegularExpression(@"^[0-9-+]*$", ErrorMessage = "Enter valid {0}.")]
        [StringLength(14, ErrorMessage = "The {0} must be minimum {2} and maximum {1} characters long.", MinimumLength = 10)]
        [DisplayName("Telephone Number")]
        [Remote("CheckTelephoneNoExist", "ChainMaster", HttpMethod = "POST", AdditionalFields = "ChainID", ErrorMessage = "{0} already exists. Please enter a different Telephone Number")]
        public string ContactTelephone { get; set; }

        [RegularExpression(@"^[0-9-+]*$", ErrorMessage = "Enter valid {0}.")]
        [StringLength(14, ErrorMessage = "The {0} must be minimum {2} and maximum {1} characters long.", MinimumLength = 10)]
        [Remote("CheckMobileNumberExist", "ChainMaster", HttpMethod = "POST", AdditionalFields = "ChainID", ErrorMessage = "{0} already exists. Please enter a different Mobile Number")]
        [DisplayName("Mobile Number")]
        public string ContactMobile { get; set; }

        [Required]
        [StringLength(100)]
        [RegularExpression(@"^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Enter valid {0}.")]
        [Remote("CheckEmailAddressIDExist", "ChainMaster", HttpMethod = "POST", AdditionalFields = "ChainID", ErrorMessage = "{0} already exists. Please enter a different Email Address")]
        [DisplayName("Email Address")]
        public string ContactEmail { get; set; }

        public int BrandCount { get; set; }

        [StringLength(200)]
        [DisplayName("Loyalty Program")]
        public string CustomLoyaltyProgram { get; set; }

        [StringLength(200)]
        [DisplayName("E-Wallet")]
        public string CustomEwallet { get; set; }

        [StringLength(200)]
        [DisplayName("Stamps")]
        public string CustomStamp { get; set; }

        [NotMapped]
        public List<ImageMasterDTO> lstImageMaster = new List<ImageMasterDTO>();

        [NotMapped]
        public List<ModuleMasterDTO> lstChainModules = new List<ModuleMasterDTO>();

        [NotMapped]
        public List<ModuleMasterDTO> lstAllModules = new List<ModuleMasterDTO>();
    }
}
