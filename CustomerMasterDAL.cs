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
    public class CustomerMasterDAL
    {
        public CustomerMasterDTO InsertUpdate_CustomerMaster(CRUDContext context, CustomerMasterDTO objcustomerMaster)
        {
            //CustomerMasterDTO objcustomer = new CustomerMasterDTO();
            objcustomerMaster = context.CustomerMasterDTO.FromSql("usp_InsertUpdate_CustomerMaster @p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16",
                objcustomerMaster.CustomerID,
                objcustomerMaster.FirstName,
                objcustomerMaster.LastName,
                objcustomerMaster.Mobile,
                objcustomerMaster.Email,
                objcustomerMaster.CityId,
                objcustomerMaster.CountryId,
                objcustomerMaster.PostalCode,
                objcustomerMaster.IsActive,
                objcustomerMaster.IsDeleted,
                objcustomerMaster.CreatedDate,
                objcustomerMaster.ModifiedDate,
                objcustomerMaster.CreatedBy,
                objcustomerMaster.ModifiedBy,
                objcustomerMaster.AddressLine1,
                objcustomerMaster.AddressLine2,
                objcustomerMaster.CustomerName
                ).FirstOrDefault();
            return objcustomerMaster;
        }
        public CustomerMasterDTO GetCustomerMasterByID(CRUDContext context, int CustomerID)
        {

            CustomerMasterDTO objCustomerMster = new CustomerMasterDTO();
            objCustomerMster = context.CustomerMasterDTO.FromSql("sp_GetCustomerDetailByID  @p0", CustomerID).FirstOrDefault();

            return objCustomerMster;
        }
        public IList<CustomerMasterDTO> Get_CustomerDetail(CRUDContext context)
        {

            return context.CustomerMasterDTO.FromSql("usp_GetCustomerDetail").ToList();
        }
        public IList<CountryMasterDDLDTO> Get_CountryMster(CRUDContext context)
        {

            List<CountryMasterDDLDTO> countryDDL = new List<CountryMasterDDLDTO>();
            return context.CountryMasterDDLDTO.FromSql("Sp_GetCountryMaster").ToList();
        }
        public IList<CityMasterDDLDTO> Get_CityMster(CRUDContext context)
        {

            List<CityMasterDDLDTO> CityDDL = new List<CityMasterDDLDTO>();
            return context.CityMasterDDLDTO.FromSql("Sp_GetCityMaster").ToList();
        }


        public CustomerMasterDTO GetCustomerDetailByID(CRUDContext context, int CustomerID)
        {

            CustomerMasterDTO objcustomer = new CustomerMasterDTO();
            objcustomer = context.CustomerMasterDTO.FromSql("Sp_GetCustomerDetail  @p0", CustomerID).FirstOrDefault();

            return objcustomer;
        }
        public bool DeleteCustomerDetailByID(CRUDContext context, CustomerMasterDTO objcustomer)
        {

            var IsDeleted = new SqlParameter
            {
                ParameterName = "retVal",
                DbType = System.Data.DbType.Boolean,
                Direction = System.Data.ParameterDirection.Output
            };
            var result = context.Database.ExecuteSqlCommand("usp_DeleteCustomerDetailByID @p0, @retVal OUT", objcustomer.CustomerID, IsDeleted);
            return (bool)IsDeleted.Value;
        }



    }
}
