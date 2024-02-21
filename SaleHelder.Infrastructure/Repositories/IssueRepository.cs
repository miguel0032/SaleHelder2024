
using Microsoft.EntityFrameworkCore;
using Presentation.Data;
using SaleHelder.Application.Interfaces.Repositories;
using SaleHelder.Shared.Entities;

namespace SaleHelder.Infrastructure.Repositories
{
    public class IssueRepository : GenericRepository<Issue>, IIssueRepository
    {
        private readonly DataContext _ctx;
        public IssueRepository(DataContext ctx) : base(ctx) 
        {
            _ctx = ctx;
        }

        public override async Task<Issue> GetById(int id)
        {
            return await _ctx.Set<Issue>().Include(p => p.FaQ).Include(p => p.User).Where(i => i.Id == id).FirstAsync();
        }
        public override async Task<List<Issue>> GetAll()
        {
            try
            {

                return await _ctx.Set<Issue>().Include(p => p.FaQ).Include(p => p.User).ToListAsync();

            }
            catch (Exception ex)
            {
                var msj_error = ex.Message;
            }
            return default;
        }
    }
}
