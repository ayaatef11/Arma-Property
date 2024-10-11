using System.Threading.Tasks;

namespace MyBookStore.Data;
// It is used to ensure that the schema of the
// database is up-to-date when the application is deployed, 
public interface IArmaPropertyDbSchemaMigrator
{
    Task MigrateAsync();
}
