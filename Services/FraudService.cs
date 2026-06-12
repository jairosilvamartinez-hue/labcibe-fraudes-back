using System.Collections.Generic;
using System.Threading.Tasks;
using HackerRank1.Entities;
using LibraryService.WebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace HackerRank1.Services
{
    public class FraudService : IFraudService
    {
        private readonly LibraryContext _context;

        public FraudService(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Fraud> CreateFraudAsync(Fraud fraud)
        {
            fraud.CreatedAt = DateTime.UtcNow;
            _context.Frauds.Add(fraud);
            await _context.SaveChangesAsync();
            return fraud;
        }

        public async Task<IEnumerable<Fraud>> GetAllFraudsAsync()
        {
            return await _context.Frauds.ToListAsync();
        }
    }
}