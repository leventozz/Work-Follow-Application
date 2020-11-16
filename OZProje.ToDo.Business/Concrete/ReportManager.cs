using OZProje.ToDo.Business.Interfaces;
using OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using OZProje.ToDo.DataAccess.Interfaces;
using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.Business.Concrete
{
    public class ReportManager : IReportService
    {
        private readonly IReportDAL _reportDAL;
        public ReportManager(IReportDAL reportDAL)
        {
            _reportDAL = reportDAL;
        }
        public void Delete(Report table)
        {
            _reportDAL.Delete(table);
        }

        public List<Report> GetAll()
        {
            return _reportDAL.GetAll();
        }

        public int GetAllReportsCount()
        {
            return _reportDAL.GetAllReportsCount();
        }

        public Report GetById(int id)
        {
            return _reportDAL.GetById(id);
        }

        public int GetReportsCount(int userId)
        {
            return _reportDAL.GetReportsCount(userId);
        }

        public Report GetWithAllies(int id)
        {
            return _reportDAL.GetWithAllies(id);
        }

        public void Save(Report table)
        {
            _reportDAL.Save(table);
        }

        public void Update(Report table)
        {
            _reportDAL.Update(table);
        }
    }
}
