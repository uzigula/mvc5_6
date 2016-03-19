using System.Configuration;

namespace VirtualOffice.Web.Filters.Auth.Configuration
{
    public class ControllerAuthorizationConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("controller", IsRequired = true)]
        public string Controller
        {
            get
            {
                return (string)this["controller"];
            }
            set
            {
                this["controller"] = value;
            }
        }

        [ConfigurationProperty("roles", IsRequired = false)]
        public string Roles
        {
            get
            {
                return (string)this["roles"];
            }
            set
            {
                this["roles"] = value;
            }
        }

        [ConfigurationProperty("actionAuthorizationMappings")]
        public ActionAuthorizationConfigurationCollection ActionAuthorizationMappings
        {
            get
            {
                return this["actionAuthorizationMappings"] as ActionAuthorizationConfigurationCollection;
            }
        }
    }
}