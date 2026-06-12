using System.Collections.Generic;
using System.Threading.Tasks;
using HackerRank1.Entities;

namespace HackerRank1.Services
{
    public interface IFraudService
    {
        Task<Fraud> CreateFraudAsync(Fraud fraud);
        Task<IEnumerable<Fraud>> GetAllFraudsAsync();
    }
}
