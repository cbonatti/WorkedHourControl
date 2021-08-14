using System;
using System.ComponentModel;
using System.Linq;

namespace WorkedHourControl.Application.Utils
{
    public static class EnumerationExtension
    {
        public static string Description(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attr = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attr.Any() ? ((DescriptionAttribute)attr.ElementAt(0)).Description : string.Empty;
        }
    }
}
