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
  public class ContainerMasterDTO
    {
        [Key]
        public int ContainerID { get; set; }
        [Display(Name = "Vessel Name")]
        [Required(ErrorMessage = "Vessel Name is Required.")]
        public int VesselMasterID { get; set;}
        public string VesselName { get; set; }
        [Display(Name = "Container Number")]
        //[StringLength(50)]
        [RegularExpression("^[a-zA-Z-0-9][a-zA-Z-0-9,@&()-+._ ]*$", ErrorMessage = "Enter Valid Container Name.")]
        [MaxLength(250, ErrorMessage = "Container Number Max Number Size is 250.")]
        [Required(ErrorMessage = "Container Number is Required.")]
        [Remote("CheckDuplicateContainerNumber", "ContainerMaster", HttpMethod = "POST", AdditionalFields = "VesselMasterID,ContainerID", ErrorMessage = "{0} is already exists. Please enter a different Container Number.")]
        public string ContainerNumber { get; set; }
        [Display(Name = "Status")]
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set;}
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
