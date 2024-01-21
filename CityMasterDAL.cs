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
    public class CityMasterDAL
    {
        public CityMasterDTO InsertUpdateCity(CRUDContext context, CityMasterDTO objCitymaster)
        {
            objCitymaster = context.CityMasterDTO.FromSql("SP_InsertUpdateCity @p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8",
            objCitymaster.CityId,
            objCitymaster.CountryId,
            objCitymaster.CityName,
            objCitymaster.IsActive,
            objCitymaster.IsDeleted,
            objCitymaster.CreatedBy,
            objCitymaster.CreatedDate,
            objCitymaster.ModifiedBy,
            objCitymaster.ModifiedDate
            ).FirstOrDefault();
            return objCitymaster;
        }

        public IList<CityMasterDTO> GetCityList(CRUDContext context)
        {
            var CityMasterDTo = new List<CityMasterDTO>();
            CityMasterDTo = context.CityMasterDTO.FromSql("SP_GetCityList").ToList();
            return CityMasterDTo;
        }

        public CityMasterDTO GetCityById(CRUDContext context, int CityID)
        {
            CityMasterDTO cityMasterDTO = new CityMasterDTO();
            cityMasterDTO = context.CityMasterDTO.FromSql("SP_GetCityById  @p0", CityID).FirstOrDefault();
            return cityMasterDTO;
        }


        public IList<CountryMasterDDLDTO> GetCountryList(CRUDContext context)
        {
            var countryMasterDto = new List<CountryMasterDDLDTO>();
            countryMasterDto = context.CountryMasterDDLDTO.FromSql("SP_GetCountryList").ToList();
            return countryMasterDto;
        }
        public bool DeleteCity(CRUDContext context, CityMasterDTO cityMasterDTO)
        {
            var isDeleted = new SqlParameter
            {
                ParameterName = "retVal",
                DbType = System.Data.DbType.Boolean,
                Direction = System.Data.ParameterDirection.Output
            };
            var result = context.Database.ExecuteSqlCommand("Sp_DeleteCityByID @p0, @retVal OUT", cityMasterDTO.CityId, isDeleted);
            return (bool)isDeleted.Value;
        }
        public bool CheckDuplicateCityName(CRUDContext context, string EntityTitle, int EntityID, int CountryId)
        {

            var out2 = new SqlParameter
            {
                ParameterName = "p3",
                DbType = System.Data.DbType.Boolean,
                Direction = System.Data.ParameterDirection.Output
            };

            var sql = "Sp_CheckDuplicateCityName @p0, @p1,@p2, @p3 OUT";
            var result = context.Database.ExecuteSqlCommand(sql, EntityTitle, CountryId, EntityID, out2);

            return (bool)out2.Value;
        }

    }
}
