using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.Business.Interfaces
{
    public interface IAppUserService
    {
        List<AppUser> GetMembers(out int totalPage, string searchKey, int activePage);
        List<AppUser> GetMembers();
        public List<DualHelper> GetTopTaskCompletionPersonnels();
        public List<DualHelper> GetTopActivePersonnels();
    }
}
