using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
//using Ninject.Web.Common;
//using DistributedPartlyCloudDatabase.BLL.Interface.Services;
//using DistributedPartlyCloudDatabase.BLL.Services;
using DistributedPartlyCloudDatabase.DependencyResolver;

namespace DistributedPartlyCloudDatabase.Web.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            kernel.ConfigurateResolverWeb();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        //private void AddBindings()
        //{
        //    kernel.Bind<IUserService>().To<UserService>();
        //    kernel.Bind<IRoleService>().To<RoleService>();
        //}
    }
}