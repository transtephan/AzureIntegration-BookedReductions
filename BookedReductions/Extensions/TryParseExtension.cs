using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureIntegration_BookedReductions.Extensions
{
 
        public static class TryParseExtension
        {
            public static Int32 TryParseInt32(this string value, string defaultValue)
            {
                return TryParse<Int32>(value, Convert.ToInt32(defaultValue), Int32.TryParse);
            }
            public static Decimal TryParseDecimal(this string value, string defaultValue)
            {
                return TryParse<Decimal>(value, Convert.ToDecimal(defaultValue), Decimal.TryParse);
            }
            public static bool TryParseBoolean(this string value, string defaultValue)
            {
                return TryParse<bool>(value, Convert.ToBoolean(defaultValue), bool.TryParse);
            }

            #region Private methods
            private delegate bool ParseDelegate<T>(string s, out T result);
            private static T TryParse<T>(this string value, T defaultValue, ParseDelegate<T> parse) where T : struct
            {
                bool chkParse = parse(value, out T result);
                if (!chkParse)
                {
                    return defaultValue;
                }
                return result;
            }
            #endregion
        }
    }

