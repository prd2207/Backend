using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelspunVessel.DTO
{
    public class ImageMasterDTO
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int ImageCategoryID { get; set; }

        [Required]
        public int ImageTypeID { get; set; }
        
        public string ImageName { get; set; }

        public string FileType { get; set; }

        public byte[] ImageOriginal { get; set; }

        public byte[] ImageSmall { get; set; }

        public byte[] ImageMedium { get; set; }

        public byte[] ImageLarge { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public long EntityID { get; set; }
    }
}
