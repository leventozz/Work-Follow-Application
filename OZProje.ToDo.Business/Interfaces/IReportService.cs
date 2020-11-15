using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.Business.Interfaces
{
    public interface IReportService : IGenericService<Report>
    {
        Report GetWithAllies(int id);
        int GetReportsCount(int userId);
    }
}
