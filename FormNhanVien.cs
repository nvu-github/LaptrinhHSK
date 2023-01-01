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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS
{
    public partial class FormNhanVien : Form
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        public FormNhanVien()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rdoNam.Checked = true;
            LayDSNS();
            getDataPhongBan();
            /*comboBox1.SelectedIndex = -1;*/
        }


        private void getDataPhongBan()
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                string procname = "sp_Getphongban";
                using (SqlCommand cmd = new SqlCommand(procname, cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dttb = new DataTable("tbl_phongban");
                        da.Fill(dttb);

                        DataView dbv = new DataView(dttb);

                        comboBox1.DisplayMember = "sTenphong";
                        comboBox1.ValueMember = "PK_PhongbanID";
                        comboBox1.DataSource = dbv;
                    }
                }
            }
        }

        private void LayDSNS()
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                string procname = "sp_GetNhanVien";
                using (SqlCommand cmd = new SqlCommand(procname, cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dttb = new DataTable("tbl_nhanvien");
                        da.Fill(dttb);
                        
                        DataView dbv = new DataView(dttb);

                        dataGridView1.AutoGenerateColumns = false;
                        dataGridView1.DataSource = dbv;

                        dataGridView1.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
                    }
                }
            }
        }

        private void Reset()
        {
            txtDiaChi.Text = "";
            txtHoTen.Text = "";
            txtPhone.Text = "";
            rdoNam.Checked = true;
            rdoNu.Checked = false;
            chucvu.Text = "";
            comboBox1.SelectedIndex = comboBox1.FindStringExact("Phong ban 1");
            ngaysinh.Text = "";
            btnXoa.Enabled = btnSua.Enabled = true;
            insert.Text = "Thêm";
            insert.Tag = "add";
            LayDSNS();
        }

        private bool KiemTraThongTin()
        {
            if (txtHoTen.Text == "")
            {
                MessageBox.Show("Vui lòng điền họ và tên nhân viên.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txtHoTen.Focus();
                return false;
            }
            if (ngaysinh.Text == "")
            {
                MessageBox.Show("Vui lòng điền ngày sinh nhân viên.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                ngaysinh.Focus();
                return false;
            }
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Vui lòng điền địa chỉ của nhân viên.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return false;
            }
            if (rdoNam.Checked == false && rdoNu.Checked == false)
            {
                MessageBox.Show("Vui lòng chọn giới tính cho nhân viên.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }
            if (txtPhone.Text == "")
            {
                MessageBox.Show("Vui lòng điền số điện thoại của nhân viên.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txtPhone.Focus();
                return false;
            }
            if (chucvu.Text == "")
            {
                MessageBox.Show("Vui lòng điền chức vụ của nhân viên.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txtPhone.Focus();
                return false;
            }
            return true;
        }

        private static int GetAge(DateTime birthDate)
        {
            DateTime n = DateTime.Now;
            int age = n.Year - birthDate.Year;

            if (n.Month < birthDate.Month || (n.Month == birthDate.Month && n.Day < birthDate.Day))
                age--;

            return age;
        }

        private void insert_Click(object sender, EventArgs e)
        {
            if (KiemTraThongTin())
            {
                    string ht = txtHoTen.Text;
                    DateTime ns = DateTime.ParseExact(ngaysinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    int gt = 0;

                    bool gtchecked = rdoNam.Checked;
                    if (gtchecked)
                        gt = 1;
                    else
                        gt = 0;
                    string dc = txtDiaChi.Text;
                    string sdt = txtPhone.Text;
                    string cv = chucvu.Text;
                    string pb = comboBox1.SelectedValue.ToString();

                    using (SqlConnection cnn = new SqlConnection(connectionString))
                    {
                        string procname = "spNhanvien_insert";
                        if (insert.Tag.ToString() != "add")
                        {
                            procname = "spNhanvien_update";
                        }
                        using (SqlCommand cm = new SqlCommand(procname, cnn))
                        {
                            cm.CommandType = CommandType.StoredProcedure;

                            if (insert.Tag.ToString() != "add")
                            {
                                cm.Parameters.Add("@PK_NhanvienID", SqlDbType.Int).Value = insert.Tag.ToString();
                            }
                            cm.Parameters.Add("@sHoten", SqlDbType.NVarChar, 255).Value = ht;
                            cm.Parameters.Add("@dNgaysinh", SqlDbType.SmallDateTime).Value = ns;
                            cm.Parameters.Add("@bGioitinh", SqlDbType.Bit).Value = gt;
                            cm.Parameters.Add("@sDiachi", SqlDbType.NVarChar, 255).Value = dc;
                            cm.Parameters.Add("@sDienthoai", SqlDbType.VarChar, 20).Value = sdt;
                            cm.Parameters.Add("@sChucvu", SqlDbType.VarChar, 255).Value = cv;
                            cm.Parameters.Add("@FK_PhongbanID", SqlDbType.Int).Value = pb;

                            cnn.Open();
                            int i = cm.ExecuteNonQuery();
                            if (i > 0)
                            {
                                if (insert.Tag.ToString() != "add")
                                {
                                    MessageBox.Show("Cập nhật nhân viên thành công", "Thông báo");
                                }
                                else
                                {
                                    MessageBox.Show("Thêm nhân viên thành công", "Thông báo");
                                }
                                LayDSNS();
                                Reset();
                            }
                            cnn.Close();
                        }
                    }
                
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataView dvNhanVien = (DataView)dataGridView1.DataSource;
            DataRowView row = dvNhanVien[dataGridView1.CurrentRow.Index];
            txtHoTen.Text = row["sHoten"].ToString();
            txtDiaChi.Text = row["sDiachi"].ToString();
            var d = row["dNgaysinh"].ToString().Split('/');
            ngaysinh.Text = String.Format("" + ((int.Parse(d[0]) < 10) ? "0" : "") + "{0:00}/" + ((int.Parse(d[1]) < 10) ? "0" : "") + "{1:00}/{2:0000}", d[0], d[1], d[2]);
            if (row["bGioitinh"].ToString() == "Nam")
                rdoNam.Checked = true;
            else
                rdoNu.Checked = true;
            txtPhone.Text = row["sDienthoai"].ToString();
            chucvu.Text = row["sChucvu"].ToString();
            comboBox1.SelectedIndex = comboBox1.FindStringExact(row["sTenphong"].ToString());
            btnXoa.Enabled = btnSua.Enabled = false;
            insert.Text = "Cập nhật";
            insert.Tag = row["PK_NhanvienID"].ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DataView dvnv = (DataView)dataGridView1.DataSource;
                DataRowView row = dvnv[dataGridView1.CurrentRow.Index];

                string id = row["PK_NhanvienID"].ToString();
                string hoten = row["sHoten"].ToString();

                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand("spNhanvien_delete", cnn))
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.Add("@PK_NhanvienID", SqlDbType.Int).Value = id;
                        DialogResult dg = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (dg == DialogResult.OK)
                        {
                            cnn.Open();
                            int i = cm.ExecuteNonQuery();
                            if (i > 0)
                            {
                                MessageBox.Show(string.Format("Xóa nhân viên {0} thành công", hoten),
                                        "Message",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                                LayDSNS();
                                Reset();
                            }
                            cnn.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa thất bại, nhân viên này đang trong quá trình thi công");
            }
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            Reset();
            btnXoa.Enabled = btnSua.Enabled = true;
            insert.Text = "Thêm";
            insert.Tag = "add";
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string ht = txtHoTen.Text;
            DateTime ns = DateTime.ParseExact(ngaysinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string gtinh = "";
            bool gtchecked = rdoNam.Checked;
            if (gtchecked)
                gtinh = "Nam";
            else
                gtinh = "Nữ";
            string address = txtDiaChi.Text;
            string phonenumer = txtPhone.Text;
            string cvu = chucvu.Text;
            string pban = comboBox1.Text;

            string dieukienloc = "PK_NhanvienID > 0";
            if (!string.IsNullOrEmpty(ht))
            {
                dieukienloc += string.Format(" AND sHoten LIKE '%{0}%' ", ht);
            }
            if (!string.IsNullOrEmpty(ngaysinh.Text))
            {
                dieukienloc += string.Format(" AND dNgaysinh >= '{0}' AND dNgaysinh <= '{0}' ", ns);
            }
            DialogResult dialogResult = MessageBox.Show("Có tìm kiếm theo giới tính không", "Tìm kiếm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                dieukienloc += string.Format(" AND bGioitinh  LIKE '%{0}%'", gtinh);
            }
            if (!string.IsNullOrEmpty(address))
            {
                dieukienloc += string.Format(" AND sDiachi LIKE '%{0}%' ", address);
            }
            if (!string.IsNullOrEmpty(phonenumer))
            {
                dieukienloc += string.Format(" AND sDienthoai LIKE '%{0}%'", phonenumer);
            }
            if (!string.IsNullOrEmpty(cvu))
            {
                dieukienloc += string.Format(" AND sChucvu LIKE '%{0}%'", cvu);
            }
            if (!string.IsNullOrEmpty(pban))
            {
                dieukienloc += string.Format(" AND sTenphong LIKE '%{0}%'", pban);
            }

            DataView dvKhachhang = dataGridView1.DataSource as DataView;
            dvKhachhang.RowFilter = dieukienloc;
            dataGridView1.DataSource = dvKhachhang;
        }
    }
}
