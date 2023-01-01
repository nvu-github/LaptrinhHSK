using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLNS
{
    public partial class FormTKNhanvien : Form
    {
        public FormTKNhanvien()
        {
            InitializeComponent();
        }
        private void loadCbbPhongban()
        {
            comboBox2.DataSource = Clsdatabase.loadtable("sp_Getphongban");
            comboBox2.DisplayMember = "sTenphong";
            comboBox2.ValueMember = "PK_PhongbanID";
        }
        private void loadCbbCongtrinh()
        {
            comboBox2.DataSource = Clsdatabase.loadtable("sp_Getcongtrinh");
            comboBox2.DisplayMember = "sTencongtrinh";
            comboBox2.ValueMember = "PK_CongtrinhID";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key = ((KeyValuePair<string,string>)comboBox1.SelectedItem).Key;
            if(key == "1")
            {
                label3.Text = "Chọn phòng ban";
                loadCbbPhongban();
            } else if(key == "2")
            {
                label3.Text = "Chọn công trình";
                loadCbbCongtrinh();
            }    
        }
        private void loadComboboxTieuChi()
        {
            Dictionary<string,string> comboSource = new Dictionary<string, string>();
            comboSource.Add("1", "Phòng ban");
            comboSource.Add("2", "Công trình");
            comboBox1.DataSource = new BindingSource(comboSource, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";
        }
        private void FormTKNhanvien_Load(object sender, EventArgs e)
        {
            loadComboboxTieuChi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string key = ((KeyValuePair<string, string>)comboBox1.SelectedItem).Key;
            if (key == "1")
            {
                DataTable phongban = new DataTable("phongban");
                using (SqlConnection connection = new SqlConnection(Clsdatabase.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_PhongBanNhanVien", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("PK_PhongbanID", comboBox2.SelectedValue);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(phongban);
                        }
                    }
                }
                dataGridView1.DataSource = null;

                dataGridView1.AutoGenerateColumns = false;

                //Set Columns Count
                dataGridView1.ColumnCount = 6;

                //Add Columns
                dataGridView1.Columns[0].Name = "hoten"; // name
                dataGridView1.Columns[0].HeaderText = "Họ tên"; // header text
                dataGridView1.Columns[0].DataPropertyName = "sHoten"; // field name
                dataGridView1.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridView1.Columns[1].HeaderText = "Ngày sinh";
                dataGridView1.Columns[1].Name = "ngaysinh ";
                dataGridView1.Columns[1].DataPropertyName = "dNgaysinh";

                dataGridView1.Columns[2].Name = "gioitinh";
                dataGridView1.Columns[2].HeaderText = "GIới tính";
                dataGridView1.Columns[2].DataPropertyName = "bGioitinh";

                dataGridView1.Columns[3].Name = "diachi";
                dataGridView1.Columns[3].HeaderText = "Địa chỉ";
                dataGridView1.Columns[3].DataPropertyName = "sDiachi";

                dataGridView1.Columns[4].Name = "dienthoai";
                dataGridView1.Columns[4].HeaderText = "Điện thoại";
                dataGridView1.Columns[4].DataPropertyName = "sDienthoai";

                dataGridView1.Columns[5].Name = "chucvu";
                dataGridView1.Columns[5].HeaderText = "Chức vụ";
                dataGridView1.Columns[5].DataPropertyName = "sChucvu";
                dataGridView1.DataSource = phongban;
            }
            else if (key == "2")
            {
                DataTable thicong = new DataTable("thicong");
                using (SqlConnection connection = new SqlConnection(Clsdatabase.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_ThiCongNhanVien", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("PK_CongtrinhID", comboBox2.SelectedValue);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(thicong);
                        }
                    }
                }
                dataGridView1.DataSource = null;

                dataGridView1.AutoGenerateColumns = false;

                //Set Columns Count
                dataGridView1.ColumnCount = 7;

                //Add Columns
                dataGridView1.Columns[0].Name = "hoten"; // name
                dataGridView1.Columns[0].HeaderText = "Họ tên"; // header text
                dataGridView1.Columns[0].DataPropertyName = "sHoten"; // field name
                dataGridView1.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridView1.Columns[1].HeaderText = "Ngày sinh";
                dataGridView1.Columns[1].Name = "ngaysinh ";
                dataGridView1.Columns[1].DataPropertyName = "dNgaysinh";

                dataGridView1.Columns[2].Name = "gioitinh";
                dataGridView1.Columns[2].HeaderText = "GIới tính";
                dataGridView1.Columns[2].DataPropertyName = "bGioitinh";

                dataGridView1.Columns[3].Name = "diachi";
                dataGridView1.Columns[3].HeaderText = "Địa chỉ";
                dataGridView1.Columns[3].DataPropertyName = "sDiachi";

                dataGridView1.Columns[4].Name = "dienthoai";
                dataGridView1.Columns[4].HeaderText = "Điện thoại";
                dataGridView1.Columns[4].DataPropertyName = "sDienthoai";

                dataGridView1.Columns[5].Name = "chucvu";
                dataGridView1.Columns[5].HeaderText = "Chức vụ";
                dataGridView1.Columns[5].DataPropertyName = "sChucvu";

                dataGridView1.Columns[6].Name = "songaycong";
                dataGridView1.Columns[6].HeaderText = "Số ngày công";
                dataGridView1.Columns[6].DataPropertyName = "iSongaycong";
                dataGridView1.DataSource = thicong;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string patchName = "";
            string title = "";
            string filternv = "{tbl_nhanvien.PK_NhanvienID} > 0";
            string filterct = "{tbl_thicong.FK_NhanvienID} > 0";
            string key = ((KeyValuePair<string, string>)comboBox1.SelectedItem).Key;

            FormReport frp = new FormReport();
            if (key == "1")
            {
                patchName = "ReportNhanviePB.rpt";
                filternv += "AND {tbl_nhanvien.FK_PhongbanID} = "+ comboBox2.SelectedValue.ToString() + "";
                title = "Danh sách nhân viên phòng ban";

                frp.showReport(patchName, title, filternv);
                frp.Show();
            }
            else if (key == "2")
            {
                patchName = "ReportThiCongNhanVien.rpt";
                filterct += " AND {tbl_thicong.FK_CongtrinhID} = " + comboBox2.SelectedValue.ToString() + "";
                title = "Danh sách nhân viên thi công công trình";

                frp.showReport(patchName, title, filterct);
                frp.Show();
            }
        }
    }
}
