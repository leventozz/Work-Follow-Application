using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.Business.Interfaces
{
    public interface IAppUserService
    {
        List<AppUser> GetMembers(string searchKey, int activePage = 1);
        List<AppUser> GetMembers();
    }
}
