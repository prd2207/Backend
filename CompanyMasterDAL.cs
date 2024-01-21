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
   public class CompanyMasterDAL
    {
        public CompanyMasterDTO InsertUpdateCompany(CRUDContext context, CompanyMasterDTO objcompanymaster)
        {
            objcompanymaster = context.CompanyMasterDTO.FromSql("SP_InsertUpdateCompany @p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9",
            objcompanymaster.CompanyId,
            objcompanymaster.CompanyName,
            objcompanymaster.CompanyCode,
            objcompanymaster.IsActive,
            objcompanymaster.IsDeleted,
            objcompanymaster.CreatedBy,
            objcompanymaster.CreatedDate,
            objcompanymaster.ModifiedBy,
            objcompanymaster.ModifiedDate,
            objcompanymaster.CompanySpokesperson
            ).FirstOrDefault();
            return objcompanymaster;
        }
        public IList<CompanyMasterDTO>Get_CompanyList(CRUDContext context)
        {
            var CompanyDTo = new List<CompanyMasterDTO>();
            CompanyDTo = context.CompanyMasterDTO.FromSql("SP_GetCompanyList").ToList();
            return CompanyDTo;
        }
        public CompanyMasterDTO GetCompanyById(CRUDContext context, int CompanyId)
        {
            CompanyMasterDTO companyMasterDTO = new CompanyMasterDTO();
            companyMasterDTO = context.CompanyMasterDTO.FromSql("SP_GetCompanyById  @p0", CompanyId).FirstOrDefault();

            return companyMasterDTO;
        }
        public bool DeleteCompany(CRUDContext context, CompanyMasterDTO companyMasterDTO)
        {
            var isDeleted = new SqlParameter
            {
                ParameterName = "retVal",
                DbType = System.Data.DbType.Boolean,
                Direction = System.Data.ParameterDirection.Output
            };
            var result = context.Database.ExecuteSqlCommand("Sp_DeleteCompanyByID @p0, @retVal OUT", companyMasterDTO.CompanyId, isDeleted);
            return (bool)isDeleted.Value;
        }
        public bool CheckDuplicateCompanyName(CRUDContext context, string EntityTitle, int EntityID)
        {
            var out2 = new SqlParameter
            {
                ParameterName = "p2",
                DbType = System.Data.DbType.Boolean,
                Direction = System.Data.ParameterDirection.Output
            };
            var sql = "Sp_CheckDuplicateCompanyName @p0,@p1,@p2 OUT";
            var result = context.Database.ExecuteSqlCommand(sql, EntityTitle,EntityID, out2);
            return (bool)out2.Value;
        }

        public bool CheckDuplicateCompanyCode(CRUDContext context, string EntityTitle, int EntityID)
        {
            var out2 = new SqlParameter
            {
                ParameterName = "p2",
                DbType = System.Data.DbType.Boolean,
                Direction = System.Data.ParameterDirection.Output
            };
            var sql = "Sp_CheckDuplicateCompanyCode @p0,@p1,@p2 OUT";
            var result = context.Database.ExecuteSqlCommand(sql, EntityTitle, EntityID, out2);
            return (bool)out2.Value;
        }
    }
}
