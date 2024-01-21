using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelspunVessel.DTO.Masters
{
    public class PortMasterDTO
    {
        [Key]
        public int PortId { get; set; }
        [Required(ErrorMessage = "Country Name is Required.")]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public List<CountryMasterDDLDTO> CountryMasters = new List<CountryMasterDDLDTO>();
        [StringLength(100)]
       
        [Remote("CheckDuplicatePortName", "PortMaster", HttpMethod = "POST", AdditionalFields = "PortId,CountryId", ErrorMessage = "Port Name is already exists. Please enter a different Port Name.")]
        [Required(ErrorMessage = "Port Name is Required.")]
        [RegularExpression("^[a-zA-Z][a-zA-Z-0-9,@&()-+._ ]*$", ErrorMessage = "Enter Valid Port Name.")]
        [MaxLength(250, ErrorMessage = "Port Name Max Characters Size is 250.")]
        public string PortName { get; set; }

        [Required(ErrorMessage = "Status is Required")]
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
