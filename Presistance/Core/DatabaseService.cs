using Application.Interfaces;
using Presistence.Core;

namespace Presistance.Core
{
    public class DatabaseService : IDatabaseService
    {
        private string connectionString;
        private IServiceProvider provider;
        AppDbContext context;
        public DatabaseService(AppDbContext context, IServiceProvider provider, IDatabaseServiceOptions options)
        {
            this.provider = provider;
            this.connectionString = options.ConnectionString;
            this.context = context;
        }

        void IDatabaseService.SaveChanges()
        {
            this.context.SaveChanges();
        }

        async Task IDatabaseService.SaveChangesAsync()
        {
            await this.context.SaveChangesAsync();
        }

        public virtual bool ExecuteTransaction(Action transactionBody)
        {
            using (var trans = this.context.Database.BeginTransaction())
            {
                try
                {
                    transactionBody.Invoke();
                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
        }
    }
}