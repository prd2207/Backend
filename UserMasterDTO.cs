 using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelspunVessel.DTO.Masters;

namespace WelspunVessel.DTO
{
    public class UserMasterDTO
    {
        [Key]
        public long UserID { get; set; }

        [Required]
        [Display(Name = "User Name")]
        [RegularExpression(@"^[A-Za-z0-9_]*$", ErrorMessage = "Enter valid user name.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "The {0} must be at least {2} characters long")]
        [Remote("CheckUserNameExist", "UserMaster", HttpMethod = "POST", AdditionalFields = "UserID", ErrorMessage = "{0} already exists. Please enter a different User Name")]
        public string UserName { get; set; }

        [Required]
        [RegularExpression(@"^[!@#$%&*_A-Za-z0-9]*$", ErrorMessage = "Enter valid password.")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long and maximum 15 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
      
        [NotMapped]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Email ID")]
        [RegularExpression(@"^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Enter valid {0}.")]
        [StringLength(255, ErrorMessage = "The {0} must be minimum {2} and maximum {1} characters long.", MinimumLength = 5)]
        [Remote("CheckUserEmailIDExist", "UserMaster", HttpMethod = "POST", AdditionalFields = "UserID", ErrorMessage = "{0} already exists. Please enter a different Eamil ID.")]
        public string EmailID { get; set; }

        [Required]
        [RegularExpression(@"^[0-9-+]*$", ErrorMessage = "Enter valid {0}.")]
        [StringLength(14, ErrorMessage = "The {0} must be minimum {2} and maximum {1} characters long.", MinimumLength = 10)]

        [Display(Name = "Mobile Number")]
        [Remote("CheckUserMobileNoExist", "UserMaster", HttpMethod = "POST", AdditionalFields = "UserID", ErrorMessage = "{0} already exists. Please enter a different Mobile Number.")]
        public string MobileNo { get; set; }

        [Required]
        [DisplayName("Role")]
        public Int16 RoleID { get; set; }

        [DisplayName("Status")]
        public bool IsActive { get; set; }

        [DisplayName("Is Deleted")]
        public bool IsDeleted { get; set; }

        public bool IsFirstTimeLogIn { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }
        
        public String RoleName { get; set; }
        
        public String PIN { get; set; }

        public UserProfileDTO UserProfileDTO { get; set; }

        [DisplayName("Chain Title")]
        public int? ChainID { get; set; }
        [DisplayName("Brand Title")]
        public int? BrandID { get; set; }
        [DisplayName("Store Name")]
        public int? StoreID { get; set; }

        [NotMapped]
        public List<MenuRightsMappingDTO> lstAllMenuRights = new List<MenuRightsMappingDTO>();

        [NotMapped]
        public List<MenuRightsMappingDTO> lstRolesRights = new List<MenuRightsMappingDTO>();

        [NotMapped]
        public List<MenuRightsMappingDTO> lstMenu = new List<MenuRightsMappingDTO>();

        [NotMapped]
        public List<MenuRightsMappingDTO> lstUsersAllMenuRights = new List<MenuRightsMappingDTO>();

        [NotMapped]
        public List<MenuRightsMappingDTO> lstUserRights = new List<MenuRightsMappingDTO>();

        [NotMapped]
        public List<MenuRightsMappingDTO> lstUserMenu = new List<MenuRightsMappingDTO>();
        [NotMapped]
        public ICollection<CompanyMasterDDLDTO> CompanyMasterDDL;

        [DisplayName("Chain Title")]
        public string ChainTitle { get; set; }
        [DisplayName("Brand Title")]
        public string BrandTitle { get; set; }
        [DisplayName("Store Name")]
        public string StoreName { get; set; }
        [NotMapped]
        [Required]
        [Display(Name = "Company Name")]
        public int[] CompanyId { get; set; }
        [NotMapped]
        public string CompanyIdList { get; set; }
        [NotMapped]
        public string CompanyName { get; set; }
       
    }

    public class UserPasswordChangeDTO
    {
        public long UserID { get; set; }
        
        [Required]
        [RegularExpression(@"^[!@#$%&*_A-Za-z0-9]*$", ErrorMessage = "Enter valid password.")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long and maximum 15 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [NotMapped]
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }
    }

    public class UserForgotPasswordDTO
    {
        public long UserID { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "The {0} must be minimum {2} and maximum {1} characters long.", MinimumLength = 5)]
        [Remote("CheckUserNameEmailIDExistForForgotPassword", "ForgotPassword", HttpMethod = "POST", AdditionalFields = "UserID", ErrorMessage = "UserName / Email ID already not exists. Please enter a different UserName / Eamil ID.")]
        public string UserNameEmailID { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [Display(Name = "User ID")]
        public Int64 UserID { get; set; }

        [Display(Name = "Email ID")]
        public string EmailID { get; set; }

        //[Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string PIN { get; set; }
        public string IsSet { get; set; }

    }
    public class UserAPILoginDTO
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
    }
     public class APITokenDTO
    {
        public string Token { get; set; }
    }
}