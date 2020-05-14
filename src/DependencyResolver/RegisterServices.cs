using System;
using DocManager.Business.Contract.Documents.Services;
using DocManager.Business.Contract.Users.Models;
using DocManager.Business.Contract.Users.Services;
using DocManager.Business.Documents.Services;
using DocManager.Business.Users.Services;
using Microsoft.AspNet.Identity;
using Ninject;
using Ninject.Web.Common;
using Repository.Contexts;
using Repository.Contract.Repositories;
using Repository.Repositories;

namespace DependencyResolver
{
    public static class RegisterServices
    {
        public static void Register(IKernel kernel)
        {
            kernel.Bind<DocManagerDbContext>().ToSelf().InRequestScope();

            kernel.Bind<UserManager<ProfileUser, Guid>>().To<UserManager>().InThreadScope();
            kernel.Bind<IUserPasswordStore<ProfileUser, Guid>, IUserStore<ProfileUser, Guid>>().To<UserService>().InRequestScope();
            kernel.Bind<IUserRetrievingService>().To<UserService>().InRequestScope();
            kernel.Bind<IDocumentService>().To<DocumentService>().InRequestScope();

            kernel.Bind<IUserRepository>().To<UserRepository>().InRequestScope();
            kernel.Bind<IStatusRepository>().To<StatusRepository>().InRequestScope();
            kernel.Bind<IDocumentRepository>().To<DocumentRepository>().InRequestScope();
            kernel.Bind<IDocumentVersionRepository>().To<DocumentVersionRepository>().InRequestScope();
            kernel.Bind<IFileBlobRepository>().To<FileBlobRepository>().InRequestScope();
            kernel.Bind<IWorkingPositionRepository>().To<WorkingPositionRepository>().InRequestScope();
        }
    }
}
