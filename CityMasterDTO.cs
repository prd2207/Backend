using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelspunVessel.DTO.Masters
{
   public class CityMasterDTO
    {
        [Key]
        public int CityId { get; set; }
        [Required(ErrorMessage = "Country Name is Required.")]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public List<CountryMasterDDLDTO> CountryMasters = new List<CountryMasterDDLDTO>();
        [StringLength(100)]
        [MaxLength(100, ErrorMessage = "City Name Max Characters Size is 100.")]

        [RegularExpression("^[a-zA-Z][a-zA-Z-0-9,@&()-+._ ]*$", ErrorMessage = "Enter Valid City Name.")]
        [Remote("CheckDuplicateCityName", "CityMaster", HttpMethod = "POST", AdditionalFields = "CityId,CountryId", ErrorMessage = "City Name is already exists. Please enter a different City Name.")]
        [Required(ErrorMessage = "City Name is Required.")]
        public string CityName { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

      

    }
}
