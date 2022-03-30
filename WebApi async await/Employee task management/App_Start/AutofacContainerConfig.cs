using Autofac;
using Autofac.Integration.WebApi;
using EmployeeManagement.Repository;
using EmployeeManagement.Repository.Common;
using EmployeeManagement.Service;
using EmployeeManagement.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace Employee_task_management.App_Start
{
    public class AutofacContainerConfig
    {
        public static void ConfigureAutofac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<EmployeeService>().As<IEmployeeService>();
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>();
            builder.RegisterType<TaskService>().As<ITaskService>();
            builder.RegisterType<TaskRepository>().As<ITaskRepository>();
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver; 

        }
    }
}