using ClosedXML.Excel;
using System;

namespace WpfApp1
{
    public static class XLSFile
    {
       public static bool Save()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet1 = workbook.Worksheets.Add("Arkusz 1");
                var products = Products.Products_list;

                worksheet1.Cell(1, 1).Value = "id";
                worksheet1.Cell(1, 2).Value = "nazwa";
                worksheet1.Cell(1, 3).Value = "dlugi_opis";
                worksheet1.Cell(1, 4).Value = "waga";
                worksheet1.Cell(1, 5).Value = "kod";
                worksheet1.Cell(1, 6).Value = "ean";
                worksheet1.Cell(1,7).Value= "status";
                worksheet1.Cell(1, 8).Value = "typ";
                worksheet1.Cell(1, 9).Value = "cena_zewnetrzna_hurt";
                worksheet1.Cell(1, 10).Value = "cena_zewnetrzna";
                worksheet1.Cell(1, 11).Value = "vat";
                worksheet1.Cell(1, 12).Value = "ilosc_wariantow";
                worksheet1.Cell(1, 13).Value = "ilosc_zdjec";
                worksheet1.Cell(1, 14).Value = "marża";


                var worksheet2 = workbook.Worksheets.Add("Arkusz 2");
                worksheet2.Cell(1, 1).Value = "id";
                worksheet2.Cell(1, 2).Value = "zdjecia";

                int i = 0;
                int j = 0;
                foreach (var product in products)
                {
                    worksheet1.Cell(i + 2, 1).Value = product.Id;
                    worksheet1.Cell(i + 2, 2).Value = product.Nazwa;
                    worksheet1.Cell(i + 2, 3).Value = product.Dlugi_opis;
                    worksheet1.Cell(i + 2, 4).Value = product.Waga;
                    worksheet1.Cell(i + 2, 5).Value = product.Kod;
                    worksheet1.Cell(i + 2, 6).Value = product.Ean;
                    worksheet1.Cell(i + 2, 7).Value = product.Status;
                    worksheet1.Cell(i + 2, 8).Value = product.Typ;
                    worksheet1.Cell(i + 2, 9).Value = product.Cena_zewnetrzna_hurt;
                    worksheet1.Cell(i + 2, 10).Value = product.Cena_zewnetrzna;
                    worksheet1.Cell(i + 2, 11).Value = product.Vat;
                    worksheet1.Cell(i + 2, 12).Value = product.Ilosc_wariantow;
                    worksheet1.Cell(i + 2, 13).Value = product.Ilosc_zdjec;
                    worksheet1.Cell(i + 2, 14).FormulaA1 = $"=({worksheet1.Cell(i+2,10).Address}/{worksheet1.Cell(i + 2, 9).Address})-1";
                    worksheet1.Cell(i+2,14).Style.NumberFormat.Format = "0.0%"; 


                    if (product.Ilosc_zdjec > 0)
                    {
                        foreach (var zdjecie in product.Zdjecia)
                        {
                            worksheet2.Cell(j + 2, 1).Value = product.Id;
                            worksheet2.Cell(j + 2, 2).Value = zdjecie;
                            j++;
                        }

                    }
                    if (product.Ilosc_zdjec < 2)
                    {
                        worksheet1.Row(i + 2).Style.Fill.BackgroundColor = XLColor.Red;
                    }
                    if (((double)worksheet1.Cell(i + 2, 10).Value/ (double)worksheet1.Cell(i + 2, 9).Value)-1 < 0.2){
                        worksheet1.Row(i + 2).Style.Fill.BackgroundColor = XLColor.Orange;
                    }
                    i++;
                }
                try
                {
                    workbook.SaveAs("PlikExcelowy.xlsx");
                    return true;
                }
                catch (Exception) { return false; }
            }
        }
    }
}
