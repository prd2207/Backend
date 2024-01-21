using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WelspunVessel.DTO.Masters
{
    public class VesselMasterDDLDTO
    {

        [Key]
        public int VesselMasterID { get; set; }
        public string VesselName { get; set; }
    }
}