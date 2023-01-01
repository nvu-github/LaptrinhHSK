﻿using System;
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
    public partial class frmdangki : Form
    {
        Clsdatabase cls = new Clsdatabase();
        string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public frmdangki()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string procname = "spTaikhoan_Insert";
            string tendn = textBox1.Text;
            string matkhau = textBox2.Text;
            string manhanvien = comboBox1.SelectedValue.ToString();
            string maquyen = comboBox2.SelectedValue.ToString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand(procname, connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("PK_TaikhoanID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        command.Parameters.AddWithValue("sTendangnhap", tendn);
                        command.Parameters.AddWithValue("sMatkhau", matkhau);
                        command.Parameters.AddWithValue("FK_NhanvienID", manhanvien);
                        command.Parameters.AddWithValue("FK_QuyenID", maquyen);
                        int row_aff = command.ExecuteNonQuery();
                        if (row_aff > 0)
                        {
                            MessageBox.Show("Đăng ký thành công");
                        }
                    } catch
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại");
                    }
                    connection.Close();
                }
            }
            loadTaikhoan();
        }

        private DataTable loadtable(string procname)
        {
            DataTable nhanvien = new DataTable("Nhanvien");
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                using(SqlCommand command = new SqlCommand(procname, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using(SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(nhanvien);
                    }    
                }    
            }    
            return nhanvien;
        }
        private DataTable loadNhanvien()
        {
            DataTable nhanvien = new DataTable("Nhanvien");
            string procname = "nhanvien_get";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(procname, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(nhanvien);
                    }
                }
            }
            return nhanvien;
        }
        private void loadTaikhoan()
        {
            DataTable taikhoan = loadtable("taikhoan_get");
            DataView dataViewtaikhoan = new DataView(taikhoan);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.DataSource = dataViewtaikhoan;
        }
        private void frmdangki_Load(object sender, EventArgs e)
        {

            comboBox1.DataSource = loadtable("nhanvien_get");
            comboBox1.DisplayMember = "sHoten";
            comboBox1.ValueMember = "PK_NhanvienID";

            comboBox2.DataSource = loadtable("quyen_get");
            comboBox2.DisplayMember = "sTenquyen";
            comboBox2.ValueMember = "PK_QuyenID";
            loadTaikhoan();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            button6.Tag = null;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Enabled = false;
            DataView data = (DataView)dataGridView1.DataSource;
            DataRowView row = data[dataGridView1.CurrentRow.Index];
            if(row["PK_TaikhoanID"] != System.DBNull.Value)
            {
                button6.Tag = row["PK_TaikhoanID"];
                textBox1.Text = (string)row["sTendangnhap"];
                textBox2.Text = (string)row["sMatkhau"];
                foreach (DataRowView rowcb in comboBox1.Items)
                {
                    if (rowcb["PK_NhanvienID"].ToString() == row["FK_NhanvienID"].ToString())
                    {
                        comboBox1.SelectedItem = rowcb;
                        break;
                    }
                }
                foreach (DataRowView rowView in comboBox2.Items)
                {
                    if (rowView["PK_QuyenID"].ToString() == row["FK_QuyenID"].ToString())
                    {
                        comboBox2.SelectedItem = rowView;
                        break;
                    }
                }
            }    
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string mataikhoan = button6.Tag.ToString();
            if(!string.IsNullOrEmpty(mataikhoan))
            {
                string pro_name = "spTaikhoan_Update";
                string tendn = textBox1.Text;
                string manhanvien = comboBox1.SelectedValue.ToString();
                string maquyen = comboBox2.SelectedValue.ToString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(pro_name, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("PK_TaikhoanID", mataikhoan);
                            command.Parameters.AddWithValue("sTendangnhap", tendn);
                            command.Parameters.AddWithValue("FK_NhanvienID", manhanvien);
                            command.Parameters.AddWithValue("FK_QuyenID", maquyen);
                            int row_aff = command.ExecuteNonQuery();
                            if (row_aff > 0)
                            {
                                MessageBox.Show("Sửa thông tin thành công");
                            }
                    }
                    connection.Close();
                }
            } else
            {
                MessageBox.Show("Hãy chọn tài khoản cần sửa");
            }
            loadTaikhoan();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string mataikhoan = button6.Tag.ToString();
            if(!string.IsNullOrEmpty(mataikhoan))
            {
                string proname = "spTaikhoan_Delete";
                if (MessageBox.Show("Bạn có muốn xóa không", "Xóa dữ liệu ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(proname, connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("PK_TaikhoanID", mataikhoan);
                            int row_aff = command.ExecuteNonQuery();
                            if (row_aff > 0)
                            {
                                MessageBox.Show("Đã xóa dữ liệu");
                            }
                        }
                        connection.Close();
                    }
                }
            } else
            {
                MessageBox.Show("Hãy chọn tài khoản để xóa");
            }
            loadTaikhoan();
        }

        private void timkiem_Click(object sender, EventArgs e)
        {
            string dieukienloc = "PK_NhanvienID>0";
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                dieukienloc += string.Format(" AND sTendangnhap LIKE '%{0}%'", textBox1.Text);

            }
            if (!string.IsNullOrEmpty(comboBox1.SelectedValue.ToString()))
            {
                dieukienloc += string.Format(" AND FK_NhanvienID = {0}", comboBox1.SelectedValue.ToString());

            }
            if (!string.IsNullOrEmpty(comboBox2.SelectedValue.ToString()))
            {
                dieukienloc += string.Format(" AND FK_QuyenID = {0}", comboBox2.SelectedValue.ToString());

            }
            DataView dataView = dataGridView1.DataSource as DataView;
            dataView.RowFilter = dieukienloc;
            dataGridView1.DataSource = dataView;
        }

        private void baocao_Click(object sender, EventArgs e)
        {
            FormReport frp = new FormReport();
            frp.showReport("TaiKhoanReport.rpt", "Danh sách tài khoản", "");
            frp.Show();
        }
    }

}
