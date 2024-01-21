using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelspunVessel.DTO.Masters
{
    public class VesselTripUploadDTO
    {
        [Key]
        public int VesselTripUploadMasterID { get; set; }
        public string FileName { get; set; }
        public string ActualFileName { get; set; }
        public int TotalRecords { get; set; }
        public string UploadStatus { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Uploadedonstr { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
        

    }

    public class VesselTripUploadReq
    {
        [Required(ErrorMessage = "Please select file.")]
        public IFormFile UploadFile { get; set; }
    }
}
