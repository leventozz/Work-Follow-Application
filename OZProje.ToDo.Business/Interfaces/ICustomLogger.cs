using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.Business.Interfaces
{
    public interface ICustomLogger
    {
        public void AddErrorLog(string message);
    }
}
