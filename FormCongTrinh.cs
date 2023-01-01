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
    public partial class FormCongTrinh : Form
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public FormCongTrinh()
        {
            InitializeComponent();
        }

        private void FormCongTrinh_Load(object sender, EventArgs e)
        {
            getDataCongTrinh();
        }

        private void getDataCongTrinh()
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

                        dataGridView1.AutoGenerateColumns = false;
                        dataGridView1.DataSource = dbv;

                        dataGridView1.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";
                        dataGridView1.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
                        dataGridView1.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";


                    }
                }
            }
        }

        private void insert_Click(object sender, EventArgs e)
        {
            if (KiemTraThongTin())
            {
                try
                {
                    string tenct = txtCongtrinh.Text;
                    DateTime ncp = DateTime.ParseExact(ngaycapphep.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime nkc = DateTime.ParseExact(ngaykhoicong.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime nkt = DateTime.ParseExact(ngayhoanthanh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    using (SqlConnection cnn = new SqlConnection(connectionString))
                    {
                        string procName = "spCongtrinh_insert";
                        if (insert.Tag != null)
                        {
                            procName = "spCongtrinh_update";
                        }
                        using (SqlCommand cmd = new SqlCommand(procName, cnn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            if (insert.Tag != null)
                            {
                                cmd.Parameters.Add("@PK_CongtrinhID", SqlDbType.Int).Value = insert.Tag.ToString();
                            }
                            cmd.Parameters.Add("@sTencongtrinh", SqlDbType.NVarChar, 255).Value = tenct;
                            cmd.Parameters.Add("@dNgaycapphep", SqlDbType.SmallDateTime).Value = ncp;
                            cmd.Parameters.Add("@dNgaykhoicong", SqlDbType.SmallDateTime).Value = nkc;
                            cmd.Parameters.Add("@dNgayhoanthanh", SqlDbType.SmallDateTime).Value = nkt;

                            cnn.Open();
                            int i = cmd.ExecuteNonQuery();
                            if (i > 0)
                            {
                                if (insert.Tag != null)
                                {
                                    MessageBox.Show("Cập nhật thông tin công trình thành công");
                                } else
                                {
                                    MessageBox.Show("Thêm thông tin công trình thành công");
                                }
                                clearForm();
                            }
                            cnn.Close();
                        }
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataView dv = (DataView)dataGridView1.DataSource;
            DataRowView row = dv[dataGridView1.CurrentRow.Index];

            txtCongtrinh.Text = row["sTencongtrinh"].ToString();
            var d1 = row["dNgaycapphep"].ToString().Split('/');
            ngaycapphep.Text = String.Format("" + ((int.Parse(d1[0]) < 10) ? "0" : "") + "{0:00}/" + ((int.Parse(d1[1]) < 10) ? "0" : "") + "{1:00}/{2:0000}", d1[0], d1[1], d1[2]);
            var d2 = row["dNgaykhoicong"].ToString().Split('/');
            ngaykhoicong.Text = String.Format("" + ((int.Parse(d2[0]) < 10) ? "0" : "") + "{0:00}/" + ((int.Parse(d2[1]) < 10) ? "0" : "") + "{1:00}/{2:0000}", d2[0], d2[1], d2[2]);
            var d3 = row["dNgayhoanthanh"].ToString().Split('/');
            ngayhoanthanh.Text = String.Format("" + ((int.Parse(d3[0]) < 10) ? "0" : "") + "{0:00}/" + ((int.Parse(d3[1]) < 10) ? "0" : "") + "{1:00}/{2:0000}", d3[0], d3[1], d3[2]);

            btnSua.Enabled = btnXoa.Enabled = false;
            insert.Text = "Cập nhật";
            insert.Tag = row["PK_CongtrinhID"].ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataView dv = (DataView)dataGridView1.DataSource;
            DataRowView row = dv[dataGridView1.CurrentRow.Index];

            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand("spCongtrinh_delete", cnn))
                    {
                        cm.CommandType = CommandType.StoredProcedure;

                        cm.Parameters.Add("@PK_CongtrinhID", SqlDbType.Int).Value = row["PK_CongtrinhID"].ToString();
                        DialogResult dg = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (dg == DialogResult.OK)
                        {
                            cnn.Open();
                            int i = cm.ExecuteNonQuery();
                            if (i > 0)
                            {
                                MessageBox.Show("Xóa thông tin công trình thành công");
                                clearForm();
                            }
                            cnn.Close();
                        }
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Xóa thất bại, công trình này đang trong quá trình thi công");
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string tenct = txtCongtrinh.Text;

            string dieukien = "PK_CongtrinhID > 0";
            if (tenct != "")
            {
                dieukien += string.Format(" AND sTencongtrinh LIKE '%{0}%'", tenct);
            }

            DataView dvCongtrinh = dataGridView1.DataSource as DataView;
            dvCongtrinh.RowFilter = dieukien;
            dataGridView1.DataSource = dvCongtrinh;
        }

        private void clearForm()
        {
            txtCongtrinh.Text = "";
            ngaycapphep.Text = "";
            ngaykhoicong.Text = "";
            ngayhoanthanh.Text = "";
            btnSua.Enabled = btnXoa.Enabled = true;
            insert.Text = "Thêm";
            insert.Tag = null;
            getDataCongTrinh();
            
        }
        private bool KiemTraThongTin()
        {
            if (txtCongtrinh.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên công trình.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txtCongtrinh.Focus();
                return false;
            }
            if (ngaycapphep.Text == "")
            {
                MessageBox.Show("Vui lòng nhập ngày cấp phép.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                ngaycapphep.Focus();
                return false;
            }
            if (ngaykhoicong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập ngày khởi công",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                ngaykhoicong.Focus();
                return false;
            }
            if (ngayhoanthanh.Text == "")
            {
                MessageBox.Show("Vui lòng nhập ngày hoàn thành.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                ngayhoanthanh.Focus();
                return false;
            }
            return true;
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = btnXoa.Enabled = true;
            insert.Text = "Thêm";
            insert.Tag = null;
            clearForm();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }
    }
}
