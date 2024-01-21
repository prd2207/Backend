using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelspunVessel.DTO
{
    public class UserRightsMasterDTO
    {
        [Key]
        public int UserRightsID { get; set; }

        public long UserID { get; set; }

        public Int32 RightsID { get; set; }

        public Int32 MenuID { get; set; }

        public Int32 MenuRightsID { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }
    }
}
