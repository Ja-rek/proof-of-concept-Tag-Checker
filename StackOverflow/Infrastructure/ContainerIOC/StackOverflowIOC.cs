using Autofac;
using Mediporta.StackOverflow.Application.Tags;
using Mediporta.StackOverflow.Infrastructure.Persistence;
using Mediporta.StackOverflow.Infrastructure.Tags.ACL;
using Mediporta.StackOverflow.Infrastructure.Tags.Storage;
using NHibernate;
using RestSharp;

namespace Mediporta.StackOverflow.Infrastructure.ContainerIOC
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
