using Chat.Domain.Common.Interfaces;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Chat.Infra.Data.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ChatDbContext _dbContext;

        public UnitOfWork(ChatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Commit()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
