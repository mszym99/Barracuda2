using Microsoft.Extensions.Options;
using Microsoft.SemanticKernel.Connectors.Postgres;
using Microsoft.SemanticKernel.Memory;
using Npgsql;

namespace Barracuda2.Helpers
{
    public class MemoryStore
    {
        private readonly OpenAIOptions options;

        public MemoryStore(IOptions<OpenAIOptions> optionsAccessor)
        {
            this.options = optionsAccessor.Value;
        }
        public IMemoryStore CreateSamplePostgresMemoryStore()
        {
            NpgsqlDataSourceBuilder dataSourceBuilder = new($"Host=essential-c-sharp-vector-db.postgres.database.azure.com;Port=5432;Database=postgres;Username=essential_c_sharp_admin;Password={options.Password}");
            dataSourceBuilder.UseVector();
            NpgsqlDataSource dataSource = dataSourceBuilder.Build();
            IMemoryStore store = new PostgresMemoryStore(dataSource, vectorSize: 1536, schema: "public");
            return store;
        }
    }
}
