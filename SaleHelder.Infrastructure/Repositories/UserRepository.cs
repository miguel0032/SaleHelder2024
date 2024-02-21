
using Microsoft.EntityFrameworkCore;
using Presentation.Data;
using SaleHelder.Application.Interfaces.Repositories;
using SaleHelder.Shared.Entities;

namespace SaleHelder.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly DataContext _ctx;
        public UserRepository(DataContext ctx) : base(ctx) 
        {
            _ctx = ctx;
        }
        public override async Task<List<User>> GetAll()
        {
            return await this._ctx.Set<User>().Include(d => d.Departamento).ToListAsync();
        }
        public override async Task<User> GetById(int id)
        {
            return await this._ctx.Set<User>().Include(d => d.Departamento).Where(d => d.UserId == id).FirstAsync();
        }
    }
}
