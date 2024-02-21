

using Presentation.Data;
using SaleHelder.Application.Interfaces.Repositories;
using SaleHelder.Shared.Entities;

namespace SaleHelder.Infrastructure.Repositories
{
    public class FaqRepository : GenericRepository<FaQ>, IFaqRepository
    {
        private readonly DataContext _ctx;

        public FaqRepository(DataContext ctx) : base(ctx) 
        {

        }
    }
}
