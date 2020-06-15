using System.Threading.Tasks;

namespace Chat.Domain.Common.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
