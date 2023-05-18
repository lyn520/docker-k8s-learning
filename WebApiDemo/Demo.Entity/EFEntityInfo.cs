using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Entity
{
    public class EFEntityInfo
    {
        public (Assembly Assembly, IEnumerable<Type> Types) EFEntitiesInfo
        {
            get
            {
                return (GetType().Assembly, GetEntityTypes(GetType().Assembly));
            }
        }

        private IEnumerable<Type> GetEntityTypes(Assembly assembly)
        {
            //获取当前程序集下所有的实现了IEFEntity的实体类
            var efEntities = assembly.GetTypes().Where(m => m.FullName != null
                                                            && Array.Exists(m.GetInterfaces(), t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEFEntity<>))
                                                            && !m.IsAbstract && !m.IsInterface).ToArray();

            return efEntities;
        }
    }

}
