using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelspunVessel.DAL.Entities;
using WelspunVessel.DAL.Mapper;
using WelspunVessel.DTO;
using Microsoft.EntityFrameworkCore;
using WelspunVessel.DTO.Masters;

namespace WelspunVessel.DAL.DataLayer.Masters
{
    public class RoleMasterDAL
    {
        CRUDContext cRUDContext;
        public RoleMasterDTO Insert_RoleMaster(CRUDContext context, RoleMasterDTO objRoleMaster)
        {
            cRUDContext = context;
            objRoleMaster.IsDeleted = false;
            RoleMasterDTO objRoleMstr = new RoleMasterDTO();
            objRoleMstr = cRUDContext.RoleMasterDTO.FromSql("usp_InsertUpdate_RoleMaster @p0, @p1, @p2, @p3, @p4, @p5, @p6 " , objRoleMaster.RoleID, objRoleMaster.RoleName, objRoleMaster.CreatedDate, objRoleMaster.ModifiedDate, objRoleMaster.IPAddress,objRoleMaster.IsActive, objRoleMaster.IsDeleted).FirstOrDefault();
            return objRoleMstr;
        }

        public IList<RoleMasterDTO> GetAll_RoleMaster(CRUDContext context)
        {
            cRUDContext = context;
            return cRUDContext.RoleMasterDTO.FromSql("usp_GetAll_RoleMaster").ToList();
        }

        public RoleMasterDTO GetRoleMasterByRoleID(CRUDContext context, Int16 roleId)
        {
            cRUDContext = context;
            RoleMasterDTO objRoleMstr = new RoleMasterDTO();
            objRoleMstr = cRUDContext.RoleMasterDTO.FromSql("usp_GetRoleMasterByRoleID  @p0", roleId).FirstOrDefault();

            if (roleId > 0)
            {
                objRoleMstr.lstRolesRights = new List<MenuRightsMappingDTO>();
                objRoleMstr.lstRolesRights = context.MenuRightsMappingDTO.FromSql("usp_GetRoleRightsByRoleID @p0", roleId).ToList();
            }
            return objRoleMstr;
        }

        public List<MenuRightsMappingDTO> GetAllMenuRightsMapping(CRUDContext context)
        {
            cRUDContext = context;
            return cRUDContext.MenuRightsMappingDTO.FromSql("usp_GetAllMenuRightsMapping").ToList();
        }

        public bool InsertUpdate_RoleRightsMapping(CRUDContext context, List<RoleRightsMasterDTO> lstMenuRights, int RoleID)
        {
            cRUDContext = context;
            if (lstMenuRights.Count > 0)
            {
                cRUDContext.Database.ExecuteSqlCommand("usp_DeleteRoleRightsByRoleID @p0", RoleID);

                foreach (var item in lstMenuRights)
                {
                    cRUDContext.Database.ExecuteSqlCommand("usp_InsertUpdateRoleRightsMapping @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7", item.RoleRightsID, item.RoleID, item.RightsID, item.MenuID, item.MenuRightsID, item.IsDeleted, item.CreatedDate, item.CreatedBy);
                }
            }
            return true;
        }

        public List<MenuRightsMappingDTO> GetMenuRightsMappingByRoleID(CRUDContext context, Int16 roleID)
        {
            List<MenuRightsMappingDTO> lstMenuRights = new List<MenuRightsMappingDTO>();
            lstMenuRights = context.MenuRightsMappingDTO.FromSql("usp_GetRoleRightsByRoleID @p0", roleID).ToList();
            return lstMenuRights;
        }

        public List<MenuRightsMappingDTO> GetMenuRightsMappingByUserID(CRUDContext context, long UserID)
        {
            List<MenuRightsMappingDTO> lstUserRights = new List<MenuRightsMappingDTO>();
            lstUserRights = context.MenuRightsMappingDTO.FromSql("usp_GetUserRightsByRoleID @p0", UserID).ToList();
            return lstUserRights;
        }

        public bool DeleteRole(CRUDContext context, RoleMaster roleMasterDTO)
        {
            var isDeleted = new SqlParameter
            {
                ParameterName = "retVal",
                DbType = System.Data.DbType.Boolean,
                Direction = System.Data.ParameterDirection.Output
            };
            var result = context.Database.ExecuteSqlCommand("Sp_DeleteRoleByID @p0, @retVal OUT", roleMasterDTO.RoleID, isDeleted);
            return (bool)isDeleted.Value;
        }


    }
}
