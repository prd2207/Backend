using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WelspunVessel.DTO.Masters
{
    public class ContainerMasterDDLDTO
    {
        [Key]
        public int ContainerID { get; set; }
       
        public string ContainerNumber { get; set; }


    }
}
