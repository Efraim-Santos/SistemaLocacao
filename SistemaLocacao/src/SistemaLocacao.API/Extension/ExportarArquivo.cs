using OfficeOpenXml;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.IO;

namespace SistemaLocacao.API.Extension
{
    public static class ExportarArquivo
    {
        public static (MemoryStream stream, string caminho, string nome) Exportar<TviewModel>(IEnumerable<TviewModel> model, string nome) where TviewModel : class
        {
            var stream = new MemoryStream();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Relatorio_SistemaLocacao");
                workSheet.Cells.LoadFromCollection(model, true, TableStyles.Light1);
                package.Save();
            }
            stream.Position = 0;
            string excelName = $"{nome}-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";

           return (stream, "application/octet-stream", excelName);
        }
    }
}
