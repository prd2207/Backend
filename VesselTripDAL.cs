using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WelspunVessel.DTO.Files;
using WelspunVessel.DTO.Masters;

namespace WelspunVessel.DAL.DataLayer.Masters
{
    public class VesselTripDAL
    {

        public VesselTripDTO InsertUpdate_VesselTrip(CRUDContext context, VesselTripDTO objVesseltripMaster, List<VesselTripDetailDTO> lst)
        {
            try
            {
                DataTable dt = new DataTable();
                //Add column in dt (VesselTripDetail)
                dt.Columns.Add("SrNo", typeof(int));
                dt.Columns.Add("VesselTripDetailID", typeof(int));
                dt.Columns.Add("VesselTripID", typeof(int));
                dt.Columns.Add("CustomerID", typeof(int));
                dt.Columns.Add("Container", typeof(string));
                dt.Columns.Add("InvoiceNumber", typeof(string));
                dt.Columns.Add("BLNumber", typeof(string));
                dt.Columns.Add("InvoiceDate", typeof(DateTime));
                dt.Columns.Add("AmountInDocCurrency", typeof(decimal));
                dt.Columns.Add("AmountInINR", typeof(decimal));
                //Add data row in dt
                //TODO: Save in database
                if (lst != null)
                {
                    int count = 1;
                    foreach (var itemVesselTripDetailDTO in lst)
                    {
                        DataRow row = dt.NewRow();
                        row["SrNo"] = count;
                        row["VesselTripDetailID"] = itemVesselTripDetailDTO.VesselTripDetailID;
                        row["VesselTripID"] = itemVesselTripDetailDTO.VesselTripID;
                        row["CustomerID"] = itemVesselTripDetailDTO.CustomerID;
                        row["Container"] = itemVesselTripDetailDTO.Container;
                        row["InvoiceNumber"] = itemVesselTripDetailDTO.InvoiceNumber;
                        row["BLNumber"] = itemVesselTripDetailDTO.BLNumber;
                        row["InvoiceDate"] = itemVesselTripDetailDTO.InvoiceDate;
                        row["AmountInDocCurrency"] = itemVesselTripDetailDTO.AmountInDocCurrency ?? 0;
                        row["AmountInINR"] = itemVesselTripDetailDTO.AmountInINR ?? 0;
                        dt.Rows.Add(row);
                        count = count + 1;
                    }
                }
                var paramUDDTName = new SqlParameter("@UDTVesselTripList", dt) { TypeName = "dbo.UDDT_VesselTripList", SqlDbType = SqlDbType.Structured };


                VesselTripDTO objvesseltrip = new VesselTripDTO();
                objvesseltrip = context.VesselTripDTO.FromSql("usp_InsertUpdate_VesselTrip @p0, @p1, @p2, @p3, @p4, @p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17,@p18,@p19, @p20,@p21,@UDTVesselTripList",
                    objVesseltripMaster.VesselTripID,
                    objVesseltripMaster.DeparturePortID,
                    objVesseltripMaster.ArrivalPortID,
                    objVesseltripMaster.TentitiveDepartureDate,
                    objVesseltripMaster.TentitiveDepartureTime,
                    objVesseltripMaster.TentitiveArrivalDate,
                    objVesseltripMaster.TentitiveArrivalTime,
                    objVesseltripMaster.ActualDepartureDate,
                    objVesseltripMaster.ActualDepartureTime,
                    objVesseltripMaster.ActualArrivalDate,
                    objVesseltripMaster.ActualArrivalTime,
                    objVesseltripMaster.IsDeleted,
                    objVesseltripMaster.CreatedDate,
                    objVesseltripMaster.CreatedBy,
                    objVesseltripMaster.ModifiedDate,
                    objVesseltripMaster.ModifiedBy,
                    objVesseltripMaster.VesselID,
                    objVesseltripMaster.CompanyID,
                    objVesseltripMaster.Lat,
                    objVesseltripMaster.Lon,
                    objVesseltripMaster.TotalAmountInDocCurrency,
                    objVesseltripMaster.TotalAmountInINR,
                    paramUDDTName
                    ).FirstOrDefault();
                return objvesseltrip;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public VesselTripDTO GetVesselTripMasterByID(CRUDContext context, int VesselTripID)
        {

            VesselTripDTO objvesseltrip = new VesselTripDTO();
            objvesseltrip = context.VesselTripDTO.FromSql("sp_GetVesselTripByID  @p0", VesselTripID).FirstOrDefault();

            return objvesseltrip;
        }
        public IList<VesselTripDTO> Get_VesselTripDetail(CRUDContext context)
        {

            return context.VesselTripDTO.FromSql("usp_GetVesselTripDetail").ToList();
        }
        public IList<PortMasterDDLDTO> Get_PortMster(CRUDContext context)
        {
            List<PortMasterDDLDTO> PortDDL = new List<PortMasterDDLDTO>();
            return context.PortMasterDDLDTO.FromSql("Sp_GetPortDetail").ToList();
        }

        public IList<VesselNumberDDLDTO> Get_VesselNumberDetails(CRUDContext context)
        {
            List<VesselNumberDDLDTO> PortDDL = new List<VesselNumberDDLDTO>();
            return context.VesselNumberDDLDTO.FromSql("Sp_GetVesselNumberDetails").ToList();
        }

        public IList<ContainerMasterDDLDTO> GetContainerDetails(CRUDContext context)
        {
            List<ContainerMasterDDLDTO> PortDDL = new List<ContainerMasterDDLDTO>();
            return context.ContainerMasterDDLDTO.FromSql("Sp_GetContainerDetails").ToList();
        }

        public VesselTripDTO GetVesselDetailByID(CRUDContext context, int VesselTripID)
        {

            VesselTripDTO objvessel = new VesselTripDTO();
            objvessel = context.VesselTripDTO.FromSql("Sp_GetVesseltripDetail  @p0", VesselTripID).FirstOrDefault();

            return objvessel;
        }
        public bool DeleteVesseltripDetailByID(CRUDContext context, VesselTripDTO objvesseltrip)
        {
            var IsDeleted = new SqlParameter
            {
                ParameterName = "retVal",
                DbType = System.Data.DbType.Boolean,
                Direction = System.Data.ParameterDirection.Output
            };
            var result = context.Database.ExecuteSqlCommand("usp_DeleteVesseltripDetailByID @p0, @retVal OUT", objvesseltrip.VesselTripID, IsDeleted);
            return (bool)IsDeleted.Value;
        }
        //for Popup (Vessel Trip Detail)
        public VesselTripDetailDTO GetVesselTripDetail(CRUDContext context, int id)
        {
            try
            {
                VesselTripDetailDTO objvesseltripDetail = new VesselTripDetailDTO();
                objvesseltripDetail = context.VesselTripDetailDTO.FromSql("Sp_GetVesselTripDetailById @p0", id).FirstOrDefault();
                if (objvesseltripDetail == null)
                {
                    objvesseltripDetail = new VesselTripDetailDTO();
                }
                return objvesseltripDetail;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public IList<CustomerDetailDDLDTO> Get_CustomerDetail(CRUDContext context)
        {

            List<CustomerDetailDDLDTO> CustomerDDL = new List<CustomerDetailDDLDTO>();
            return context.CustomerDetailDDLDTO.FromSql("Sp_GetCustomerNameDetail").ToList();
        }

        //For GridView (for Vessel Trip Detail)
        public List<VesselTripDetailDTO> Get_VsselTripDetail(CRUDContext context, int id)
        {
            try
            {
                var VesseltripDetail = new List<VesselTripDetailDTO>();
                VesseltripDetail = context.VesselTripDetailDTO.FromSql("SP_ListVesselTripDetail @p0", id).ToList();
                return VesseltripDetail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // delete (get) method  for partial (Vessel Trip Detail) view

        public VesselTripDetailDTO GetVesselTripdetailByID(CRUDContext context, int VesselTripDetailID)
        {
            VesselTripDetailDTO objvesseltripDetail = new VesselTripDetailDTO();
            objvesseltripDetail = context.VesselTripDetailDTO.FromSql("usp_GetVesselTripDetailByID  @p0", VesselTripDetailID).FirstOrDefault();

            return objvesseltripDetail;
        }

        public async Task <UpdateVesselEndTripDTO> UpdateVesselEndTrip(CRUDContext context, UpdateVesselEndTripDTO objvesseltrip)
        {
            try
            {
                UpdateVesselEndTripDTO vesseltrip = new UpdateVesselEndTripDTO();
                var var = context.Database.ExecuteSqlCommand("SP_UpdateVesselEndTrip @p0,@p1,@p2",
                    objvesseltrip.VesselTripID.ToString(),
                    DateTime.ParseExact(objvesseltrip.ActualArrivalDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Convert.ToDateTime(objvesseltrip.ActualArrivalTime));
                return vesseltrip;
            }
            catch (Exception ex)
            {
                throw ex;
            }
         
        }

       public async Task<List<VesselTripAPIDTO>> GetVesselEndTripList(CRUDContext context)
        {
            List<VesselTripAPIDTO> result = new List<VesselTripAPIDTO>();
            try
            {
                return context.VesselTripAPIDTO.FromSql("usp_GetVesselTripDetail").ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public VesselTripAPIDTO GetVesselEndTripDetailByID(CRUDContext context, int VesselTripID)
        {
            VesselTripAPIDTO vesselTripAPIDTO = new VesselTripAPIDTO();
            vesselTripAPIDTO = context.VesselTripAPIDTO.FromSql("sp_GetVesselTripByID  @p0", VesselTripID).FirstOrDefault();

            return vesselTripAPIDTO;
        }


        CRUDContext cRUDContext;

        public int InsertVesselTripUploadData(CRUDContext context, CSVFileDTO cSVFile, int Vesseltripuploadmasterid)
        {
            try
            {
                cRUDContext = context;

                var result = cRUDContext.Database.ExecuteSqlCommand("SP_InsertVesselTripUploadData  @p0, @p1, @p2, @p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@P13,@P14,@P15,@P16,@p17,@p18,@p19,@p20,@p21,@p22,@p23,@p24",
                    cSVFile.WelspunCompany,
                    cSVFile.VesselNumber,
                    cSVFile.VesselName,
                    cSVFile.CustomerCompany,
                    cSVFile.Container,
                    //cSVFile.AmountInUSD,
                    //cSVFile.TotalAmountInUSD,
                    cSVFile.SourcePort,
                    cSVFile.TentativeStartDate,
                    cSVFile.TentativeStartTime,
                    cSVFile.ActualStartDate,
                    cSVFile.ActualStartTime,
                    cSVFile.DestinationPort,
                    cSVFile.TentativeEndDate,
                    cSVFile.TentativeEndTime,
                    cSVFile.ActualEndDate,
                    cSVFile.ActualEndTime,
                    cSVFile.CustomerCode,
                    cSVFile.InvoiceNumber,
                    cSVFile.BLNumber,
                    cSVFile.InvoiceDate,
                    cSVFile.AmountInDocCurrency,
                    cSVFile.AmountInINR,
                    cSVFile.TotalAmountInDocCurrency,
                    cSVFile.TotalAmountInINR,
                    cSVFile.VesselTripUploadMasterID = Vesseltripuploadmasterid,
                    cSVFile.ValidationSummary
                    

                    );

                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public int InsertVesselTripUploadMasterData(CRUDContext context, VesselTripUploadDTO vesselTripUpload)
        {
            try
            {
                cRUDContext = context;
                var Vesseltripuploadmasterid = new SqlParameter
                {
                    ParameterName = "retVal",
                    DbType = System.Data.DbType.Int32,
                    Direction = System.Data.ParameterDirection.Output
                };
                var result = cRUDContext.Database.ExecuteSqlCommand("InsertUploadedFileData  @p0, @p1, @p2, @p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10, @retVal OUT",
                   // vesselTripUpload.VesselTripUploadMasterID,
                    vesselTripUpload.FileName,
                    vesselTripUpload.ActualFileName,
                    vesselTripUpload.TotalRecords,
                    vesselTripUpload.UploadStatus,
                    //cSVFile.AmountInUSD,
                    //cSVFile.TotalAmountInUSD,
                    vesselTripUpload.IsDeleted,
                    vesselTripUpload.CreatedDate,
                    vesselTripUpload.CreatedBy,
                    vesselTripUpload.ModifiedDate,
                    vesselTripUpload.ModifiedBy,
                    vesselTripUpload.DeletedDate,
                    vesselTripUpload.DeletedBy,
                    Vesseltripuploadmasterid
                    );
                if (Vesseltripuploadmasterid != null)
                {


                    return Convert.ToInt32(Vesseltripuploadmasterid.Value);
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public int InsertVesselTripData(CRUDContext context, CSVFileDTO cSVFile, int Vesseltripuploadmasterid)
        {
            try
            {
                cRUDContext = context;

                var result = cRUDContext.Database.ExecuteSqlCommand("SP_InsertVesselTripData  @p0, @p1, @p2, @p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@P13,@P14,@P15,@p16,@p17,@p18,@p19,@p20,@p21,@p22,@p23,@p24,@p25,@p26",
                    cSVFile.SourcePort,
                    cSVFile.DestinationPort,
                    cSVFile.TentativeStartDate,
                    cSVFile.TentativeStartTime,
                    cSVFile.TentativeEndDate,
                    cSVFile.TentativeEndTime,
                    cSVFile.ActualStartDate,
                    cSVFile.ActualStartTime,
                    cSVFile.ActualEndDate,
                    cSVFile.ActualEndTime,
                   // cSVFile.TotalAmountInUSD,
                    cSVFile.IsDelete = false,
                    cSVFile.CreatedDate = DateTime.Now,
                    cSVFile.CreatedBy,
                    cSVFile.ModifiedDate = DateTime.Now,
                    cSVFile.ModifiedBy,
                    cSVFile.WelspunCompany,
                    cSVFile.VesselNumber,
                    cSVFile.Container,
                    cSVFile.CustomerCompany,
                    //cSVFile.AmountInUSD,
                    //cSVFile.CustomerCode,
                    cSVFile.InvoiceNumber,
                    cSVFile.BLNumber,
                    cSVFile.InvoiceDate,
                    cSVFile.AmountInDocCurrency,
                    cSVFile.AmountInINR,
                    cSVFile.TotalAmountInDocCurrency,
                    cSVFile.TotalAmountInINR,
                    cSVFile.VesselTripUploadMasterID = Vesseltripuploadmasterid
                    );

                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        //public async Task<List<GetDataCSVDTO>> GetAll_CSVData(CRUDContext context)
        //{
        //    List<GetDataCSVDTO> result = new List<GetDataCSVDTO>();
        //    try
        //    {
        //        cRUDContext = context;
        //        result = (cRUDContext.GetDataCSVDTO.FromSql("SP_GetAllCSVData")).ToList();
        //        return result;

        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }

        //}

        public async Task<List<PortMasterDDLDTO>> GetAllPortDetail(CRUDContext context)
        {
            List<PortMasterDDLDTO> result = new List<PortMasterDDLDTO>();
            try
            {
                cRUDContext = context;
                result = (cRUDContext.PortMasterDDLDTO.FromSql("Sp_GetPortDetail")).ToList();
                return result;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<List<VesselNumberDDLDTO>> GetAllVesselNumberDetail(CRUDContext context)
        {
            List<VesselNumberDDLDTO> result = new List<VesselNumberDDLDTO>();
            try
            {
                cRUDContext = context;
                result = (cRUDContext.VesselNumberDDLDTO.FromSql("Sp_GetVesselNumberDetails")).ToList();
                return result;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<List<ContainerMasterDDLDTO>> GetAllContainerDetail(CRUDContext context)
        {
            List<ContainerMasterDDLDTO> result = new List<ContainerMasterDDLDTO>();
            try
            {
                cRUDContext = context;
                result = (cRUDContext.ContainerMasterDDLDTO.FromSql("Sp_GetContainerDetails")).ToList();
                return result;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<List<VesselMasterDDLDTO>> GetAllVesselNameDetail(CRUDContext context)
        {
            List<VesselMasterDDLDTO> result = new List<VesselMasterDDLDTO>();
            try
            {
                cRUDContext = context;
                result = (cRUDContext.VesselMasterDDLDTO.FromSql("SP_GetVesselName")).ToList();
                return result;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<List<CustomerDetailDDLDTO>> GetAllCustomerNameDetail(CRUDContext context)
        {
            List<CustomerDetailDDLDTO> result = new List<CustomerDetailDDLDTO>();
            try
            {
                cRUDContext = context;
                result = (cRUDContext.CustomerDetailDDLDTO.FromSql("Sp_GetCustomerNameDetail")).ToList();
                return result;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<List<CompanyMasterDDLDTO>> GetAllCompanyNameDetail(CRUDContext context)
        {
            List<CompanyMasterDDLDTO> result = new List<CompanyMasterDDLDTO>();
            try
            {
                cRUDContext = context;
                result = (cRUDContext.CompanyMasterDDLDTO.FromSql("SP_GetCompanyList")).ToList();
                return result;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}

