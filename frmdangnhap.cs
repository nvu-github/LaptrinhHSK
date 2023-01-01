using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace QLNS
{
    public partial class frmdangnhap : Form
    {
        public frmdangnhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Clsdatabase.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_dangnhap", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("sTendangnhap", textBox1.Text);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        if (reader["sTendangnhap"].ToString().Equals(textBox1.Text) && reader["sMatkhau"].ToString().Equals(textBox2.Text))
                        {
                            MessageBox.Show("Đăng nhập vào hệ thống ", "Thông báo !");
                            FrmMain.quyen = (string)reader["sTenquyen"];
                            this.Hide();
                            this.Close();
                            FrmMain frm = new FrmMain();
                            //frm.Show();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác", "Thông báo !");
                            
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản không tồn tại", "Thông báo !");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có chắc muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dg == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        /*check_login(reader["PK_TaikhoanID"].ToString(), reader["iCheck"].ToString());*/

        private void check_login(string id_taikhoan, string icheck)
        {
            int i = 0;
            if (string.IsNullOrEmpty(icheck))
            {
                i = 0;
            }
            else
            {
                i = int.Parse(icheck) + 1;
            }
            using (SqlConnection cnn = new SqlConnection(Clsdatabase.connectionString))
            {
                using (SqlCommand cm = new SqlCommand("sp_uplogin", cnn))
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.Add("@PK_TaikhoanID", SqlDbType.Int).Value = id_taikhoan;
                    if (i < 4)
                        cm.Parameters.Add("@iCheck", SqlDbType.Int).Value = i;
                    else
                        cm.Parameters.Add("@iCheck", SqlDbType.Int).Value = 0;
                    cnn.Open();
                    cm.ExecuteNonQuery();
                    cnn.Close();
                    if (i > 3)
                    {
                        Application.Exit();
                    }
                }
            }
        }
    }
}

