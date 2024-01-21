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
    public class CountryMasterDAL
    {
        public CountryMasterDTO InsertUpdateCountry(CRUDContext context, CountryMasterDTO objcountrymaster)
        {
            objcountrymaster = context.CountryMasterDTO.FromSql("SP_InsertupdateCountry @p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7",
            objcountrymaster.CountryId,
            objcountrymaster.CountryName,
            objcountrymaster.IsActive,
            objcountrymaster.IsDeleted,
            objcountrymaster.CreatedBy,
            objcountrymaster.CreatedDate,
            objcountrymaster.ModifiedBy,
            objcountrymaster.ModifiedDate
            ).FirstOrDefault();
            return objcountrymaster;
        }

        public IList<CountryMasterDTO> Get_CountryList(CRUDContext context)
        {
            var CountryMasterDTo = new List<CountryMasterDTO>();
            CountryMasterDTo = context.CountryMasterDTO.FromSql("SP_GetCountryList").ToList();
            return CountryMasterDTo;
        }

        public CountryMasterDTO GetAPICountryById(CRUDContext context, int CountryId)
        {
            CountryMasterDTO countryMasterDTO = new CountryMasterDTO();
            countryMasterDTO = context.CountryMasterDTO.FromSql("SP_GetCountryById  @p0", CountryId).FirstOrDefault();

            return countryMasterDTO;
        }

        public int DeleteCountry(CRUDContext context, CountryMasterDTO countryMasterDTO)
        {
            var isDeleted = new SqlParameter
            {
                ParameterName = "retVal",
                DbType = System.Data.DbType.Int32,
                Direction = System.Data.ParameterDirection.Output
            };
            var result = context.Database.ExecuteSqlCommand("Sp_DeleteCountryByID @p0, @retVal OUT", countryMasterDTO.CountryId, isDeleted);
            return (int)isDeleted.Value;
        }

        public bool CheckDuplicateCountryName(CRUDContext context, string EntityTitle, int EntityID)
        {

            var out2 = new SqlParameter
            {
                ParameterName = "p2",
                DbType = System.Data.DbType.Boolean,
                Direction = System.Data.ParameterDirection.Output
            };

            var sql = "Sp_CheckDuplicateCountryName @p0, @p1,@p2 OUT";
            var result = context.Database.ExecuteSqlCommand(sql, EntityTitle, EntityID, out2);

            return (bool)out2.Value;
        }
    }
}
