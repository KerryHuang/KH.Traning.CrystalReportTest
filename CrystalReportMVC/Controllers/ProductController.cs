using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CrystalReportMVC.Models;
using CrystalDecisions.CrystalReports.Engine;

using System.IO;

namespace CrystalReportMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            // 資料庫類別
            ProductRepository db = new ProductRepository();
            //List<ProductModel> items =  db.GetAll();

            // 取得資料
            ProductDataSet ds = db.ExcuteDataSet();

            // 報表文件類別
            ReportClass reportdoc = new ReportClass();

            // 讀取報表檔
            reportdoc.FileName = Server.MapPath("~/Views/Product/ProductReport.rpt");

            // 設定資料來源1
            reportdoc.SetDataSource(ds);

            // 設定輸出楁式為PDF
            Stream stream = reportdoc.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

            return File(stream, "application/pdf");
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
