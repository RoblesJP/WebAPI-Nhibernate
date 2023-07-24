using NHibernate.Mapping.ByCode;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using Domain.Categories;
using Infrastructure.Mappings;

namespace Infrastructure.Session
{
    public class SessionConfiguration
    {
        public Configuration Configuration { get; }
        public ISessionFactory SessionFactory { get; }

        public SessionConfiguration()
        {
            ModelMapper mapper = new ModelMapper();
            mapper.AddMapping<CategoryMap>();
            var domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            Configuration = new Configuration();
            Configuration.DataBaseIntegration(db =>
            {
                db.ConnectionString = @"User Id=postgres;Password=tTclAc4Yp4aiX3W2;Server=db.fviojeyqghomrbvdfcnp.supabase.co;Port=5432;Database=postgres";
                db.Dialect<PostgreSQLDialect>();
                db.Driver<NpgsqlDriver>();
            });
            Configuration.AddMapping(domainMapping);
            Configuration.SessionFactory().GenerateStatistics();

            SessionFactory = Configuration.BuildSessionFactory();
        }

        public ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}