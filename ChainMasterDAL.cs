using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WelspunVessel.DTO;
using Microsoft.EntityFrameworkCore;

namespace WelspunVessel.DAL.DataLayer.Masters
{
    public class ChainMasterDAL
    {
        CRUDContext _context;
        public ChainMasterDTO InsertUpdate_ChainMaster(CRUDContext context, ChainMasterDTO objChainMaster)
        {
            _context = context;
            ChainMasterDTO objChain = new ChainMasterDTO();
            objChain = _context.ChainMasterDTO.FromSql("usp_InsertUpdate_ChainMaster @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14, @p15", objChainMaster.ChainID, objChainMaster.ChainTitle, objChainMaster.ChainDescription, objChainMaster.Status, objChainMaster.ContactName, objChainMaster.ContactEmail, objChainMaster.ContactMobile, objChainMaster.ContactTelephone, objChainMaster.IsDeleted, objChainMaster.CreatedDate, objChainMaster.CreatedBy, objChainMaster.ModifiedDate, objChainMaster.ModifiedBy, objChainMaster.CustomLoyaltyProgram, objChainMaster.CustomEwallet, objChainMaster.CustomStamp).FirstOrDefault();
            return objChain;
        }

        public IList<ChainMasterDTO> GetAll_ChainMaster(CRUDContext context)
        {
            _context = context;
            return _context.ChainMasterDTO.FromSql("usp_GetAllChainMaster").ToList();
        }

        public IList<ChainMasterDTO> GetAll_ChainMasterByChainID(CRUDContext context, int? ChainID)
        {
            _context = context;
            return _context.ChainMasterDTO.FromSql("usp_GetAllChainMasterByID @p0", ChainID).ToList();
        }

        public ChainMasterDTO GetChainMasterDetailByID(CRUDContext context, int ChainID, long ImageCategoryID)
        {
            _context = context;
            ChainMasterDTO objChain = new ChainMasterDTO();
            objChain =  _context.ChainMasterDTO.FromSql("usp_GetChainMasterByID  @p0", ChainID).FirstOrDefault();

            if (ChainID > 0)
            {
                objChain.lstImageMaster = new List<ImageMasterDTO>();
                objChain.lstImageMaster = _context.ImageMasterDTO.FromSql("usp_GetImageByID  @p0, @p1", ChainID, ImageCategoryID).ToList();

                objChain.lstChainModules = new List<ModuleMasterDTO>();
                objChain.lstChainModules = _context.ModuleMasterDTO.FromSql("usp_GetModuleListByChainID @p0", ChainID).ToList();
            }

            return objChain;
        }

        public bool DeleteChainMasterByID(CRUDContext context, ChainMasterDTO objChain)
        {
            _context = context;
            var isDeleted = new SqlParameter
            {
                ParameterName = "retVal",
                DbType = System.Data.DbType.Boolean,
                Direction = System.Data.ParameterDirection.Output
            };
            var result = _context.Database.ExecuteSqlCommand("usp_DeleteChainMasterByID @p0, @p1, @p2, @retVal OUT", objChain.ChainID, objChain.DeletedDate, objChain.DeletedBy, isDeleted);
            return (bool)isDeleted.Value;
        }

        public IList<ModuleMasterDTO> GetAll_Modules(CRUDContext context)
        {
            _context = context;
            return _context.ModuleMasterDTO.FromSql("usp_GetModules").ToList();
        }

        public int InsertUpdate_ChainModuleMapping(CRUDContext context, int ChainID, string ModuleIDs)
        {
            _context = context;
            return _context.Database.ExecuteSqlCommand("usp_InsertUpdate_ChainModuleMapping @p0 ,@p1", ChainID, ModuleIDs);
        }
    }
}
