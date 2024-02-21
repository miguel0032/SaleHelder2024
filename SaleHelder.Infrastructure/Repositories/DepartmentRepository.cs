

using Presentation.Data;
using SaleHelder.Application.Interfaces.Repositories;
using SaleHelder.Shared.Entities;

namespace SaleHelder.Infrastructure.Repositories
{
    public class DepartmentRepository : GenericRepository<Departamento>, IDepartmentRepository
    {
        private readonly DataContext _ctx;
        public DepartmentRepository(DataContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
