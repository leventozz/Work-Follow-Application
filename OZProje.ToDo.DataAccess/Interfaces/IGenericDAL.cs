using OZProje.ToDo.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.DataAccess.Interfaces
{
    public interface IGenericDAL<Table> where Table:class,ITable,new()
    {
        void Save(Table table);
        void Delete(Table table);
        void Update(Table table);
        Table GetById(int id);
        List<Table> GetAll();
    }
}
