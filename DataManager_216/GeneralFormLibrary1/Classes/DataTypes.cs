using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralFormLibrary1
{
    public class DataTypes
    {
        public static bool TypeCodeIsNumeric(TypeCode type)
        {
            if (type == TypeCode.Byte || type == TypeCode.DateTime || type == TypeCode.Decimal || type == TypeCode.Double ||
                type == TypeCode.Int16 || type == TypeCode.Int32 || type == TypeCode.Int64 || type == TypeCode.SByte ||
                type == TypeCode.Single || type == TypeCode.UInt16 || type == TypeCode.UInt32 || type == TypeCode.UInt64)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string ConvertSqlDataTypeToCSharpDataType(string SqlDataType)
        {
            if(SqlDataType.ToLower() == "int")
            {
                return "int";
            }
            else if (SqlDataType.ToLower() == "date")
            {
                return "DateTime";
            }
            else if (SqlDataType.ToLower() == "datetime")
            {
                return "DateTime";
            }
            else if (SqlDataType.ToLower() == "smalldatetime")
            {
                return "DateTime";
            }
            else if(SqlDataType.ToLower() == "decimal")
            {
                return "decimal";
            }
            else if (SqlDataType.ToLower() == "float")
            {
                return "float";
            }
            else if (SqlDataType.ToLower() == "varchar")
            {
                return "string";
            }
            else if (SqlDataType.ToLower() == "bit")
            {
                return "byte";
            }
            else
            {
                return "Data type not configured!";
            }
        }
    }
}
