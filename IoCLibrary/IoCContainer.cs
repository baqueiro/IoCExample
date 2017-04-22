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
            var constructor = typeof(T).GetConstructor(container.Keys.ToArray());

            var instancesList = container.Values.Select(p => Activator.CreateInstance(p)).ToArray();

            return (T)constructor.Invoke(instancesList);
        }
    }
}
