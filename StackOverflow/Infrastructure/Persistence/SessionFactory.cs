using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using System;
using FluentNHibernate.Automapping;
using Mediporta.TagChecker.StackOverflow.Infrastructure.Persistence.DataModel;

namespace Mediporta.TagChecker.StackOverflow.Infrastructure.Persistence
{
    public static class SessionFactory
    {
        public static ISession Session(bool createDb = false)
        {
            var mySql = "server=localhost;User Id=root; password=Password; database=Mediporta;";

            Action<NHibernate.Cfg.Configuration> shemaConfig = (cfg) => 
            { 
                if (createDb) new SchemaExport(cfg).Create(true, createDb); 
                new SchemaUpdate(cfg).Execute(true, true); 
            };

            return Fluently.Configure()
                .Database(MySQLConfiguration.Standard.ConnectionString(mySql).ShowSql())
                .Mappings(m => m.AutoMappings.Add(AutoMap.AssemblyOf<TagData>(new AutomappingConfiguration())))
                .ExposeConfiguration(shemaConfig)
                .BuildSessionFactory()
                .OpenSession();
        }
    }
}
