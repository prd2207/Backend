using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WelspunVessel.DTO;
using Microsoft.EntityFrameworkCore;

namespace WelspunVessel.DAL.DataLayer.Masters
{
    public class BrandMasterDAL
    {
        CRUDContext _context;
        public BrandMasterDTO InsertUpdate_BrandMaster(CRUDContext context, BrandMasterDTO objBrandMaster)
        {
            _context = context;
            BrandMasterDTO objBrand = new BrandMasterDTO();
            objBrand = _context.BrandMasterDTO.FromSql("usp_InsertUpdate_BrandMaster @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10", objBrandMaster.ID, objBrandMaster.ChainID, objBrandMaster.BrandTitle, objBrandMaster.BrandDescription, objBrandMaster.Status, objBrandMaster.Color, objBrandMaster.IsDeleted, objBrandMaster.CreatedDate, objBrandMaster.CreatedBy, objBrandMaster.ModifiedDate, objBrandMaster.ModifiedBy).FirstOrDefault();
            return objBrand;
        }

        public IList<BrandMasterDTO> GetAll_BrandMaster(CRUDContext context)
        {
            _context = context;
            return _context.BrandMasterDTO.FromSql("usp_GetAllBrand").ToList();
        }

        public BrandMasterDTO GetBrandMasterDetailByID(CRUDContext context, int ID, long ImageCategoryID)
        {
            _context = context;
            BrandMasterDTO objBrandMaster = new BrandMasterDTO();
            objBrandMaster = _context.BrandMasterDTO.FromSql("usp_GetBrandMasterByID  @p0", ID).FirstOrDefault();

            if (ID > 0)
            {
                objBrandMaster.lstImageMaster = new List<ImageMasterDTO>();
                objBrandMaster.lstImageMaster = _context.ImageMasterDTO.FromSql("usp_GetImageByID  @p0, @p1", ID, ImageCategoryID).ToList();
            }

            return objBrandMaster;
        }

        public bool DeleteBrandMasterByID(CRUDContext context, BrandMasterDTO objBrand)
        {
            _context = context;
            var isDeleted = new SqlParameter
            {
                ParameterName = "retVal",
                DbType = System.Data.DbType.Boolean,
                Direction = System.Data.ParameterDirection.Output
            };
            var result = _context.Database.ExecuteSqlCommand("usp_DeleteBrandMasterByID @p0, @p1, @p2, @retVal OUT", objBrand.ID, objBrand.DeletedDate, objBrand.DeletedBy, isDeleted);
            return (bool)isDeleted.Value;
        }

        public IList<BrandMasterDTO> GetAll_BrandMasterByChainID(CRUDContext context,int? chainID)
        {
            _context = context;
            return _context.BrandMasterDTO.FromSql("usp_GetAllBrandMasterByChainID @p0", chainID).ToList();
        }
    }
}
