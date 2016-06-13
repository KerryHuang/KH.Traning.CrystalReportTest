using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CrystalDecisions.CrystalReports.Engine;

namespace CrystalReportTest
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 報表文件類別
            ReportDocument reportdoc = new ReportDocument();

            // 讀取報表檔
            reportdoc.FileName = Server.MapPath("~/View/Pull.rpt");

            // 登入資料
            CrystalDecisions.Shared.TableLogOnInfo logininfo;

            // 加入資料庫帳號密碼
            foreach(CrystalDecisions.CrystalReports.Engine.Table table in reportdoc.Database.Tables)
            {
                logininfo = table.LogOnInfo;
                logininfo.ConnectionInfo.UserID = "cr";
                logininfo.ConnectionInfo.Password = "123";
                table.ApplyLogOnInfo(logininfo);
            }

            // 設定資料來源2
            CrystalReportViewer1.ReportSource = reportdoc;

        }
    }
}