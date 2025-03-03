using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories
{
    public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
    {
        private readonly CashflowDbContext _context;

        public UserRepository(CashflowDbContext context)
        {
            _context = context;
        }

        public async Task Add(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<bool> ExistActiveUserWithEmail(string email)
        {
            return await _context.Users.AnyAsync(user => user.Email.Equals(email));
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Email.Equals(email));
        }
    }
}
