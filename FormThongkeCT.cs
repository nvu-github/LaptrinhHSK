using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLNS
{
    public partial class FormThongkeCT : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        public FormThongkeCT()
        {
            InitializeComponent();
        }

        private void FormThongkeCTThicong_Load(object sender, EventArgs e)
        {
            getDataCongTrinh();
        }

        private void getDataCongTrinh()
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                string procname = "sp_GetcongtrinhReport";
                using (SqlCommand cmd = new SqlCommand(procname, cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dttb = new DataTable("tbl_congtrinh");
                        da.Fill(dttb);
                        DataView dbv = new DataView(dttb);

                        dataGridView1.AutoGenerateColumns = false;
                        dataGridView1.DataSource = dbv;

                        dataGridView1.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";
                        dataGridView1.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
                        dataGridView1.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
                    }
                }
            }
        }

        private void btnThongkeCTTC_Click(object sender, EventArgs e)
        {
            string filter = "{tbl_thicong.FK_CongtrinhID} > 0";
            DateTime nkc = DateTime.ParseExact(ngaykhoicong.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime nht = DateTime.ParseExact(ngayhoanthanh.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DialogResult dg = MessageBox.Show("Bạn có muốn thống kê theo ngày không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dg == DialogResult.OK)
            {
                filter += " AND {tbl_congtrinh.dNgaykhoicong} >= #" + nkc + "# AND {tbl_congtrinh.dNgayhoanthanh} <= #" + nht + "#";
            }
            FormReport formreport = new FormReport();
            formreport.showReport("ReportCongTrinh.rpt", "Danh sách công trình", filter);
            formreport.Show();
        }

        private void xemthongtin_Click(object sender, EventArgs e)
        {
            DateTime nkc = DateTime.ParseExact(ngaykhoicong.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime nht = DateTime.ParseExact(ngayhoanthanh.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string namkc = namkhoicong.Text;
            /*string dieukien = "PK_CongtrinhID > 0";*/

            /*dieukien += " AND dNgaykhoicong >= '"+ nkc + "' AND dNgayhoanthanh <= '"+ nht +"'";*/

            /*dieukien += " AND YEAR(dNgaykhoicong) >= '" + namkc + "'";

            DataView dv = dataGridView1.DataSource as DataView;
            dv.RowFilter = dieukien;
            dataGridView1.DataSource = dv;*/
            DataTable dttb = new DataTable("tbl_congtrinh");
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                string procname = "sp_getdatanam";
                using (SqlCommand cmd = new SqlCommand(procname, cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@thoigian", SqlDbType.VarChar, 4).Value = namkc;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dttb);
                    }
                    dataGridView1.DataSource = null;

                    dataGridView1.AutoGenerateColumns = false;

                    //Set Columns Count
                    dataGridView1.ColumnCount = 6;

                    //Add Columns
                    dataGridView1.Columns[0].Name = "tencongtrinh"; // name
                    dataGridView1.Columns[0].HeaderText = "Tên công trình"; // header text
                    dataGridView1.Columns[0].DataPropertyName = "sTencongtrinh"; // field name

                    dataGridView1.Columns[1].HeaderText = "Ngày cấp phép";
                    dataGridView1.Columns[1].Name = "ngaycp ";
                    dataGridView1.Columns[1].DataPropertyName = "dNgaycapphep";

                    dataGridView1.Columns[2].Name = "ngaykc";
                    dataGridView1.Columns[2].HeaderText = "Ngày khởi công";
                    dataGridView1.Columns[2].DataPropertyName = "dNgaykhoicong";

                    dataGridView1.Columns[3].Name = "ngayht";
                    dataGridView1.Columns[3].HeaderText = "Ngày hoàn thành";
                    dataGridView1.Columns[3].DataPropertyName = "dNgayhoanthanh";

                    dataGridView1.DataSource = dttb;
                }
            }
        }
    }
}
