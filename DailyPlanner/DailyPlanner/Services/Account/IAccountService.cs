using System.Threading.Tasks;

namespace DailyPlanner
{
    public interface IAccountService
    {
        Task<bool> LogAsync(string username, string password);
    }
}
