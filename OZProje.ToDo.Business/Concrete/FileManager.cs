using FastMember;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using OZProje.ToDo.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace OZProje.ToDo.Business.Concrete
{
    public class FileManager : IFileService
    {
        public byte[] ExcelExport<T>(List<T> list) where T : class, new()
        {
            var excelPackage = new ExcelPackage();
            var excelBlank = excelPackage.Workbook.Worksheets.Add("Calisma1");
            excelBlank.Cells["A1"].LoadFromCollection(list, true, OfficeOpenXml.Table.TableStyles.Light15);
            return excelPackage.GetAsByteArray();
        }

        public string PdfExport<T>(List<T> list) where T : class, new()
        {
            DataTable dataTable = new DataTable();
            dataTable.Load(ObjectReader.Create(list));

            var fileName = Guid.NewGuid() + ".pdf";
            var returnPath = "/documents/"+fileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/documents/"+fileName);

            var stream = new FileStream(path, FileMode.Create);

            string arialTTf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
            BaseFont bf = BaseFont.CreateFont(arialTTf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font font = new Font(bf, 12, Font.NORMAL);

            Document document = new Document(PageSize.A4, 25f, 25f, 25f, 25f);
            PdfWriter.GetInstance(document, stream);
            document.Open();

            PdfPTable pdfPTable = new PdfPTable(dataTable.Columns.Count);

            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                pdfPTable.AddCell(new Phrase(dataTable.Columns[i].ColumnName,font));
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    pdfPTable.AddCell(new Phrase(dataTable.Rows[i][j].ToString(),font));
                }
            }
            document.Add(pdfPTable);

            document.Close();

            return returnPath;
        }
    }
}
