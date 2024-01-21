using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelspunVessel.DTO.Masters
{
    public class PortMasterDDLDTO
    {
        
        
            [Key]
            public int PortId { get; set; }

            public string PortName { get; set; }
        
    }
}
