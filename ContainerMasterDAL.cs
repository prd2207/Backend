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
    public class ContainerMasterDAL
    {
        public ContainerMasterDTO AddEditContainer(CRUDContext context , ContainerMasterDTO objcontainer)
        {
            objcontainer = context.ContainerMasterDTO.FromSql("SP_InsertUpdateContainerMaster @p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8",
                objcontainer.ContainerID,
                objcontainer.VesselMasterID,
                objcontainer.ContainerNumber,
                objcontainer.IsActive,
                objcontainer.IsDeleted,
                objcontainer.CreatedBy,
                objcontainer.CreatedDate,
                objcontainer.ModifiedBy,
                objcontainer.ModifiedDate
                ).FirstOrDefault();
            return objcontainer;
        }

        public IList<ContainerMasterDTO> GetContainerList(CRUDContext context )
        {
            var objcontainer = new List<ContainerMasterDTO>();
            objcontainer = context.ContainerMasterDTO.FromSql("SP_GetContainerList").ToList();
            return objcontainer;
        }

        public ContainerMasterDTO GetContainerById(CRUDContext context , int ContainerID)
        {
            ContainerMasterDTO objcontainer = new ContainerMasterDTO();
            objcontainer = context.ContainerMasterDTO.FromSql("SP_ContainerMasterByID @p0", ContainerID).FirstOrDefault();
            return objcontainer;
        }


        public IList<VesselMasterDDLDTO> GetVesselList(CRUDContext context)
        {
            var objVesselMaster = new List<VesselMasterDDLDTO>();
            objVesselMaster = context.VesselMasterDDLDTO.FromSql("SP_GetVesselName").ToList();
            return objVesselMaster;
        }
        public bool DeleteContainer(CRUDContext context, ContainerMasterDTO objcontainer)
        {
            var isDeleted = new SqlParameter
            {
                ParameterName = "retVal",
                DbType = System.Data.DbType.Boolean,
                Direction = System.Data.ParameterDirection.Output
            };
            var result = context.Database.ExecuteSqlCommand("SP_DeletedContainerById @p0, @retVal OUT", objcontainer.ContainerID, isDeleted);
            return (bool)isDeleted.Value;
        }
        public bool CheckDuplicateContainerNumber(CRUDContext context, string EntityTitle, int VesselMasterID, int EntityID)
        {



            var out2 = new SqlParameter
            {
                ParameterName = "p3",
                DbType = System.Data.DbType.Boolean,
                Direction = System.Data.ParameterDirection.Output
            };



            var sql = "Sp_CheckDuplicateContainerNumber @p0, @p1,@p2, @p3 OUT";
            var result = context.Database.ExecuteSqlCommand(sql, EntityTitle, VesselMasterID, EntityID, out2);



            return (bool)out2.Value;
        }

    }
}
