using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloMVC.Northwind.Data;
using HelloMVC.Northwind.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml;

namespace HelloMVC.Controllers
{
    public class ReportsController : Controller
    {
        private readonly NorthwindDb db;

        //public ReportsController(NorthwindDb db)
        //{
        //    this.db = db;
        //}
        public ReportsController(NorthwindDb db) => this.db = db;
        

        public IActionResult Index()
        {
            var cats1 = db.Categories.Select(x=>x.CategoryName).ToList();

            var cats2 = db.Categories.Select(x => new
            {
                x.CategoryId,
                x.CategoryName
            }).ToList();
            ViewBag.CategoryList = new SelectList(cats2, "CategoryName","CategoryName");
   
            return View();
        }
        
        public IActionResult SalesByCategory(string c)
        {
            var items = db.sp_SalesByCategory(c).ToList();
            //return Content($"Report for {c}");
            return PartialView(items);
        }

        public async Task<IActionResult> DownloadAsync(string c)
        {
            var items = db.sp_SalesByCategory(c).ToList();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add(c);
                int row = 2;
                ws.Cells["A1"].Value = "Product Name";
                ws.Cells["B1"].Value = "Total Purchase";
                foreach (var item in items)
                {
                    ws.Cells[row, 1].Value = item.ProductName;
                    ws.Cells[row, 2].Value = item.TotalPurchase;
                    row++;
                }
                ws.Cells[row, 2].Formula = $"SUM(B2:B{row - 1})";

                //package.SaveAs(new System.IO.FileInfo("demo.xlsx"));
                var bytes = await package.GetAsByteArrayAsync();
                return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "demo.xlsx");
            }
        }
    }
}
