using System;
using System.Linq;

namespace EnumValidator
{
    public static class EnumValidator
    {
        /// <summary>
        /// Verification of enum if it contains defined value. Also works on flags enum.
        /// </summary>
        /// <param name="enum"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool IsValueDefined<TEnum>(this TEnum @enum) where TEnum : Enum
        {
            var enumType = typeof(TEnum);
            if (!enumType.IsEnum)
                throw new ArgumentException("TEnum must be an enum parameter");
            
            if (enumType.GetCustomAttributes(true).OfType<Attribute>().Any(i => i.GetType() == typeof(FlagsAttribute)))
            {
                var value = @enum.ToString();
                if (value.Contains(","))
                    return true;
            }

            return @enum.IsDefined();
        }

        private static bool IsDefined<TEnum>(this TEnum @enum) where TEnum : Enum
        {
            return Enum.IsDefined(typeof(TEnum), @enum);
        }
    }
}