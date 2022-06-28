using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using TelerikMVC.Models;

using System.IO;
using NPOI.XSSF.UserModel;
using System.Web.UI.WebControls;
using System.Data;
using NPOI.SS.UserModel;
using System.Reflection;

namespace TelerikMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult LineChart()
        {
            return View();
        }

        public ActionResult ExportAll()
        {
            return View();
        }

        public ActionResult MenuPage()
        {
            return View();
        }

        public ActionResult ExportAllGeneric()
        {
            return View();
        }

        public ActionResult DBData()
        {
            return View();
        }


        public ActionResult Select([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                //var data = Enumerable.Range(1, 500000)
                //.Select(index => new Employee
                //{
                //    ProductID = index,
                //    ProductName = "Product #" + index,
                //    UnitPrice = index * 10,
                //    Discontinued = false
                //}).ToList();
                List<Employee> data = new List<Employee>();
                Employee emp = new Employee();
                data = emp.GetEmpList();
                return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return null;
        }











        //Export with NPOI Static
        public FileResult ExportWithNPOI([DataSourceRequest] DataSourceRequest request)
        {
            //Get the data representing the current grid state - page, sort and filter
            List<Employee> data = new List<Employee>();
            Employee emp = new Employee();
            data = emp.GetEmpList();

            //Create new Excel workbook
            var workbook = new XSSFWorkbook();

            //Create new Excel sheet
            var sheet = workbook.CreateSheet();

            //Create a header row
            var headerRow = sheet.CreateRow(0);

            //Set the column names in the header row
            headerRow.CreateCell(0).SetCellValue("Product ID");
            headerRow.CreateCell(1).SetCellValue("Product Name");
            headerRow.CreateCell(2).SetCellValue("Unit Price");
            headerRow.CreateCell(3).SetCellValue("Quantity Per Unit");

            int rowNumber = 1;

            //Populate the sheet with values from the grid data
            foreach (Employee product in data)
            {
                //Create a new row
                var row = sheet.CreateRow(rowNumber++);

                //Set values for the cells
                row.CreateCell(0).SetCellValue(product.ProductID);
                row.CreateCell(1).SetCellValue(product.ProductName);
                row.CreateCell(2).SetCellValue(product.UnitPrice.ToString());
                row.CreateCell(3).SetCellValue(product.Discontinued.ToString());
            }

            //Write the workbook to a memory stream
            MemoryStream output = new MemoryStream();
                workbook.Write(output);

                //Return the result to the end user
                return File(output.ToArray(),   //The binary data of the XLS file
                    "application/vnd.ms-excel", //MIME type of Excel files
                    "GridExcelExport.xlsx");     //Suggested file name in the "Save as" dialog which will be displayed to the end user
        }


        //ClosedXML
        //public ActionResult ExportToExcel()
        //{
        //    var gv = new GridView();

        //    var data = Enumerable.Range(1, 100000)
        //        .Select(index => new Employee
        //        {
        //            ProductID = index,
        //            ProductName = "Product #" + index,
        //            UnitPrice = index * 10,
        //            Discontinued = false
        //        }).ToList();

        //    gv.DataSource = data;
        //    gv.DataBind();

        //    Response.ClearContent();
        //    Response.Buffer = true;
        //    Response.AddHeader("content-disposition", "attachment; filename=DemoExcel.xls");
        //    Response.ContentType = "application/ms-excel";
        //    Response.Charset = "";
        //    StringWriter objStringWriter = new StringWriter();
        //    HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);

        //    gv.RenderControl(objHtmlTextWriter);

        //    Response.Output.Write(objStringWriter.ToString());
        //    Response.Flush();
        //    Response.End();

        //    return View("Index");
        //}


        //NPOI export all Generic
        public void WriteExcelWithNPOI(DataTable dt, String extension)
        {

            IWorkbook workbook;

            if (extension == "xlsx")
            {
                workbook = new XSSFWorkbook();
            }
            else
            {
                throw new Exception("This format is not supported");
            }

            ISheet sheet1 = workbook.CreateSheet("Sheet 1");

            //make a header row
            IRow row1 = sheet1.CreateRow(0);

            for (int j = 0; j < dt.Columns.Count; j++)
            {

                ICell cell = row1.CreateCell(j);
                String columnName = dt.Columns[j].ToString();
                cell.SetCellValue(columnName);
            }

            //loops through data
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IRow row = sheet1.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {

                    ICell cell = row.CreateCell(j);
                    String columnName = dt.Columns[j].ToString();
                    cell.SetCellValue(dt.Rows[i][columnName].ToString());
                }
            }
            using (var exportData = new MemoryStream())
            {
                Response.Clear();
                workbook.Write(exportData);
                if (extension == "xlsx") //xlsx file format
                {
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "StudentNPOI.xlsx"));
                    Response.BinaryWrite(exportData.ToArray());
                }
                Response.End();
            }
        }

        public void ExportListUsingNPOI()
        {
            List<Employee> data = new List<Employee>();
            Employee emp = new Employee();
            data = emp.GetEmpList();
            var Datatble = ToDataTable(data);

            //Call NPOI method with xlx output
            WriteExcelWithNPOI(Datatble, "xlsx");
        }


        // Convert .ToList into Datatable
        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties by using reflection   
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names  
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {

                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }






        //Bind data from database to Telerik Grid
        public JsonResult GetDBData([DataSourceRequest] DataSourceRequest request)
        {
            List<DBTable> dbTable = new List<DBTable>();
            DBTable dt = new DBTable();
            dbTable = dt.dtTable();
            return Json(dbTable.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        //Export DB Data to Excel
        public void ExportFromDBData()
        {
            List<DBTable> data = new List<DBTable>();
            DBTable emp = new DBTable();
            data = emp.dtTable();
            var Datatble = ToDataTable(data);

            //Call NPOI method with xlx output
            WriteExcelWithNPOI(Datatble, "xlsx");
        }

    }
}