using System.Threading.Tasks;

namespace Booking.Repositories
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}