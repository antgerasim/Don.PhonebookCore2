using Abp.Application.Navigation;
using Abp.Localization;
using Don.PhonebookCore2.Authorization;

namespace Don.PhonebookCore2.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class PhonebookCore2NavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("Dashboard"),
                        url: "",
                        icon: "home",
                        requiresAuthentication: true
                    )
                ).AddItem( //Menu items below is just for demonstration!
                    new MenuItemDefinition(
                            "Administration",
                            L("Administration"),
                            icon: "build"
                        ).AddItem(
                            new MenuItemDefinition(
                                PageNames.Tenants,
                                L("Tenants"),
                                url: "Tenants",
                                icon: "business",
                                requiredPermissionName: PermissionNames.Pages_Tenants
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                PageNames.Users,
                                L("Users"),
                                url: "Users",
                                icon: "people",
                                requiredPermissionName: PermissionNames.Pages_Users
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                PageNames.Roles,
                                L("Roles"),
                                url: "Roles",
                                icon: "local_offer",
                                requiredPermissionName: PermissionNames.Pages_Roles
                            )
                        )
                        .AddItem(
                            new MenuItemDefinition(
                                PageNames.About,
                                L("About"),
                                url: "About",
                                icon: "info"
                            )
                        )
                        /*  multilevelMenuItems*/
                        .AddItem(
                            new MenuItemDefinition(
                                "PhoneBook",
                                L("PhoneBook"),
                                url: "PhoneBook",
                                icon: "book"
                            )
                        )
                        .AddItem(
                            new MenuItemDefinition(
                                "AspNetZero",
                                new FixedLocalizableString("ASP.NET Zero")
                            ).AddItem(
                                new MenuItemDefinition(
                                    "AspNetZeroHome",
                                    new FixedLocalizableString("Home"),
                                    url: "https://aspnetzero.com?ref=abptmpl"
                                )
                            ).AddItem(
                                new MenuItemDefinition(
                                    "AspNetZeroDescription",
                                    new FixedLocalizableString("Description"),
                                    url: "https://aspnetzero.com/?ref=abptmpl#description"
                                )
                            ).AddItem(
                                new MenuItemDefinition(
                                    "AspNetZeroFeatures",
                                    new FixedLocalizableString("Features"),
                                    url: "https://aspnetzero.com/?ref=abptmpl#features"
                                )
                            ).AddItem(
                                new MenuItemDefinition(
                                    "AspNetZeroPricing",
                                    new FixedLocalizableString("Pricing"),
                                    url: "https://aspnetzero.com/?ref=abptmpl#pricing"
                                )
                            ).AddItem(
                                new MenuItemDefinition(
                                    "AspNetZeroFaq",
                                    new FixedLocalizableString("Faq"),
                                    url: "https://aspnetzero.com/Faq?ref=abptmpl"
                                )
                            ).AddItem(
                                new MenuItemDefinition(
                                    "AspNetZeroDocuments",
                                    new FixedLocalizableString("Documents"),
                                    url: "https://aspnetzero.com/Documents?ref=abptmpl"
                                )
                            )
                        )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PhonebookCore2Consts.LocalizationSourceName);
        }
    }
}