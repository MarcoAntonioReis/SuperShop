using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace SuperShop.Prism.Helpers
{
    public class PlatformCulture
    {
        public string PlatformString { get; private set; }

        public string LanguageCode { get; private set; }

        public string LocaleCode { get; private set; }

        public PlatformCulture(string platformCultureString)
        {
            if (string.IsNullOrEmpty(platformCultureString))
            {
                throw new ArgumentException("Expected culture identifier", "platformCultureString");
            }

            PlatformString = platformCultureString.Replace("_", "-");
            int dashIndex = PlatformString.IndexOf('-');
            if (dashIndex > 0)
            {
                string[] parts = platformCultureString.Split('-');
                LanguageCode = parts[0];
                LocaleCode = parts[1];
            }
            else
            {
                LanguageCode = PlatformString;
                LocaleCode = "";
            }

        }

        public override string ToString()
        {
            return PlatformString;

        }

    }
}
