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
    }
}
