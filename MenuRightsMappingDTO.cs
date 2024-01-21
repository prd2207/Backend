using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelspunVessel.DTO
{
    public class MenuRightsMappingDTO
    {
        [Key]
        public int MenuRightsID { get; set; }

        public Int32 MenuID { get; set; }

        public Int32 RightsID { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        [NotMapped]
        public bool IsActive { get; set; }
        
        public bool IsDeleted { get; set; }
        
        public string MenuName { get; set; }

        public string RightsName { get; set; }

        [NotMapped]
        public bool IsSelected { get; set; }

        public int DisplayOrder { get; set; }

        public string IconClass { get; set; }

        public int RightsDisplayOrder { get; set; }
    }
}
