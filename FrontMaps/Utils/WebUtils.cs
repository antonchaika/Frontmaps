using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Web.Handlers;

namespace FrontMaps.Utils
{
    public static class WebUtils
    {
        private static MethodInfo _getWebResourceUrlMethod;
        private static object _getWebResourceUrlLock = new object();

        public static string GetWebResourceUrl<T>(string resourceName)
        {
            if (string.IsNullOrEmpty(resourceName))
            {
                throw new ArgumentNullException("resourceName");
            }

            if (_getWebResourceUrlMethod == null)
            {
                lock (_getWebResourceUrlLock)
                {
                    if (_getWebResourceUrlMethod == null)
                    {
                        var methods = typeof(AssemblyResourceLoader).GetMember("GetWebResourceUrlInternal", BindingFlags.NonPublic | BindingFlags.Static).ToList();
                        foreach (var methodCandidate in methods)
                        {
                            var method = methodCandidate as MethodInfo;
                            if (method == null || method.GetParameters().Length != 5) continue;

                            _getWebResourceUrlMethod = method;
                            break;
                        }
                    }
                }
            }

            return (string)_getWebResourceUrlMethod.Invoke(null,
                new object[] { Assembly.GetAssembly(typeof(T)), resourceName, false, false, null });
        }
    }
}
