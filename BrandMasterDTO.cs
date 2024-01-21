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
    public class BrandMasterDTO
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [DisplayName("Chain")]
        public Int32 ChainID { get; set; }

        [DisplayName("ChainTitle")]
        public string ChainTitle { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [DisplayName("Brand Name")]
        [Remote("CheckDuplicateBrandName", "BrandMaster", HttpMethod = "POST", AdditionalFields = "ID", ErrorMessage = "{0} already exists. Please enter a different name.")]
        public string BrandTitle { get; set; }

        [StringLength(2000)]
        [DisplayName("Brand Description")]
        public string BrandDescription { get; set; }
        
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

        public int StoreCount { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Brand Color")]
        public string Color { get; set; }

        public string BrandNumber { get; set; }

        [NotMapped]
        public List<ImageMasterDTO> lstImageMaster = new List<ImageMasterDTO>();
    }
}
