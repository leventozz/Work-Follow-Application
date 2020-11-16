using OZProje.ToDo.Entities.Concrete;

namespace OZProje.ToDo.DataAccess.Interfaces
{
    public interface IReportDAL : IGenericDAL<Report>
    {
        Report GetWithAllies(int id);
        int GetReportsCount(int userId);
        int GetAllReportsCount();
    }
}
