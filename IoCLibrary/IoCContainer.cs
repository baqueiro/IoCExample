using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IoCLibrary
{
    public class IoCContainer
    {
        private Dictionary<Type, Type> container { get; set; } = new Dictionary<Type, Type>();

        public void Register<TFrom, TTo>()
        {
            if (!container.ContainsKey(typeof(TFrom)))
            {
                container.Add(typeof(TFrom), typeof(TTo));
            }
            else
            {
                throw new Exception($"{typeof(TFrom).FullName} can't be implemented twice.");
            }
        }

        public T Resolve<T>()
        {
            //var types = AppDomain.CurrentDomain.GetAssemblies().Where(p => !IgnoreSystemAsemblies(p));

            var values = container.Values.ToArray();

            dynamic o = Activator.CreateInstance(values[0]);

            var constructor = typeof(T).GetConstructor(container.Keys.ToArray());

            object i = constructor.Invoke(new object[] { o });

            return (T)i;
        }

        private bool IgnoreSystemAsemblies(Assembly p)
        {
            return p.FullName.Contains("Microsoft.")
                    || p.FullName.Contains("System")
                    || p.FullName.Contains("mscorlib")
                    || p.FullName.Contains("vshost32");
        }

        
    }
}
