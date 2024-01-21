using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelspunVessel.DTO.Masters
{
   public class CompanyMasterDDLDTO
    {
        [Key]
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }
    }
}
