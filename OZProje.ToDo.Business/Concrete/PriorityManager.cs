using OZProje.ToDo.Business.Interfaces;
using OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using OZProje.ToDo.DataAccess.Interfaces;
using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.Business.Concrete
{
    public class PriorityManager : IPriorityService
    {
        private readonly IPriorityDAL _priorityDAL;
        public PriorityManager(IPriorityDAL priorityDAL)
        {
            _priorityDAL = priorityDAL;
        }
        public void Delete(Priority table)
        {
            _priorityDAL.Delete(table);
        }

        public List<Priority> GetAll()
        {
            return _priorityDAL.GetAll();
        }

        public Priority GetById(int id)
        {
            return _priorityDAL.GetById(id);
        }

        public void Save(Priority table)
        {
            _priorityDAL.Save(table);
        }

        public void Update(Priority table)
        {
            _priorityDAL.Update(table);
        }
    }
}
