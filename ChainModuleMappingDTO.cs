using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelspunVessel.DTO
{
    public class ChainModuleMappingDTO
    {
        [Key]
        public int MappingID { get; set; }

        public int ChainID { get; set; }

        public int ModuleID { get; set; }
        
        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
    }
}
