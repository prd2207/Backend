using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WelspunVessel.DTO;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using WelspunVessel.DTO.Masters;

namespace WelspunVessel.DAL.DataLayer.Masters
{
    public class UserMasterDAL
    {
        CRUDContext _context;
        public UserMasterDTO InsertUpdate_UserMaster(CRUDContext context, UserMasterDTO objUserMaster)
        {
            _context = context;
            UserMasterDTO objUserMasterDTO = new UserMasterDTO();
            if (objUserMaster.CompanyId != null && objUserMaster.CompanyId.Length > 0)
            {
                objUserMaster.CompanyIdList = String.Join(",",objUserMaster.CompanyId);
            }
            
            using (var transaction = _context.Database.BeginTransaction())
            {
                //Insert into user master
                objUserMasterDTO = _context.UserMasterDTO.FromSql("usp_InsertUpdate_UserMaster @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7,@p8, @p9, @p10, @p11, @p12, @p13, @p14, @p15", objUserMaster.UserID, objUserMaster.UserName, objUserMaster.Password, objUserMaster.EmailID, objUserMaster.MobileNo, objUserMaster.RoleID, objUserMaster.IsActive, objUserMaster.CreatedDate, objUserMaster.CreatedBy, objUserMaster.ModifiedDate, objUserMaster.ModifiedBy, objUserMaster.PIN, objUserMaster.ChainID, objUserMaster.BrandID, objUserMaster.StoreID, objUserMaster.CompanyIdList).FirstOrDefault();
                //Insert into user profile
                UserProfileDTO objUserProfileDTO = new UserProfileDTO();
                objUserProfileDTO = _context.UserProfileDTO.FromSql("usp_InsertUpdate_UserProfile @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7,@p8, @p9, @p10, @p11", objUserMaster.UserProfileDTO.UserProfileID, objUserMasterDTO.UserID, objUserMaster.UserProfileDTO.Salutation, objUserMaster.UserProfileDTO.FirstName, objUserMaster.UserProfileDTO.MiddleName, objUserMaster.UserProfileDTO.LastName, objUserMaster.UserProfileDTO.Gender, objUserMaster.UserProfileDTO.BirthDate, objUserMaster.CreatedDate, objUserMaster.CreatedBy, objUserMaster.ModifiedDate, objUserMaster.ModifiedBy).FirstOrDefault();
                //Save user  profile image
                if (objUserMaster.UserProfileDTO.IsProfileImageChange)
                {
                    ImageMasterDAL objImageMasterDAL = new ImageMasterDAL();
                    //delete old profile image
                    if (objUserMaster.UserProfileDTO.ProfileImage.ID > 0)
                    {
                        objImageMasterDAL.DeleteImageByID(context, objUserMaster.UserProfileDTO.ProfileImage.ID);
                    }
                    //Insert new profile image
                    if (objUserMaster.UserProfileDTO.ProfileImage.ImageCategoryID > 0)
                    {
                        objUserMaster.UserProfileDTO.ProfileImage.EntityID = objUserProfileDTO.UserProfileID;
                        objImageMasterDAL.Insert_ImageMaster(context, objUserMaster.UserProfileDTO.ProfileImage);
                    }
                }
                transaction.Commit();
            }
            return objUserMasterDTO;
        }
        
        public IList<UserMasterDTO> GetAll_UserMaster(CRUDContext context)
        {
            _context = context;
            return _context.UserMasterDTO.FromSql("usp_GetAllUserMaster").ToList();
        }

        //public IList<CompanyMasterDDLDTO> GetCompanyLists(CRUDContext context)
        //{
        //    _context = context;
        //    return _context.CompanyMasterDDLDTO.FromSql("SP_GetCompanyList").ToList();
        //}
        public IList<CompanyMasterDDLDTO> GetCompanyDetails(CRUDContext context)
        {
            _context = context;
            return _context.CompanyMasterDDLDTO.FromSql("Sp_GetCompanyDetails").ToList();
        }

        public List<CompanyMasterDDLDTO> GetCompanyListsByUserID(CRUDContext context , long UserID)
        {
            _context = context;
            return _context.CompanyMasterDDLDTO.FromSql("SP_CompanyListByUserID @p0", UserID).ToList();
        }

        public IList<UserMasterDTO> GetAllUserMasterByChainBrandStore(CRUDContext context,int chainId,int brandId,int storeId )
        {
            try
            {
                _context = context;
                return _context.UserMasterDTO.FromSql("usp_GetAllUserMasterByChainBrandStore @p0, @p1, @p2", chainId, brandId, storeId ).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserMasterDTO UserMasterDTO(CRUDContext context, long UserID,int imageCategory)
        {
            _context = context;
            UserMasterDTO objUserMasterDTO = new UserMasterDTO();
            objUserMasterDTO = _context.UserMasterDTO.FromSql("usp_GetUserMasterByID  @p0", UserID).FirstOrDefault();
            if (objUserMasterDTO != null)
            {
                //Get user profils details
                objUserMasterDTO.UserProfileDTO = _context.UserProfileDTO.FromSql("usp_GetUserProfileByUserID  @p0", UserID).FirstOrDefault();

                //User profile image
                if (objUserMasterDTO.UserProfileDTO != null)
                {
                    ImageMasterDAL objImageMasterDAL = new ImageMasterDAL();
                    objUserMasterDTO.UserProfileDTO.ProfileImage = objImageMasterDAL.GetImageByID(context, objUserMasterDTO.UserProfileDTO.UserProfileID, imageCategory);
                }
            }
            return objUserMasterDTO == null ? new UserMasterDTO() : objUserMasterDTO;
        }

        public bool DeleteUserMasterByID(CRUDContext context, long UserID)
        {
            _context = context;
            var RETVAL = new SqlParameter
            {
                ParameterName = "@p1",
                DbType = System.Data.DbType.Boolean,
                Direction = System.Data.ParameterDirection.Output
            };
            _context.Database.ExecuteSqlCommand("usp_DeleteUserMasterByID @p0, @p1 OUT", UserID, RETVAL);
            return (bool)RETVAL.Value;
        }



        public UserMasterDTO CheckUserNameExist(CRUDContext context, long UserID,string UserName)
        {
            _context = context;
            UserMasterDTO objUserMasterDTO = new UserMasterDTO();
            return _context.UserMasterDTO.FromSql("usp_CheckUserNameExist @p0, @p1", UserID, UserName).FirstOrDefault();
        }

        public UserMasterDTO CheckUserEmailIDExist(CRUDContext context, long UserID,string EmailID)
        {
            _context = context;
            UserMasterDTO objUserMasterDTO = new UserMasterDTO();
            return _context.UserMasterDTO.FromSql("usp_CheckUserEmailIDExist @p0, @p1", UserID, EmailID).FirstOrDefault();
        }

        public UserMasterDTO CheckUserMobileNoExist(CRUDContext context, long UserID, string MobileNo)
        {
            _context = context;
            UserMasterDTO objUserMasterDTO = new UserMasterDTO();
            return _context.UserMasterDTO.FromSql("usp_CheckUserMobileNoExist @p0, @p1", UserID, MobileNo).FirstOrDefault();
        }

        public UserMasterDTO CheckUserNameEmailIDExistForForgotPassword(CRUDContext context, long UserID, string UserNameEmailID)
        {
            _context = context;
            UserMasterDTO objUserMasterDTO = new UserMasterDTO();
            return _context.UserMasterDTO.FromSql("usp_CheckUserNameEmailIDExistForForgotPassword @p0, @p1", UserID, UserNameEmailID).FirstOrDefault();
        }

        public int UpdateUserMasterPassword(CRUDContext context, UserMasterDTO objUserMaster)
        {
            _context = context;
            return _context.Database.ExecuteSqlCommand("usp_Update_UserMaster_Password @p0, @p1, @p2, @p3, @p4", objUserMaster.UserID, objUserMaster.Password, objUserMaster.PIN, objUserMaster.ModifiedDate,objUserMaster.ModifiedBy);
        }

        public UserMasterDTO GetUserMasterByLoginCredential(CRUDContext context, string UserName)
        {
            _context = context;
            UserMasterDTO objUserMasterDTO = new UserMasterDTO();
            objUserMasterDTO = _context.UserMasterDTO.FromSql("usp_GetUserMasterByLoginCredential  @p0", UserName).FirstOrDefault();

            
            return objUserMasterDTO == null ? new UserMasterDTO() : objUserMasterDTO;
        }

        public int UpdateUserMasterPIN(CRUDContext context, UserMasterDTO objUserMaster)
        {
            _context = context;
            return _context.Database.ExecuteSqlCommand("usp_Update_UserMaster_PIN @p0, @p1, @p2, @p3", objUserMaster.UserID, objUserMaster.PIN, objUserMaster.ModifiedDate, objUserMaster.ModifiedBy);
        }

        public UserMasterDTO GetUsersInfoAndRoleRights(CRUDContext context, long UserID, int RoleID)
        {
            _context = context;
            UserMasterDTO objUserMasterDTO = new UserMasterDTO();
            objUserMasterDTO = _context.UserMasterDTO.FromSql("usp_GetUserMasterByID  @p0", UserID).FirstOrDefault();

            objUserMasterDTO.lstAllMenuRights = context.MenuRightsMappingDTO.FromSql("usp_GetAllMenuRightsMapping").ToList();
            objUserMasterDTO.lstUsersAllMenuRights = context.MenuRightsMappingDTO.FromSql("usp_GetAllMenuRightsMapping").ToList();
            if (objUserMasterDTO.RoleID > 0)
            {
                objUserMasterDTO.lstRolesRights = new List<MenuRightsMappingDTO>();
                objUserMasterDTO.lstRolesRights = context.MenuRightsMappingDTO.FromSql("usp_GetRoleRightsByRoleID @p0", objUserMasterDTO.RoleID).ToList();
            }

            if (UserID > 0)
            {
                objUserMasterDTO.lstUserRights = context.MenuRightsMappingDTO.FromSql("usp_GetUserRightsByRoleID @p0", UserID).ToList();
            }
            return objUserMasterDTO;
        }

        public bool InsertUpdate_UserRightsMapping(CRUDContext context, List<UserRightsMasterDTO> lstMenuRights, long UserID)
        {
            _context = context;
            if (lstMenuRights.Count > 0)
            {
                _context.Database.ExecuteSqlCommand("usp_DeleteUserRightsByUserID @p0", UserID);

                foreach (var item in lstMenuRights)
                {
                    _context.Database.ExecuteSqlCommand("usp_InsertUpdateUserRightsMapping @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7", item.UserRightsID, item.UserID, item.RightsID, item.MenuID, item.MenuRightsID, item.IsDeleted, item.CreatedDate, item.CreatedBy);
                }
            }
            return true;
        }
    }
}
