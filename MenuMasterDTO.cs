using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WelspunVessel.DTO
{
    public class MenuMasterDTO
    {
        [Key]
        public int MenuID { get; set; }

        [Required]
        public Int32 ParentID { get; set; }

        public string MenuName { get; set; }

        public string MenuURL { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsVisibleOnMenu { get; set; }

        public int DisplayOrder { get; set; }

        public string ControllerName { get; set; }

        public string Description { get; set; }

        public string IconClass { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }
    }
}
