using SuperShop.Prism.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SuperShop.Prism.Helpers
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        private readonly CultureInfo ci;
        private const string ResourceId = "SuperShop.Prism.Resources.Resource";
        private static readonly Lazy<ResourceManager> ResMgr =
            new Lazy<ResourceManager>(() => new ResourceManager(
                ResourceId,
                typeof(TranslateExtension).GetTypeInfo().Assembly));


        public string Text { get; set; }

        public TranslateExtension()
        {
            ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
            {
                return "";
            }

            string translation = ResMgr.Value.GetString(Text, ci);

            if (translation == null)
            {
                throw new ArgumentException(
                    string.Format(
                      "Key '{0}' was not found in resources '{1}' for culture '{2}'.",
                      Text, ResourceId, ci.Name), "Text"
                    );
            }
            return translation;

        }
    }
}
