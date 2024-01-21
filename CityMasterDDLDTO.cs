using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelspunVessel.DTO.Masters
{
    public class CityMasterDDLDTO
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }

    }
}
