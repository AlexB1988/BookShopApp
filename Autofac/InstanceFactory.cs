using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Autofac
{
    internal class InstanceFactory
    {
        public static T GetInstance<T>()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new ServiceModule());
            IContainer Container = builder.Build();
            using (var scope =Container.BeginLifetimeScope())
            {
                return scope.Resolve<T>();
            }
        }
    }
}
