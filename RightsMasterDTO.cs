using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelspunVessel.DTO
{
    public class RightsMasterDTO
    {
        [Key]
        public int RightsID { get; set; }

        [Required]
        [DisplayName("Rights Name")]
        public string RightsName { get; set; }
        
        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public int DisplayOrder { get; set; }
    }
}
