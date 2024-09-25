using Foundation;
using SuperShop.Prism.Helpers;
using SuperShop.Prism.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;
using System.Text;
using System.Threading;
using UIKit;

[assembly: Dependency(typeof(SuperShop.Prism.iOS.Implementations.Localize))]
namespace SuperShop.Prism.iOS.Implementations
{
    public class Localize : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            string netLanguage = "en";
            if (NSLocale.PreferredLanguages.Length > 0)
            {
                string pref = NSLocale.PreferredLanguages[0];
                netLanguage = iOSToDotnetLanguage(pref);
            }

            CultureInfo ci = null;

            try
            {
                ci = new System.Globalization.CultureInfo(netLanguage);

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

        private string iOSToDotnetLanguage(string iOSLanguage)
        {
            string netLanguage = iOSLanguage;

            switch (iOSLanguage)
            {
                case "ms-MY":
                case "ms-SG":
                    netLanguage = "ms";
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