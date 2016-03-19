using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace VirtualOffice.Web.Filters.Auth.Configuration
{
    public class ControllerAuthorizationConfigurationCollection : ConfigurationElementCollection, IEnumerable<ControllerAuthorizationConfigurationElement>
    {
   
        public ControllerAuthorizationConfigurationElement this[int index]
        {
            get
            {
                return base.BaseGet(index) as ControllerAuthorizationConfigurationElement;
            }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        public IEnumerable<ControllerAuthorizationConfigurationElement> Elements
        {
            get
            {
                for (int i = 0; i < base.Count; ++i)
                {
                    yield return this[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public new IEnumerator<ControllerAuthorizationConfigurationElement> GetEnumerator()
        {
            for (int i = 0; i < base.Count; ++i)
            {
                yield return this[i];
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ControllerAuthorizationConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ControllerAuthorizationConfigurationElement)element).Controller;
        }
    }
}