using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedSqlServerDependencies.Util
{
    public static class ValueConverter
    {
        public static string ConvertToDynamicSize(float value)
        {
            int unit = 0; // 0 = bytes, 1 = Kb, 2 = Mb, 3 = Gb, etc.
            string unitName;
            while (value > 1024)
            {
                unit++;
                value /= 1024;
            }
            switch (unit)
            {
                case 0: unitName = "B"; break;
                case 1: unitName = "KB"; break;
                case 2: unitName = "MB"; break;
                case 3: unitName = "GB"; break;
                case 4: unitName = "TB"; break;
                case 5: unitName = "PB"; break;
                default: unitName = "ERR"; break;
            };

            return string.Format("{0:n2} {1}", value, unitName);
        }

        public static string ConvertToDynamicSize(long value)
        {
            return ConvertToDynamicSize((float)value);
        }
    }
}
