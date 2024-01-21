using System.ComponentModel.DataAnnotations;

namespace WelspunVessel.DTO.Masters
{
    public class CountryMasterDDLDTO
    {
        [Key]
        public int CountryID { get; set; }

        public string CountryName { get; set; }
    }
}