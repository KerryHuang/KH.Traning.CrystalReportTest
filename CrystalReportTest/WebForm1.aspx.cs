using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CrystalReportTest.Model;
using CrystalDecisions.CrystalReports.Engine;

namespace CrystalReportTest
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 資料庫類別
            ProductRepository db = new ProductRepository();
            //List<ProductModel> items =  db.GetAll();

            // 取得資料
            ProductDataSet ds = db.ExcuteDataSet();

            // 報表文件類別
            ReportDocument reportdoc = new ReportDocument();

            // 讀取報表檔
            reportdoc.FileName = Server.MapPath("~/View/Push.rpt");

            // 設定資料來源1
            reportdoc.SetDataSource(ds);

            // 設定資料來源2
            CrystalReportViewer1.ReportSource = reportdoc;

            // 建置報表
            CrystalReportViewer1.DataBind();

            // 設定文字物件
            TextObject txt = (TextObject)reportdoc.ReportDefinition.ReportObjects["MyName"];
            txt.Text = "Kerry";
            txt.Color = System.Drawing.Color.Red;

        }
    }
}