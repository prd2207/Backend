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
   public class PortMasterDAL
    {
        public PortMasterDTO AddEditPortDetails(PortMasterDTO objportmaster , CRUDContext context)
        {
            objportmaster = context.PortMasterDTO.FromSql("SP_InsertUpdatePortMaster @p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8",
                objportmaster.PortId,
                objportmaster.CountryId,
                objportmaster.PortName,
                objportmaster.IsActive,
                objportmaster.IsDeleted,
                objportmaster.CreatedBy,
                objportmaster.CreatedDate,
                objportmaster.ModifiedBy,
                objportmaster.ModifiedDate).FirstOrDefault();
                return objportmaster;
        }

        public PortMasterDTO GetPortDetailById(CRUDContext context, int PortId)
        {
            PortMasterDTO portMasterDTO = new PortMasterDTO();
            portMasterDTO = context.PortMasterDTO.FromSql("SP_GetPortDetailById @p0", PortId).FirstOrDefault();

            return portMasterDTO;
        }

        public List<PortMasterDTO> GetPortDetails(CRUDContext context)
        {
            var portmasterDto = new List<PortMasterDTO>();
            portmasterDto = context.PortMasterDTO.FromSql("SP_GetPortList").ToList();
            return portmasterDto;
        }

        public IList<CountryMasterDDLDTO> GetCountryList(CRUDContext context)
        {
            var countryMasterDto = new List<CountryMasterDDLDTO>();
            countryMasterDto = context.CountryMasterDDLDTO.FromSql("SP_GetCountryList").ToList();
            return countryMasterDto;
        }
        public bool DeletePort(CRUDContext context, PortMasterDTO portMasterDTO)
        {
            var isDeleted = new SqlParameter
            {
                ParameterName = "retVal",
                DbType = System.Data.DbType.Boolean,
                Direction = System.Data.ParameterDirection.Output
            };
            var result = context.Database.ExecuteSqlCommand("SP_DeletePortDetailById @p0, @retVal OUT", portMasterDTO.PortId, isDeleted);
            return (bool)isDeleted.Value;
        }
        public bool CheckDuplicatePortName(CRUDContext context, string EntityTitle, int EntityID, int CountryId)
        {

            var out2 = new SqlParameter
            {
                ParameterName = "p3",
                DbType = System.Data.DbType.Boolean,
                Direction = System.Data.ParameterDirection.Output
            };

            var sql = "Sp_CheckDuplicatePortName @p0,@p1,@p2,@p3 OUT";
            var result = context.Database.ExecuteSqlCommand(sql, EntityTitle, CountryId, EntityID, out2);

            return (bool)out2.Value;
        }
    }
}
