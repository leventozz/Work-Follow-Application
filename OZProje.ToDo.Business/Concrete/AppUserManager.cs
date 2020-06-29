using OZProje.ToDo.Business.Interfaces;
using OZProje.ToDo.DataAccess.Interfaces;
using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.Business.Concrete
{
    public class AppUserManager : IAppUserService
    {
        IAppUserDAL _appUserDAL;
        public AppUserManager(IAppUserDAL appUserDAL)
        {
            _appUserDAL = appUserDAL;
        }
        public List<AppUser> GetMembers()
        {
            return _appUserDAL.GetMembers();
        }

        public List<AppUser> GetMembers(out int totalPage,string searchKey, int activePage)
        {
            return _appUserDAL.GetMembers(out totalPage, searchKey, activePage);
        }
    }
}
