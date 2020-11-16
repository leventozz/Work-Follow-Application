using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.DataAccess.Interfaces
{
    public interface IAppUserDAL 
    {
        List<AppUser> GetMembers();
        List<AppUser> GetMembers(out int totalPage, string searchKey, int activePage = 1);
        public List<DualHelper> GetTopTaskCompletionPersonnels();
        public List<DualHelper> GetTopActivePersonnels();
    }
}
