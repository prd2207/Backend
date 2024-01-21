using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelspunVessel.DTO
{
    public class RoleMasterDTO : BaseDTO
    {
        [Key]
        public Int16 RoleID { get; set; }
        [Display(Name = "Role Name")]
        [Required]
        public string RoleName { get; set; }
        [Required]
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        [NotMapped]
        public List<MenuRightsMappingDTO> lstAllMenuRights = new List<MenuRightsMappingDTO>();

        [NotMapped]
        public List<MenuRightsMappingDTO> lstRolesRights = new List<MenuRightsMappingDTO>();

        [NotMapped]
        public List<MenuRightsMappingDTO> lstMenu = new List<MenuRightsMappingDTO>();
    }
}