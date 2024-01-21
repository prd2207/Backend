using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;



namespace WelspunVessel.DTO.Masters
{
    public class VesselMasterDTO
    {

        [Key]
        public int VesselMasterID { get; set; }
        [Required(ErrorMessage = "Vessel Name is Required.")]
        [RegularExpression("^[a-zA-Z][a-zA-Z-0-9,@&()-+._ ]*$", ErrorMessage = "Enter valid vessel name.")]
        [MinLength(2,ErrorMessage = "Vessel Name Minimum Character Size is 2.")]
        [Display(Name = "Vessel Name")]
        [MaxLength(100, ErrorMessage = "Vessel Name Max Character Size is 100.")]

        [Remote("CheckDuplicateVesselName", "VesselMaster", HttpMethod = "POST", AdditionalFields = "VesselMasterID", ErrorMessage = "Vessel Name is already exists. Please enter a different Vessel Name.")]
        public string VesselName { get; set; }

        [Required(ErrorMessage = "Company Name is Required.")]
        public int CompanyId { get; set; }

        public List<CompanyMasterDDLDTO> CompanyMasterDDLDTO = new List<CompanyMasterDDLDTO>();
        public string CompanyName { get; set; }

        [Display(Name = "Status")]
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        [Required(ErrorMessage = "Vessel Number is Required.")]
        [Display(Name = "Vessel Number")]
        [MaxLength(250, ErrorMessage = "Vessel Number Max Number Size is 250.")]
        [RegularExpression("^[a-zA-Z-0-9][a-zA-Z-0-9,@&()-+._ ]*$", ErrorMessage = "Enter valid vessel number.")]
        [MinLength(2, ErrorMessage = "Vessel Number Minimum Character Size is 2.")]
        [Remote("CheckDuplicateVesselNumber", "VesselMaster", HttpMethod = "POST", AdditionalFields = "VesselMasterID", ErrorMessage = "Vessel Number is already exists. Please enter a different Vessel Number.")]
        public string VesselNumber { get; set; }
    }
}