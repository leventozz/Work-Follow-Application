using OZProje.ToDo.DataAccess.Interfaces;
using OZProje.ToDo.Entities.Concrete;

namespace OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfPriorityRepository : EfGenericRepository<Priority>, IPriorityDAL
    {
    }
}
