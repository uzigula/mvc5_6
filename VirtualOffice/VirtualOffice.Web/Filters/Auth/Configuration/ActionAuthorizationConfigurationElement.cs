using System.Configuration;

namespace VirtualOffice.Web.Filters.Auth.Configuration
{

    public class ActionAuthorizationConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("action", IsRequired = true)]
        public string Action
        {
            get
            {
                return (string)this["action"];
            }
            set
            {
                this["action"] = value;
            }
        }

        [ConfigurationProperty("roles", IsRequired = true)]
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
    }
}