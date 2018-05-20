using DistributedPartlyCloudDatabase.BLL.Interface.Services;
using DistributedPartlyCloudDatabase.BLL.Services;
using DistributedPartlyCloudDatabase.DAL.Interface;
using DistributedPartlyCloudDatabase.DAL.Interface.DTO;
using DistributedPartlyCloudDatabase.DAL.Interface.Repositories;
using DistributedPartlyCloudDatabase.DAL.Repositories;
using DistributedPartlyCloudDatabase.ORM;
using Ninject;
using Ninject.Activation;
using Ninject.Web.Common;
using System;
using System.Data.Entity;
using System.Linq;
using Ninject.Planning.Bindings;
using DistributedPartlyCloudDatabase.DAL;

namespace DistributedPartlyCloudDatabase.DependencyResolver
{
    public static class ResolverModule
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            Configure(kernel, true);
        }

        public static void ConfigurateResolverConsole(this IKernel kernel)
        {
            Configure(kernel, false);
        }

        private static void Configure(IKernel kernel, bool isWeb)
        {
            if (isWeb)
            {
                kernel.Bind(typeof(IUnitOfWork<>)).To(typeof(UnitOfWork<>)).InRequestScope();

                //kernel
                //    .Bind<DbContext>()
                //    .To<EntityModel>()
                //    .InRequestScope()
                //    .WithMetadata("CloudConnection", false);

                //kernel
                //    .Bind<DbContext>()
                //    .To<AzureEntityModel>()
                //    .InRequestScope()
                //    .WithMetadata("CloudConnection", true); 


                //kernel
                //    .Bind<DbContext>()
                //    .To<EntityModel>()                   
                //    .InRequestScope()
                //    .WithConstructorArgument("connectionString", ConfigurationManager.ConnectionStrings["EntityModel"]
                //    .ConnectionString);

                // kernel
                //.Bind<DbContext>()
                //.To<EntityModel>()
                //.WhenInjectedInto<IRepository<DalRole>>()
                //.InRequestScope();
                // //   .Named("EntityModel");

                // kernel
                //     .Bind<DbContext>()
                //     .To<AzureEntityModel>()
                //      .WhenInjectedInto<IRepository<DalImage>>()
                //     .InRequestScope();
                // .Named("AzureEntityModel");


                //kernel.Bind<DbContext>().To<EntityModel>();
                //kernel.Bind<DbContext>().To<AzureEntityModel>();
                //kernel.Bind<IDbContextFactory>().To<DbContextFactory>().InRequestScope();


                //kernel
                //    .Bind<DbContext>()
                //    .To<EntityModel>()
                //    .Named("EntityModel");
                //   // .InRequestScope();

                //kernel
                //    .Bind<DbContext>()
                //    .To<AzureEntityModel>()
                //   // .InRequestScope()
                //    .Named("AzureEntityModel");
            }
            else
            {
               // kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();

                kernel
                  .Bind<DbContext>()
                  .To<EntityModel>()
                  .InSingletonScope()
                  .Named("EntityModel");

                kernel
                    .Bind<DbContext>()
                    .To<AzureEntityModel>()
                    .InSingletonScope()
                    .Named("AzureEntityModel");

                //kernel
                //  .Bind<DbContext>()
                //  .To<EntityModel>()
                //  .When(t => t.IsInjectingToRepositoryDataSourceOfNamespace("EntityModel"))
                //  .InSingletonScope();

                //kernel
                //    .Bind<DbContext>()
                //    .To<AzureEntityModel>()
                //    .When(t => t.IsInjectingToRepositoryDataSourceOfNamespace("AzureEntityModel"))
                //    .InSingletonScope();

            }

            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<IImageService>().To<ImageService>();

            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();
            kernel.Bind<IImageRepository>().To<ImageRepository>();

            kernel.Bind<IDBOneRepositories>().To<DBOneRepositories>();
            kernel.Bind<IDBTwoRepositories>().To<DBTwoRepositories>();
        }

        public static bool IsInjectingToRepositoryDataSourceOfNamespace(
         this IRequest request, string entityNamespace)
        {
            Type type = request.ParentRequest.ParentRequest.Service.GetType();

            if (type.IsGenericType
                && request.ParentRequest.ParentRequest.Service.GetGenericTypeDefinition() == typeof(IRepository<>))
            {
                return request.ParentRequest.ParentRequest.Service.GetGenericArguments().First().Namespace
                     == entityNamespace;
            }

            return false;
        }

        // will work just as well without this line, but it's more correct and important for IntelliSense etc.
        //[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        //    AllowMultiple = true, Inherited = true)]
        //public class ConnectionHelper : ConstraintAttribute
        //{            
        //    public override bool Matches(IBindingMetadata metadata)
        //    {
        //        return metadata.Has("CloudConnection") && metadata.Get<bool>("CloudConnection");
        //    }
        //}
    }

}
