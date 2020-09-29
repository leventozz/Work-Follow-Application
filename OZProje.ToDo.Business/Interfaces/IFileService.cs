using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.Business.Interfaces
{
    public interface IFileService
    {
        string PdfExport<T>(List<T> list) where T : class, new();
        byte[] ExcelExport<T>(List<T> list) where T : class, new();
    }
}
