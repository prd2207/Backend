using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelspunVessel.DTO.Masters;

namespace WelspunVessel.DAL.DataLayer.Masters
{
    public class VesselMasterDAL
    {
        public VesselMasterDTO InsertUpdate_VesselMaster(CRUDContext context, VesselMasterDTO objvesselMaster)
        {

            VesselMasterDTO objvessel = new VesselMasterDTO();
            objvessel = context.VesselMasterDTO.FromSql("usp_InsertUpdate_VesselMaster @p0, @p1, @p2, @p3, @p4, @p5,@p6,@p7,@p8,@p9",
                objvesselMaster.VesselMasterID,
                objvesselMaster.VesselName,
                objvesselMaster.IsActive,
                objvesselMaster.IsDeleted,
                objvesselMaster.CreatedDate,
                objvesselMaster.ModifiedDate,
                objvesselMaster.CreatedBy,
                objvesselMaster.ModifiedBy,
                objvesselMaster.CompanyId,
                objvesselMaster.VesselNumber
                
                ).FirstOrDefault();
            return objvessel;
        }

        
        public IList<VesselMasterDTO> GetVesseList(CRUDContext context)
        {
            var vesselMasters = new List<VesselMasterDTO>();
            vesselMasters = context.VesselMasterDTO.FromSql("sp_GetVesselList").ToList();
            return vesselMasters;
        }

        public VesselMasterDTO GetVesselMasterByID(CRUDContext context, int VesselMasterID)
        {

            VesselMasterDTO objVesselMaster = new VesselMasterDTO();
            objVesselMaster = context.VesselMasterDTO.FromSql("sp_GetVesselMasterByID  @p0", VesselMasterID).FirstOrDefault();

            return objVesselMaster;
        }

       
        public VesselMasterDTO GetVesselDetailByID(CRUDContext context, int VesselMasterID)
        {

            VesselMasterDTO objvesselDetail = new VesselMasterDTO();
            objvesselDetail = context.VesselMasterDTO.FromSql("sp_GetVesselMasterByID  @p0", VesselMasterID).FirstOrDefault();

            return objvesselDetail;
        }
        public bool DeleteVesselDetailByID(CRUDContext context, VesselMasterDTO objVesselMaster)
        {
            var IsDeleted = new SqlParameter
            {
                ParameterName = "retVal",
                DbType = System.Data.DbType.Boolean,
                Direction = System.Data.ParameterDirection.Output
            };
            var result = context.Database.ExecuteSqlCommand("usp_DeleteVesselDetailByID @p0, @retVal OUT", objVesselMaster.VesselMasterID, IsDeleted);
            return (bool)IsDeleted.Value;
        }

        public IList<CompanyMasterDDLDTO> GetCompanyList(CRUDContext context)
        {
            var companyMasterDto = new List<CompanyMasterDDLDTO>();
            companyMasterDto = context.CompanyMasterDDLDTO.FromSql("SP_GetCompanyList").ToList();
            return companyMasterDto;
        }

        public bool CheckDuplicateVesselName(CRUDContext context, string EntityTitle, int EntityID)
        {
            var out2 = new SqlParameter
            {
                ParameterName = "p2",
                DbType = System.Data.DbType.Boolean,
                Direction = System.Data.ParameterDirection.Output
            };
            var sql = "Sp_CheckDuplicateVesselName @p0,@p1,@p2 OUT";
            var result = context.Database.ExecuteSqlCommand(sql, EntityTitle, EntityID, out2);
            return (bool)out2.Value;
        }

        public bool CheckDuplicateVesselNumber(CRUDContext context, string EntityTitle, int EntityID)
        {
            var out2 = new SqlParameter
            {
                ParameterName = "p2",
                DbType = System.Data.DbType.Boolean,
                Direction = System.Data.ParameterDirection.Output
            };
            var sql = "Sp_CheckDuplicateVesselNumber @p0,@p1,@p2 OUT";
            var result = context.Database.ExecuteSqlCommand(sql, EntityTitle, EntityID, out2);
            return (bool)out2.Value;
        }
    }
}
