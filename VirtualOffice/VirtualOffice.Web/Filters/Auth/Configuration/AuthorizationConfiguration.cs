using System.Configuration;

namespace VirtualOffice.Web.Filters.Auth.Configuration
{

    public class AuthorizationConfiguration : ConfigurationSection
    {
        private static AuthorizationConfiguration _authorizationConfiguration
            = ConfigurationManager.GetSection("authorizationConfiguration") as AuthorizationConfiguration;

        public static AuthorizationConfiguration Section
        {
            get
            {
                return _authorizationConfiguration;
            }
        }

        [ConfigurationProperty("controllerAuthorizationMappings")]
        public ControllerAuthorizationConfigurationCollection ControllerAuthorizationMappings
        {
            get
            {
                return this["controllerAuthorizationMappings"] as ControllerAuthorizationConfigurationCollection;
            }
        }
    }
}