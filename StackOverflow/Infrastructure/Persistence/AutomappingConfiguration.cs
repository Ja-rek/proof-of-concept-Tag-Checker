using FluentNHibernate;
using FluentNHibernate.Automapping;

namespace Mediporta.StackOverflow.Infrastructure.Persistence
{
    public class AutomappingConfiguration : DefaultAutomappingConfiguration 
    {
        public override bool ShouldMap(System.Type type)
        {
            return type.Namespace.EndsWith("DataModel");
        }
    }
}
