using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HDQueue.App_Start
{
    using Autofac;
    using Autofac.Integration.Mvc;
    using HDQueue.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    namespace HelpDeskTicketHandler.App_Start
    {
        public class ContainerConfig
        {
            internal static void ResolveDependencies()
            {
                var builder = new ContainerBuilder();
                builder.RegisterControllers(typeof(MvcApplication).Assembly);

                builder.RegisterType<ITicketServiceEF>().As<ITicketService>().InstancePerRequest();
                builder.RegisterType<ApplicationDbContext>().InstancePerRequest();

                var container = builder.Build();

                DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            }
        }
    }
}