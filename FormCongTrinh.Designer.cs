﻿
namespace QLNS
{
    partial class FormCongTrinh
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ngaykhoicong = new System.Windows.Forms.DateTimePicker();
            this.ngayhoanthanh = new System.Windows.Forms.DateTimePicker();
            this.ngaycapphep = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCongtrinh = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBoqua = new System.Windows.Forms.Button();
            this.insert = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ncp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nkc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nht = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(398, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(414, 42);
            this.label2.TabIndex = 1;
            this.label2.Text = "Quản lý công trình";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.ngaykhoicong);
            this.groupBox1.Controls.Add(this.ngayhoanthanh);
            this.groupBox1.Controls.Add(this.ngaycapphep);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCongtrinh);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(65, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1041, 111);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin công trình";
            // 
            // ngaykhoicong
            // 
            this.ngaykhoicong.CustomFormat = "dd/MM/yyyy";
            this.ngaykhoicong.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.ngaykhoicong.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngaykhoicong.Location = new System.Drawing.Point(173, 64);
            this.ngaykhoicong.Name = "ngaykhoicong";
            this.ngaykhoicong.Size = new System.Drawing.Size(273, 30);
            this.ngaykhoicong.TabIndex = 27;
            // 
            // ngayhoanthanh
            // 
            this.ngayhoanthanh.CustomFormat = "dd/MM/yyyy";
            this.ngayhoanthanh.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.ngayhoanthanh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngayhoanthanh.Location = new System.Drawing.Point(705, 64);
            this.ngayhoanthanh.Name = "ngayhoanthanh";
            this.ngayhoanthanh.Size = new System.Drawing.Size(289, 30);
            this.ngayhoanthanh.TabIndex = 26;
            // 
            // ngaycapphep
            // 
            this.ngaycapphep.CustomFormat = "dd/MM/yyyy";
            this.ngaycapphep.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.ngaycapphep.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngaycapphep.Location = new System.Drawing.Point(705, 18);
            this.ngaycapphep.Name = "ngaycapphep";
            this.ngaycapphep.Size = new System.Drawing.Size(289, 30);
            this.ngaycapphep.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(575, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 17);
            this.label8.TabIndex = 24;
            this.label8.Text = "Ngày hoàn thành";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "Ngày khởi công";
            // 
            // txtCongtrinh
            // 
            this.txtCongtrinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCongtrinh.Location = new System.Drawing.Point(173, 25);
            this.txtCongtrinh.Name = "txtCongtrinh";
            this.txtCongtrinh.Size = new System.Drawing.Size(273, 23);
            this.txtCongtrinh.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(575, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ngày cấp phép";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(56, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên công trình";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnBoqua);
            this.groupBox2.Controls.Add(this.insert);
            this.groupBox2.Controls.Add(this.btnXoa);
            this.groupBox2.Controls.Add(this.btnSua);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(65, 194);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1041, 79);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng";
            // 
            // btnBoqua
            // 
            this.btnBoqua.Image = global::QLNS.Properties.Resources.button1_Image;
            this.btnBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBoqua.Location = new System.Drawing.Point(689, 28);
            this.btnBoqua.Name = "btnBoqua";
            this.btnBoqua.Size = new System.Drawing.Size(107, 35);
            this.btnBoqua.TabIndex = 6;
            this.btnBoqua.Text = "Bỏ qua";
            this.btnBoqua.UseVisualStyleBackColor = true;
            this.btnBoqua.Click += new System.EventHandler(this.btnBoqua_Click);
            // 
            // insert
            // 
            this.insert.Image = global::QLNS.Properties.Resources.add_user;
            this.insert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.insert.Location = new System.Drawing.Point(206, 25);
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(107, 37);
            this.insert.TabIndex = 4;
            this.insert.Text = "Thêm";
            this.insert.UseVisualStyleBackColor = true;
            this.insert.Click += new System.EventHandler(this.insert_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Image = global::QLNS.Properties.Resources.exiit;
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(521, 25);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(107, 38);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Image = global::QLNS.Properties.Resources.Danh_muc;
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(354, 24);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(107, 38);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tct,
            this.ncp,
            this.nkc,
            this.nht});
            this.dataGridView1.Location = new System.Drawing.Point(65, 303);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1041, 213);
            this.dataGridView1.TabIndex = 16;
            // 
            // tct
            // 
            this.tct.DataPropertyName = "sTencongtrinh";
            this.tct.HeaderText = "Tên công trình";
            this.tct.MinimumWidth = 6;
            this.tct.Name = "tct";
            this.tct.Width = 300;
            // 
            // ncp
            // 
            this.ncp.DataPropertyName = "dNgaycapphep";
            this.ncp.HeaderText = "Ngày cấp phép";
            this.ncp.MinimumWidth = 6;
            this.ncp.Name = "ncp";
            this.ncp.Width = 150;
            // 
            // nkc
            // 
            this.nkc.DataPropertyName = "dNgaykhoicong";
            this.nkc.HeaderText = "Ngày khởi công";
            this.nkc.MinimumWidth = 6;
            this.nkc.Name = "nkc";
            this.nkc.Width = 150;
            // 
            // nht
            // 
            this.nht.DataPropertyName = "dNgayhoanthanh";
            this.nht.HeaderText = "Ngày hoàn thành";
            this.nht.MinimumWidth = 6;
            this.nht.Name = "nht";
            this.nht.Width = 150;
            // 
            // FormCongTrinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::QLNS.Properties.Resources.afsadfdafdfaf;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1191, 528);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCongTrinh";
            this.Text = "FormCongTrinh";
            this.Load += new System.EventHandler(this.FormCongTrinh_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCongtrinh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBoqua;
        private System.Windows.Forms.Button insert;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tct;
        private System.Windows.Forms.DataGridViewTextBoxColumn ncp;
        private System.Windows.Forms.DataGridViewTextBoxColumn nkc;
        private System.Windows.Forms.DataGridViewTextBoxColumn nht;
        private System.Windows.Forms.DateTimePicker ngaykhoicong;
        private System.Windows.Forms.DateTimePicker ngayhoanthanh;
        private System.Windows.Forms.DateTimePicker ngaycapphep;
    }
}