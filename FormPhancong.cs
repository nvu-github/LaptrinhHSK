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
    public partial class FormPhancong : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        public string quyen;
        private string namect, id_congtrinh_old, id_nhanvien_old;
        public FormPhancong()
        {
            InitializeComponent();
        }

        private void FormPhancong_Load(object sender, EventArgs e)
        {
            checkload(quyen);
            get_data_thicong();
            get_data_congtrinh();
            get_data_nhanvien();
        }

        public void checkload(string quyen)
        {
            if (quyen == "User")
            {
                insert.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnBoqua.Enabled = false;
            }
        }

        private void get_data_thicong()
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cm = new SqlCommand("sp_Getthicong", cnn))
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cm))
                    {
                        DataTable data = new DataTable("tbl_thicong");
                        da.Fill(data);

                        DataView dv = new DataView(data);
                        dataGridView1.AutoGenerateColumns = false;
                        dataGridView1.DataSource = dv;

                        dataGridView1.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
                        dataGridView1.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
                    }
                }
            }
        }

        private void get_data_congtrinh()
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                string procname = "sp_Getcongtrinh";
                using (SqlCommand cmd = new SqlCommand(procname, cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dttb = new DataTable("tbl_congtrinh");
                        da.Fill(dttb);

                        DataView dbv = new DataView(dttb);
                        comboBox1.DisplayMember = "sTencongtrinh";
                        comboBox1.ValueMember = "PK_CongtrinhID";
                        comboBox1.DataSource = dbv;
                    }
                }
            }
        }

        private void get_data_nhanvien()
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                string procname = "sp_Getnhanvien";
                using (SqlCommand cmd = new SqlCommand(procname, cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dttb = new DataTable("tbl_nhanvien");
                        da.Fill(dttb);

                        DataView dbv = new DataView(dttb);
                        comboBox2.DisplayMember = "sHoten";
                        comboBox2.ValueMember = "PK_NhanvienID";
                        comboBox2.DataSource = dbv;
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataView dv = (DataView)dataGridView1.DataSource;
            DataRowView row = dv[dataGridView1.CurrentRow.Index];

            comboBox1.SelectedIndex = comboBox1.FindStringExact(row["sTencongtrinh"].ToString());
            comboBox2.SelectedIndex = comboBox2.FindStringExact(row["sHoten"].ToString());
            var d1 = row["dNgaybatdau"].ToString().Split('/');
            ngaybatdau.Text = String.Format("" + ((int.Parse(d1[0]) < 10) ? "0" : "") + "{0:00}/" + ((int.Parse(d1[1]) < 10) ? "0" : "") + "{1:00}/{2:0000}", d1[0], d1[1], d1[2]);
            var d2 = row["dNgayketthuc"].ToString().Split('/');
            ngayketthuc.Text = String.Format("" + ((int.Parse(d2[0]) < 10) ? "0" : "") + "{0:00}/" + ((int.Parse(d2[1]) < 10) ? "0" : "") + "{1:00}/{2:0000}", d2[0], d2[1], d2[2]);
            songaycong.Text = row["iSongaycong"].ToString();

            namect = row["sTencongtrinh"].ToString();
            id_congtrinh_old = row["FK_CongtrinhID"].ToString();
            id_nhanvien_old = row["FK_NhanvienID"].ToString();

            btnSua.Enabled = btnXoa.Enabled = false;
            insert.Text = "Cập nhật";
            insert.Tag = row["FK_CongtrinhID"].ToString();
        }

        private void insert_Click(object sender, EventArgs e)
        {
            
            string id_congtrinh = comboBox1.SelectedValue.ToString();
            string id_nhanvien = comboBox2.SelectedValue.ToString();
            DateTime nbd = DateTime.ParseExact(ngaybatdau.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime nkt = DateTime.ParseExact(ngayketthuc.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string snc = songaycong.Text;

            if (check_date() == 1)
            {
                MessageBox.Show("Nhân viên này đang thi công một công trình khác trong khoảng thời gian này!");
                return;
            }
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    string procname = "spThicong_insert";
                    if (insert.Tag.ToString() != "add")
                    {
                        procname = "spThicong_update";
                    }
                    using (SqlCommand cm = new SqlCommand(procname, cnn))
                    {
                        cm.CommandType = CommandType.StoredProcedure;

                        /*MessageBox.Show(id_congtrinh + " " + id_nhanvien + " " + nbd + " " + nkt + " " + snc);*/
                        if (insert.Tag.ToString() != "add")
                        {
                            cm.Parameters.Add("@FK_CongtrinhID_Old", SqlDbType.Int).Value = id_congtrinh_old;
                            cm.Parameters.Add("@FK_NhanvienID_Old", SqlDbType.Int).Value = id_nhanvien_old;
                        }
                        cm.Parameters.Add("@FK_CongtrinhID", SqlDbType.Int).Value = id_congtrinh;
                        cm.Parameters.Add("@FK_NhanvienID", SqlDbType.Int).Value = id_nhanvien;
                        cm.Parameters.Add("@dNgaybatdau", SqlDbType.SmallDateTime).Value = nbd;
                        cm.Parameters.Add("@dNgayketthuc", SqlDbType.SmallDateTime).Value = nkt;
                        cm.Parameters.Add("@iSongaycong", SqlDbType.Int).Value = snc;

                        cnn.Open();
                        int i = cm.ExecuteNonQuery();
                        if (i > 0)
                        {
                            if (insert.Tag.ToString() != "add")
                            {
                                MessageBox.Show("Cập nhật phân công nhân viên - công trình thành công");
                            }
                            else
                            {
                                MessageBox.Show("Phân công nhân viên - công trình thành công");
                            }
                            get_data_congtrinh();
                            get_data_nhanvien();
                            get_data_thicong();
                            clearForm();
                        }
                        cnn.Close();
                    }
                }
            } catch
            {
                MessageBox.Show("Nhân viên này đang thi công công trình này");
            }
        }

        private int check_date()
        {
            for (int rows = 0; rows < dataGridView1.Rows.Count; rows++)
            {
                string ngaybd = dataGridView1.Rows[rows].Cells[2].Value == null ? "" : dataGridView1.Rows[rows].Cells[2].Value.ToString();
                string ngaykt = dataGridView1.Rows[rows].Cells[3].Value == null ? "" : dataGridView1.Rows[rows].Cells[3].Value.ToString();
                string tennv = dataGridView1.Rows[rows].Cells[0].Value == null ? "" : dataGridView1.Rows[rows].Cells[0].Value.ToString();
                string tenct = dataGridView1.Rows[rows].Cells[1].Value == null ? "" : dataGridView1.Rows[rows].Cells[1].Value.ToString();
                Boolean dieukien = tennv.ToLower().Equals(comboBox2.Text.ToLower());
                if (insert.Tag.ToString() != "add")
                {
                    dieukien = tennv.ToLower().Equals(comboBox2.Text.ToLower()) && !tenct.ToLower().Equals(namect.ToLower());
                }
                if (dieukien)
                {
                    if (!string.IsNullOrEmpty(ngaybd) && !string.IsNullOrEmpty(ngaykt))
                    {
                        DateTime nbd = DateTime.Parse(ngaybd);
                        DateTime nkt = DateTime.Parse(ngaykt);

                        DateTime nbatdau = DateTime.ParseExact(ngaybatdau.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        DateTime nketthuc = DateTime.ParseExact(ngayketthuc.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                        if (nbd <= nbatdau && nketthuc <= nkt)
                        {
                            return 1;
                        }
                    }
                }
            }
            return 0;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataView dv = (DataView)dataGridView1.DataSource;
            DataRowView row = dv[dataGridView1.CurrentRow.Index];

            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand("spThicong_delete", cnn))
                    {
                        cm.CommandType = CommandType.StoredProcedure;

                        cm.Parameters.Add("@FK_CongtrinhID", SqlDbType.Int).Value = row["FK_CongtrinhID"].ToString();
                        cm.Parameters.Add("@FK_NhanvienID", SqlDbType.Int).Value = row["FK_NhanvienID"].ToString();
                        DialogResult dg = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (dg == DialogResult.OK)
                        {
                            cnn.Open();
                            int i = cm.ExecuteNonQuery();
                            if (i > 0)
                            {
                                MessageBox.Show("Xóa phân công nhân viên - công trình thành công");
                                clearForm();
                            }
                            cnn.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clearForm()
        {
            get_data_congtrinh();
            get_data_nhanvien();
            get_data_thicong();
            ngaybatdau.Text = "";
            ngayketthuc.Text = "";
            songaycong.Text = "";
            btnSua.Enabled = btnXoa.Enabled = true;
            insert.Text = "Thêm";
            insert.Tag = "add";
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            clearForm();
        }
        /*MessageBox.Show(""+(nkt - nbd).TotalDays);return;*/
    }
}
