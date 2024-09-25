
using SuperShop.Prism.Helpers;
using SuperShop.Prism.Interface;
using System;
using System.Globalization;
using System.Threading;
using Xamarin.Forms;


[assembly: Dependency(typeof(SuperShop.Prism.Droid.Implementations.Localize))]
namespace SuperShop.Prism.Droid.Implementations
{
    public class Localize : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            string netLanguage = "en";
            Java.Util.Locale androidLocale = Java.Util.Locale.Default;
            netLanguage = AndroidToDotnetlanguage(androidLocale.ToString().Replace("_", "-"));
            CultureInfo ci = null;

            try
            {
                ci = new CultureInfo(netLanguage);

            }
            catch (CultureNotFoundException)
            {

                try
                {
                    string fallback = ToDotnetFallbackLanguage(new PlatformCulture(netLanguage));
                    ci = new CultureInfo(fallback);
                }
                catch (Exception)
                {

                    ci = new CultureInfo("en");
                }
            }

            return ci;

        }



        public void SetLocale(CultureInfo ci)
        {
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        private string AndroidToDotnetlanguage(string androidLanguage)
        {
            string netLanguage = androidLanguage;

            switch (androidLanguage)
            {
                case "ms-BN":
                case "ms-MY":
                case "ms-SG":
                    netLanguage = "ms";
                    break;

                case "in.ID":
                    netLanguage = "id-ID";
                    break;
                case "gsw-CH":
                    netLanguage = "de-CH";
                    break;


                default:
                    break;
            }
            return netLanguage;
        }

        private string ToDotnetFallbackLanguage(PlatformCulture platformCulture)
        {
            string netLanguage = platformCulture.LanguageCode;

            switch (platformCulture.LanguageCode)
            {
                case "pt":
                    netLanguage = "pt-PT";
                    break;

                case "gsw":
                    netLanguage = "de-CH";
                    break;
            }
            return netLanguage;
        }


    }
}