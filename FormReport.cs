using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLNS
{
    public partial class FormReport : Form
    {
        public FormReport()
        {
            InitializeComponent();
        }
        internal void showReport(string reportFileName, string reportTitle, string recordFilter = "")
        {

            CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            string reportfile = string.Format("{0}\\Report\\{1}", Application.StartupPath, reportFileName);
            reportDocument.Load(reportfile);

            CrystalDecisions.Shared.TableLogOnInfo tableLogOnInfo = new CrystalDecisions.Shared.TableLogOnInfo();
            tableLogOnInfo.ConnectionInfo.ServerName = "LAPTOP-7IF3BCAL\\SQLEXPRESS";
            tableLogOnInfo.ConnectionInfo.DatabaseName = "BTL_HSK";
            tableLogOnInfo.ConnectionInfo.UserID = "sa";
            tableLogOnInfo.ConnectionInfo.Password = "123";

            foreach (CrystalDecisions.CrystalReports.Engine.Table table in reportDocument.Database.Tables)
            {
                table.ApplyLogOnInfo(tableLogOnInfo);
            }

            reportDocument.SummaryInfo.ReportTitle = reportTitle;
            if (!string.IsNullOrEmpty(recordFilter))
            {
                reportDocument.RecordSelectionFormula = recordFilter;
            }
            CrpReport.ReportSource = reportDocument;
            CrpReport.Refresh();
        }
    }
}
