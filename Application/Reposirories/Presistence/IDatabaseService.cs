using System;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDatabaseService
    {
        void SaveChanges();
        Task SaveChangesAsync();
        bool ExecuteTransaction(Action transactionBody);
    }
}