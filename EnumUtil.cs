using WelspunVessel.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WelspunVessel.DAL.DataLayer.Masters
{
    public class EnumUtil
    {
        CRUDContext _context;
        public static IDictionary<int, string> GetListItemCollection<TEnum>() where TEnum : struct
        {
            var enumerationType = typeof(TEnum);

            if (!enumerationType.IsEnum)
                throw new ArgumentException("Enumeration type is expected.");

            var dictionary = new Dictionary<int, string>();

            foreach (int value in Enum.GetValues(enumerationType))
            {
                var name = Enum.GetName(enumerationType, value);
                dictionary.Add(value, name);
            }

            return dictionary;
        }

        public static IDictionary<int, string> GetListItemCollectionByDisplayName<TEnum>() where TEnum : struct
        {
            var enumerationType = typeof(TEnum);

            if (!enumerationType.IsEnum)
                throw new ArgumentException("Enumeration type is expected.");

            var dictionary = new Dictionary<int, string>();

            foreach (int value in Enum.GetValues(enumerationType))
            {
                var name = Enum.GetName(enumerationType, value);
                FieldInfo fi = enumerationType.GetField(name.ToString());
                var Disname = fi.GetCustomAttributes(typeof(DisplayAttribute), true);
                dictionary.Add(value, ((DisplayAttribute)Disname[0]).Name);
            }

            return dictionary;
        }

        public static IDictionary<int, string> GetListItemCollectionByDescription<TEnum>() where TEnum : struct
        {
            var enumerationType = typeof(TEnum);

            if (!enumerationType.IsEnum)
                throw new ArgumentException("Enumeration type is expected.");

            var dictionary = new Dictionary<int, string>();

            foreach (int value in Enum.GetValues(enumerationType))
            {
                var name = Enum.GetName(enumerationType, value);
                FieldInfo fi = enumerationType.GetField(name.ToString());
                var Disname = fi.GetCustomAttributes(typeof(DisplayAttribute), true);
                dictionary.Add(value, ((DisplayAttribute)Disname[0]).Description);
            }

            return dictionary;
        }

        #region Get Eum DisplayName

        public static string GetEnumDisplayName(object enumValue)
        {
            string defDesc = string.Empty;
            FieldInfo fi = enumValue.GetType().GetField(enumValue.ToString());

            if (null != fi)
            {
                object[] attrs = fi.GetCustomAttributes(typeof(DisplayAttribute), true);
                if (attrs != null && attrs.Length > 0)
                    return ((DisplayAttribute)attrs[0]).Name;
            }

            return defDesc;
        }

        public static string GetEnumDescription(object enumValue)
        {
            string defDesc = string.Empty;
            FieldInfo fi = enumValue.GetType().GetField(enumValue.ToString());

            if (null != fi)
            {
                object[] attrs = fi.GetCustomAttributes(typeof(DisplayAttribute), true);
                if (attrs != null && attrs.Length > 0)
                    return ((DisplayAttribute)attrs[0]).Description;
            }

            return defDesc;
        }

        #endregion Get Eum DisplayName

        public bool CheckEmailAddressExistOrNot(CRUDContext context, string EmailID, int EntityID, string EntityName)
        {
            _context = context;
            var out1 = new SqlParameter
            {
                ParameterName = "p3",
                DbType = System.Data.DbType.Boolean,
                Direction = System.Data.ParameterDirection.Output
            };
            
            var sql = "exec CheckEmailAddressExistOrNot @p0, @p1, @p2, @p3 OUT";
            var result = _context.Database.ExecuteSqlCommand(sql, EmailID, EntityID, EntityName, out1);

            return (bool)out1.Value;
        }

        public bool CheckPhoneNumberExistOrNot(CRUDContext context, string PhoneNo, int EntityID, string EntityName)
        {
            _context = context;
            var out2 = new SqlParameter
            {
                ParameterName = "p3",
                DbType = System.Data.DbType.Boolean,
                Direction = System.Data.ParameterDirection.Output
            };
            
            var sql = "exec CheckPhoneNumberExistOrNot @p0, @p1, @p2, @p3 OUT";
            var result = _context.Database.ExecuteSqlCommand(sql, PhoneNo, EntityID, EntityName, out2);

            return (bool)out2.Value;
        }

        public bool CheckDuplicateEntityName(CRUDContext context, string EntityTitle, int EntityID, string EntityName)
        {
            _context = context;
            var out2 = new SqlParameter
            {
                ParameterName = "p3",
                DbType = System.Data.DbType.Boolean,
                Direction = System.Data.ParameterDirection.Output
            };

            var sql = "exec usp_CheckDuplicateEntityName @p0, @p1, @p2, @p3 OUT";
            var result = _context.Database.ExecuteSqlCommand(sql, EntityTitle, EntityID, EntityName, out2);

            return (bool)out2.Value;
        }
    }
}
