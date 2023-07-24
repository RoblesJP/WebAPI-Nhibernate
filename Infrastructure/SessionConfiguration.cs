using NHibernate.Mapping.ByCode;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using Domain.Categories;
using Infrastructure.Mappings;
using Microsoft.Extensions.Options;

namespace Infrastructure.Session
{
    public class SessionConfiguration
    {
        public Configuration Configuration { get; }
        public ISessionFactory SessionFactory { get; }
        private ConnectionStringsOptions _connectionStringsOptions;

        public SessionConfiguration(IOptions<ConnectionStringsOptions> options)
        {
            _connectionStringsOptions = options.Value;

            ModelMapper mapper = new ModelMapper();
            mapper.AddMapping<CategoryMap>();
            var domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            Configuration = new Configuration();
            Configuration.DataBaseIntegration(db =>
            {
                db.ConnectionString = _connectionStringsOptions.Supabase;
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

    public class ConnectionStringsOptions
    {
        public const string Section = "ConnectionStrings";

        public string Supabase { get; set; } = String.Empty;
    }
}