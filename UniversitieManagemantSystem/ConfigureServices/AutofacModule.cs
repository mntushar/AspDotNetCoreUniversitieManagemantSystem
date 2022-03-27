using Autofac;
using Manager;
using Manager.Contacts;
using Repositories;
using Repositories.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversitieManagemantSystem.ConfigureServices
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // The generic ILogger<TCategoryName> service was added to the ServiceCollection by ASP.NET Core.
            // It was then registered with Autofac using the Populate method. All of this starts
            // with the `UseServiceProviderFactory(new AutofacServiceProviderFactory())` that happens in Program and registers Autofac
            // as the service provider.
            //builder.Register(c => new DepartmentManager(c.Resolve<ILogger<ValuesService>>()))
            
            builder.RegisterType<DepartmentManager>().As<IDepartmentManager>();
            builder.RegisterType<DepartmentRepositorie>().As<IDepartmentRepositorie>();

            builder.RegisterType<StudentManager>().As<IStudentManager>();
            builder.RegisterType<StudentRepositore>().As<IStudentRepositore>();
        }
    }
}
