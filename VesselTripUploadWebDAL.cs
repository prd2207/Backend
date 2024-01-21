using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelspunVessel.DTO.Files;
using WelspunVessel.DTO.Masters;

namespace WelspunVessel.DAL.DataLayer.Masters
{
    public class VesselTripUploadWebDAL
    {
        public IList<VesselTripUploadDTO> GetAllVesselUploadFileList(CRUDContext context)
        {
            var VesselTripUploadDTo = new List<VesselTripUploadDTO>();
            VesselTripUploadDTo = context.VesselTripUploadDTO.FromSql("Sp_GetAllVesselUploadFile").ToList();
            return VesselTripUploadDTo;
        }


        public VesselTripUploadDTO GetVesselUploadFileById(CRUDContext context, int VesselTripUploadMasterID)
        {
            VesselTripUploadDTO VesselTripUploadDTo = new VesselTripUploadDTO();
            VesselTripUploadDTo = context.VesselTripUploadDTO.FromSql("SP_GetVesselUploadFileByID  @p0", VesselTripUploadMasterID).FirstOrDefault();
            return VesselTripUploadDTo;
        }

        public IList<VesselTripUploadDetailsDTO>  GetVesselUploadDetailById(CRUDContext context, int @VesselTripUploadMasterID)
        {
           List<VesselTripUploadDetailsDTO>  VesselTripUploaddetailsDTo = new List<VesselTripUploadDetailsDTO>();
            VesselTripUploaddetailsDTo = context.VesselTripUploadDetailsDTO.FromSql("Sp_VesselTripUploadDetailByID  @p0", @VesselTripUploadMasterID).ToList();
            return VesselTripUploaddetailsDTo;
        }


        public bool DeleteVesselUploadFile(CRUDContext context, VesselTripUploadDTO VesselTripUploadDTo)
        {
            var isDeleted = new SqlParameter
            {
                ParameterName = "retVal",
                DbType = System.Data.DbType.Boolean,
                Direction = System.Data.ParameterDirection.Output
            };
            VesselTripUploadDTo.DeletedDate= DateTime.Now;
            var result = context.Database.ExecuteSqlCommand("SP_DeleteVesselFileById @p0, @p1, @retVal OUT", VesselTripUploadDTo.VesselTripUploadMasterID, isDeleted, VesselTripUploadDTo.DeletedDate);
            return (bool)isDeleted.Value;
        }
    }
}
