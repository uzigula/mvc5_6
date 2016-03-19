using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace VirtualOffice.Web.Filters.Auth.Configuration
{
    public class ActionAuthorizationConfigurationCollection : ConfigurationElementCollection, IEnumerable<ActionAuthorizationConfigurationElement>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public ActionAuthorizationConfigurationElement this[int index]
        {
            get
            {
                return base.BaseGet(index) as ActionAuthorizationConfigurationElement;
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

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<ActionAuthorizationConfigurationElement> Elements
        {
            get
            {
                for (int i = 0; i < base.Count; ++i)
                {
                    yield return this[i];
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public new IEnumerator<ActionAuthorizationConfigurationElement> GetEnumerator()
        {
            for (int i = 0; i < base.Count; ++i)
            {
                yield return this[i];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new ActionAuthorizationConfigurationElement();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ActionAuthorizationConfigurationElement)element).Action;
        }
    }
}