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
    public partial class frmphongban : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        public frmphongban()
        {
            InitializeComponent();
        }
        Clsdatabase cls = new Clsdatabase();
        private void frmphongban_Load(object sender, EventArgs e)
        {
            loadPhongban();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in this.groupBox1.Controls)
            {
                if ((ctr is TextBox) || (ctr is DateTimePicker) || (ctr is ComboBox))
                {
                    ctr.Text = "";
                }
            }
        }
        private void loadPhongban()
        {
            DataTable phongban = Clsdatabase.loadtable("sp_Phongbanget");
            DataView dataViewphongban = new DataView(phongban);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.DataSource = dataViewphongban;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string procname = "sp_PhongbanInsert";
            string tenphong = textBox3.Text;
            DateTime ngaythanhlap = DateTime.ParseExact(dateTimePicker1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string chucnang = textBox5.Text;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(procname, connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@sTenphong", SqlDbType.NVarChar, 50).Value = tenphong;
                        command.Parameters.Add("@sPhutrach", SqlDbType.NVarChar, 50).Value = chucnang;
                        command.Parameters.Add("@dNgaythanhlap", SqlDbType.SmallDateTime).Value = ngaythanhlap;
                        int row_aff = command.ExecuteNonQuery();
                        if (row_aff > 0)
                        {
                            MessageBox.Show("Thêm phòng ban thành công");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    connection.Close();
                }
            }
            loadPhongban();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataView dataView = (DataView)dataGridView1.DataSource;
            DataRowView row = dataView[dataGridView1.CurrentRow.Index];
            if(row["sTenphong"] != System.DBNull.Value)
            {
                textBox3.Text = (string)row["sTenphong"];
                dateTimePicker1.Text = row["dNgaythanhlap"].ToString();
                textBox5.Text = (string)row["sPhutrach"];
                button2.Tag = row["PK_PhongbanID"];
            }    
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string maphongban = button2.Tag.ToString();
            if(!string.IsNullOrEmpty(maphongban))
            {
                string procname = "sp_PhongbanUpdate";
                string tenphong = textBox3.Text;
                DateTime ngaythanhlap = DateTime.ParseExact(dateTimePicker1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string chucnang = textBox5.Text;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(procname, connection))
                    {
                        try
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add("@sTenphong", SqlDbType.NVarChar, 50).Value = tenphong;
                            command.Parameters.Add("@sPhutrach", SqlDbType.NVarChar, 50).Value = chucnang;
                            command.Parameters.Add("@dNgaythanhlap", SqlDbType.SmallDateTime).Value = ngaythanhlap;
                            command.Parameters.Add("@PK_PhongbanID", SqlDbType.Int).Value = maphongban;
                            int row_aff = command.ExecuteNonQuery();
                            if (row_aff > 0)
                            {
                                MessageBox.Show("Sửa phòng ban thành công");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        connection.Close();
                    }
                }
                loadPhongban();
            } else
            {
                MessageBox.Show("Hãy chọn phòng ban cần chỉnh sửa");
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string dieukienloc = "PK_PhongbanID>0";
            if (!string.IsNullOrEmpty(textBox3.Text))
            {
                dieukienloc += string.Format(" AND sTenphong LIKE '%{0}%'", textBox3.Text);

            }
            if (!string.IsNullOrEmpty(textBox5.Text))
            {
                dieukienloc += string.Format(" AND sPhutrach LIKE '%{0}%'", textBox5.Text);

            }
            DialogResult timtheogt = MessageBox.Show("Có tìm theo ngày thành lập không?", "Tìm kiếm", MessageBoxButtons.YesNo);
            if (timtheogt == DialogResult.Yes)
            {
                string dateval = dateTimePicker1.Text;
                DateTime dt = DateTime.ParseExact(dateval, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                string st = dt.ToString("yyyy-MM-dd");

                dieukienloc += String.Format(" AND dNgaythanhlap=#{0}#", st);
            }
            DataView dataView = dataGridView1.DataSource as DataView;
            dataView.RowFilter = dieukienloc;
            dataGridView1.DataSource = dataView;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string maphongban = button2.Tag.ToString();
            if (!string.IsNullOrEmpty(maphongban))
            {
                string procname = "sp_PhongbanDelete";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(procname, connection))
                    {
                        try
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("PK_PhongbanID", maphongban);
                            int row_aff = command.ExecuteNonQuery();
                            if (row_aff > 0)
                            {
                                MessageBox.Show("Xóa phòng ban thành công");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Xóa thất bại. Phòng ban đã được sử dụng");
                        }
                        connection.Close();
                    }
                }
                loadPhongban();
            }
            else
            {
                MessageBox.Show("Hãy chọn phòng ban để xóa");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormReport frp = new FormReport();
            frp.showReport("PhongbanReport1.rpt", "Danh sách phòng ban", "");
            frp.Show();

            /*CrystalDecisions.CrystalReports.Engine.ReportDocument
                 rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            string reportFile = string.Format("{0}\\Report\\PhongbanReport1.rpt", Application.StartupPath);
            rpt.Load(reportFile);
            CrystalDecisions.Shared.TableLogOnInfo tableLogOnInfo = new CrystalDecisions.Shared.TableLogOnInfo();
            tableLogOnInfo.ConnectionInfo.ServerName = "DESKTOP-LNGJ4BJ";
            tableLogOnInfo.ConnectionInfo.DatabaseName = "BTL_HSK";
            tableLogOnInfo.ConnectionInfo.UserID = "sa";
            tableLogOnInfo.ConnectionInfo.Password = "Anhung21";
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in rpt.Database.Tables)
            {
                table.ApplyLogOnInfo(tableLogOnInfo);
            }

            rpt.SummaryInfo.ReportTitle = "Danh sách phòng ban";
            FormReport f = new FormReport();

            f.CrpReport.ReportSource = rpt;
            f.CrpReport.Refresh();
            f.ShowDialog();*/
        }
    }
}
