
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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        public int k = 1;
        public static string quyen;
        private void FrmMain_Load(object sender, EventArgs e)
        {
           /* menuItem14.Enabled = false;
            menuItem5.Enabled = false;
            menuItem14.Enabled = false;
            menuItem5.Enabled = false;
            menuItemdmk.Enabled = false;
            toolStripMenuItem1.Enabled = false;
            phânCôngToolStripMenuItem.Enabled = false;
            if (quyen == "Admin")
            {
                menuItem14.Enabled = true;
                menuItem5.Enabled = true;
                toolStripMenuItem1.Enabled = true;
                phânCôngToolStripMenuItem.Enabled = true;
                menuItemdmk.Enabled = true;
                menuItem4.Text = "Đăng xuất";
            }
            else if (quyen == "User")
            {
                phânCôngToolStripMenuItem.Enabled = true;
                menuItemdmk.Enabled = true;
                menuItem4.Text = "Đăng xuất";
            }*/
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            frmdangnhap dn = new frmdangnhap();
            this.Hide();
            dn.ShowDialog();
            dn.Show();
        }

        private void menuItemdmk_Click_1(object sender, EventArgs e)
        {
            frmdoimatkhau fdm = new frmdoimatkhau();
            panel_show.Show();
            panel_show.Controls.Clear();
            fdm.TopLevel = false;
            fdm.Dock = DockStyle.Fill;
            panel_show.Controls.Add(fdm);
            fdm.Show();

        }

        private void menuItem15_Click(object sender, EventArgs e)
        {
            frmphongban fpb = new frmphongban();
            panel_show.Show();
            panel_show.Controls.Clear();
            fpb.TopLevel = false;
            fpb.Dock = DockStyle.Fill;
            panel_show.Controls.Add(fpb);
            fpb.Show();
        }
        private void menuItem5_Click(object sender, EventArgs e)
        {
            frmdangki b = new frmdangki();
            panel_show.Show();
            panel_show.Controls.Clear();
            b.TopLevel = false;
            b.Dock = DockStyle.Fill;
            panel_show.Controls.Add(b);
            b.Show();
        }

        private void phânCôngNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPhancong f = new FormPhancong();
            f.quyen = quyen;
            panel_show.Show();
            panel_show.Controls.Clear();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            panel_show.Controls.Add(f);
            f.Show();
        }

        private void côngTrìnhToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormThongkeCT frmtkct = new FormThongkeCT();
            panel_show.Show();
            panel_show.Controls.Clear();
            frmtkct.TopLevel = false;
            frmtkct.Dock = DockStyle.Fill;
            panel_show.Controls.Add(frmtkct);
            frmtkct.Show();
        }

        private void contrinhoption_Click(object sender, EventArgs e)
        {
            FormCongTrinh frmCongTrinh = new FormCongTrinh();
            panel_show.Show();
            panel_show.Controls.Clear();
            frmCongTrinh.TopLevel = false;
            frmCongTrinh.Dock = DockStyle.Fill;
            panel_show.Controls.Add(frmCongTrinh);
            frmCongTrinh.Show();
        }

        private void nhanvienoption_Click(object sender, EventArgs e)
        {
            FormNhanVien formNhanVien = new FormNhanVien();
            panel_show.Show();
            panel_show.Controls.Clear();
            formNhanVien.TopLevel = false;
            formNhanVien.Dock = DockStyle.Fill;
            panel_show.Controls.Add(formNhanVien);
            formNhanVien.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTKNhanvien formNhanVien = new FormTKNhanvien();
            panel_show.Show();
            panel_show.Controls.Clear();
            formNhanVien.TopLevel = false;
            formNhanVien.Dock = DockStyle.Fill;
            panel_show.Controls.Add(formNhanVien);
            formNhanVien.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có chắc muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dg == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
