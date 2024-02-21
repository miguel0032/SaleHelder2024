
using Presentation.Data;
using SaleHelder.Application.Interfaces.Repositories;
using SaleHelder.Shared.Entities;
using System.Runtime.CompilerServices;

namespace SaleHelder.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Categoria>, ICategoryRepository
    {
        private readonly DataContext _ctx;
        public CategoryRepository(DataContext ctx) : base(ctx) { }
      
    }
}
