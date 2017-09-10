using System.Reflection;
using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Don.PhonebookCore2.Localization
{
    public static class PhonebookCore2LocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(PhonebookCore2Consts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(PhonebookCore2LocalizationConfigurer).GetAssembly(),
                        "Don.PhonebookCore2.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}