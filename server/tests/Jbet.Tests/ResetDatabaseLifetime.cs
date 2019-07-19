using Npgsql;
using Respawn;
using System.Threading.Tasks;
using Xunit;

namespace Jbet.Tests
{
    /// <inheritdoc />
    /// <summary>
    /// Keeps the relational and event store test databases clean.
    /// </summary>
    public class ResetDatabaseLifetime : IAsyncLifetime
    {
        private readonly Checkpoint _relationalCheckpoint;
        private readonly Checkpoint _eventStoreCheckpoint;

        public ResetDatabaseLifetime()
        {
            _relationalCheckpoint = new Checkpoint
            {
                SchemasToInclude = new[]
                {
                    "public"
                },
                DbAdapter = DbAdapter.Postgres
            };

            _eventStoreCheckpoint = new Checkpoint
            {
                SchemasToInclude = new[]
                {
                    "public"
                },
                DbAdapter = DbAdapter.Postgres
            };
        }

        /// <inheritdoc />
        ///  <summary>
        ///  Resets test databases to a clean state.
        ///  </summary>
        ///  <returns>
        ///  A <see cref="T:System.Threading.Tasks.Task" /> representing the asynchronous operation.
        ///  </returns>
        public async Task DisposeAsync()
        {
            await Reset(_relationalCheckpoint, AppFixture.RelationalDbConnectionString);
            await Reset(_eventStoreCheckpoint, AppFixture.EventStoreConnectionString);
        }

        /// <inheritdoc />
        ///  <summary>
        ///   Already completed successfully.
        ///  </summary>
        ///  <returns>
        ///  A <see cref="T:System.Threading.Tasks.Task" /> representing the asynchronous operation.
        ///  </returns>
        public Task InitializeAsync() => Task.CompletedTask;

        private static async Task Reset(Checkpoint checkpoint, string connectionString)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                await checkpoint.Reset(connection);
            }
        }
    }
}