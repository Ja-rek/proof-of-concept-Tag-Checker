using Autofac;
using Mediporta.TagChecker.StackOverflow.Application.Tags;
using Mediporta.TagChecker.StackOverflow.Infrastructure.Persistence;
using Mediporta.TagChecker.StackOverflow.Infrastructure.Tags.ACL;
using Mediporta.TagChecker.StackOverflow.Infrastructure.Tags.Storage;
using NHibernate;
using RestSharp;

namespace Mediporta.TagChecker.StackOverflow.Infrastructure.ContainerIOC
{
    public class StackOverflowIOC : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TagAdapter>().AsSelf();
            builder.RegisterType<TagService>().As<ITagService>();
            builder.RegisterType<TagStorageService>().As<ITagStorageService>();
            builder.RegisterType<TagApplicationService>().AsSelf();
            builder.RegisterType<TagQueryService>().AsSelf();
            builder.Register(c => new RestClient("http://api.stackexchange.com/2.2")).AsSelf();
            builder.Register(c => SessionFactory.Session()).As<ISession>().InstancePerDependency();
        }
    }
}
