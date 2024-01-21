using System.Collections.Generic;
using System.Linq;
using WelspunVessel.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

namespace WelspunVessel.DAL.DataLayer.Masters
{
    public class ImageMasterDAL
    {
        CRUDContext _context;
        public int Insert_ImageMaster(CRUDContext context, ImageMasterDTO objImageMaster)
        {
            _context = context;
            
            return _context.Database.ExecuteSqlCommand("usp_Insert_ImageMaster @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10",
                objImageMaster.ImageCategoryID,
                objImageMaster.ImageTypeID,
                objImageMaster.ImageName,
                objImageMaster.FileType,
                objImageMaster.ImageOriginal,
                objImageMaster.ImageSmall,
                objImageMaster.ImageMedium,
                objImageMaster.ImageLarge,
                objImageMaster.CreatedDate, 
                objImageMaster.CreatedBy,
                objImageMaster.EntityID);
     
        }

        public ImageMasterDTO GetImageByID(CRUDContext context, long EntityID, int ImageCategoryID)
        {
            _context = context;
            return _context.ImageMasterDTO.FromSql("usp_GetImageByID  @p0, @p1", EntityID, ImageCategoryID).FirstOrDefault();
        }
        
        public int DeleteImageByID(CRUDContext context, int ID)
        {
            _context = context;
            return _context.Database.ExecuteSqlCommand("usp_DeleteImageByID @p0", ID);
        }
    }
}
