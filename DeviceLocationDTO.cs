using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelspunVessel.DTO.Masters
{
    public class DeviceLocationDTO
    {
        [Key]
        public int DeviceID { get; set; }
        public string Devicename { get; set; }
        public int Macaddress { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public int EmpID { get; set; }
        public string EmpName { get; set; }
    }
}
