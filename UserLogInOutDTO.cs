using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelspunVessel.DTO.Masters
{
    public class UserLogInOutDTO
    {
        [Key]
        public long LogInOutID { get; set; }

        [Required]
        public long UserID { get; set; }

        public Nullable<DateTime> LogInTime { get; set; }
        
        public Nullable<DateTime> LogOutTime { get; set; }

        public bool IsMobile { get; set; }

        public string IPAddress { get; set; }
    }
}
