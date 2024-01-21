using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelspunVessel.DTO.Masters
{
    public class VesselNumberDDLDTO
    {
        [Key]
        public int VesselMasterID { get; set; }
        public string VesselNumber { get; set; }
    }
}
