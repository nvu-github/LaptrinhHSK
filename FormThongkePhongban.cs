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
    public partial class FormThongkePhongban : Form
    {
        private string phongbanReportFilter;
        private static string ma_phongban = "";
        public FormThongkePhongban()
        {
            InitializeComponent();
        }

        private void FormThongkePhongban_Load(object sender, EventArgs e)
        {

        }
        private void btnThongkePB_Click(object sender, EventArgs e)
        {
            phongbanReportFilter = "{tbl_nhanvien.FK_PhongbanID}>0";
            if (!string.IsNullOrEmpty(ma_phongban))
                phongbanReportFilter += string.Format(" and {1} = {0}", ma_phongban, "{tbl_nhanvien.FK_PhongbanID}");
            FormReport f = new FormReport();
            f.showReport("PhongbanReport.rpt", "Danh sách nhân viên của phòng ban", phongbanReportFilter);
            f.Show();
        }

        private void cbTKPhongban_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTKPhongban.SelectedValue != null)
                ma_phongban = cbTKPhongban.SelectedValue.ToString();
            string sql_tim_nv = "select * from tbl_nhanvien where FK_PhongbanID like '%" + ma_phongban + "%'";
            DataTable mytable = Connection.ExecuteDataTable_SQL(sql_tim_nv);
            dgThongkePhongban.DataSource = mytable;
        }
    }
}
