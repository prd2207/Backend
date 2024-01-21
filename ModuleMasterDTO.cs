using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelspunVessel.DTO
{
    public class ModuleMasterDTO
    {
        [Key]
        public int ModuleID { get; set; }

        public string ModuleName { get; set; }

        public string ModuleURL { get; set; }

        public int DisplayOrder { get; set; }

        public string IconClass { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public Nullable<DateTime> CreatedDate { get; set; }

        public Nullable<int> CreatedBy { get; set; }

        [NotMapped]
        public bool IsSelected { get; set; }
    }
}
