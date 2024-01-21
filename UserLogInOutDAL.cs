using System.Collections.Generic;
using System.Linq;
using WelspunVessel.DTO;
using WelspunVessel.DTO.Masters;
using Microsoft.EntityFrameworkCore;

namespace WelspunVessel.DAL.DataLayer.Masters
{
    public class UserLogInOutDAL
    {
        CRUDContext _context;
        public int InsertUpdate_UserLogInOut(CRUDContext context, UserLogInOutDTO objUserLogInOut)
        {
            _context = context;
            return _context.Database.ExecuteSqlCommand("usp_InsertUpdate_UserLogInOut @p0, @p1, @p2, @p3, @p4", objUserLogInOut.UserID, objUserLogInOut.LogInTime, objUserLogInOut.LogOutTime, objUserLogInOut.IsMobile, objUserLogInOut.IPAddress);
        }
    }
}
