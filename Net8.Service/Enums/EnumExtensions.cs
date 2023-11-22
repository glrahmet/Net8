using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Net8.Service.Enums
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            string displayName = string.Empty;
            try
            {
                if (enumValue == null)
                    return displayName;
                displayName = enumValue.GetType()
                    .GetMember(enumValue.ToString())
                    .FirstOrDefault()
                    .GetCustomAttribute<DisplayAttribute>()?
                    .GetName();
                if (String.IsNullOrEmpty(displayName))
                {
                    displayName = enumValue.ToString();
                }
            }
            catch
            {

            }
            return displayName;
        }
    }
}
