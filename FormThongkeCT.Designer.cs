
namespace QLNS
{
    partial class FormThongkeCT
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
            this.components = new System.ComponentModel.Container();
            this.btnThongkeCTTC = new System.Windows.Forms.Button();
            this.ngayhoanthanh = new System.Windows.Forms.DateTimePicker();
            this.ngaykhoicong = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tblcongtrinhBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tblcongtrinhBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.xemthongtin = new System.Windows.Forms.Button();
            this.namkhoicong = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tblcongtrinhBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblcongtrinhBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThongkeCTTC
            // 
            this.btnThongkeCTTC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnThongkeCTTC.Location = new System.Drawing.Point(567, 188);
            this.btnThongkeCTTC.Name = "btnThongkeCTTC";
            this.btnThongkeCTTC.Size = new System.Drawing.Size(108, 42);
            this.btnThongkeCTTC.TabIndex = 10;
            this.btnThongkeCTTC.Text = "Báo cáo";
            this.btnThongkeCTTC.UseVisualStyleBackColor = true;
            this.btnThongkeCTTC.Click += new System.EventHandler(this.btnThongkeCTTC_Click);
            // 
            // ngayhoanthanh
            // 
            this.ngayhoanthanh.CustomFormat = "dd/MM/yyy";
            this.ngayhoanthanh.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.ngayhoanthanh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngayhoanthanh.Location = new System.Drawing.Point(714, 94);
            this.ngayhoanthanh.Name = "ngayhoanthanh";
            this.ngayhoanthanh.Size = new System.Drawing.Size(227, 30);
            this.ngayhoanthanh.TabIndex = 9;
            // 
            // ngaykhoicong
            // 
            this.ngaykhoicong.CustomFormat = "dd/MM/yyy";
            this.ngaykhoicong.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.ngaykhoicong.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngaykhoicong.Location = new System.Drawing.Point(276, 94);
            this.ngaykhoicong.Name = "ngaykhoicong";
            this.ngaykhoicong.Size = new System.Drawing.Size(227, 30);
            this.ngaykhoicong.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label2.Location = new System.Drawing.Point(563, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ngày hoàn thành:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(131, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "Ngày khởi công:";
            // 
            // tblcongtrinhBindingSource1
            // 
            this.tblcongtrinhBindingSource1.DataMember = "tbl_congtrinh";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(58, 236);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1041, 251);
            this.dataGridView1.TabIndex = 11;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "sTencongtrinh";
            this.Column1.HeaderText = "Tên công trình";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 300;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "dNgaycapphep";
            this.Column2.HeaderText = "Ngày cấp phép";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "dNgaykhoicong";
            this.Column3.HeaderText = "Ngày khởi công";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "dNgayhoanthanh";
            this.Column4.HeaderText = "Ngày hoàn thành";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 150;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(362, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(414, 42);
            this.label3.TabIndex = 12;
            this.label3.Text = "Thống kê công trình";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xemthongtin
            // 
            this.xemthongtin.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xemthongtin.Location = new System.Drawing.Point(380, 188);
            this.xemthongtin.Name = "xemthongtin";
            this.xemthongtin.Size = new System.Drawing.Size(108, 42);
            this.xemthongtin.TabIndex = 13;
            this.xemthongtin.Text = "Xem";
            this.xemthongtin.UseVisualStyleBackColor = true;
            this.xemthongtin.Click += new System.EventHandler(this.xemthongtin_Click);
            // 
            // namkhoicong
            // 
            this.namkhoicong.Location = new System.Drawing.Point(276, 143);
            this.namkhoicong.Name = "namkhoicong";
            this.namkhoicong.Size = new System.Drawing.Size(212, 22);
            this.namkhoicong.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(131, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 22);
            this.label4.TabIndex = 15;
            this.label4.Text = "Năm khởi công";
            // 
            // FormThongkeCT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::QLNS.Properties.Resources.afsadfdafdfaf;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1191, 528);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.namkhoicong);
            this.Controls.Add(this.xemthongtin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnThongkeCTTC);
            this.Controls.Add(this.ngayhoanthanh);
            this.Controls.Add(this.ngaykhoicong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormThongkeCT";
            this.Text = "FormThongkeCTThicong";
            this.Load += new System.EventHandler(this.FormThongkeCTThicong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblcongtrinhBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblcongtrinhBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThongkeCTTC;
        private System.Windows.Forms.DateTimePicker ngayhoanthanh;
        private System.Windows.Forms.DateTimePicker ngaykhoicong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource tblcongtrinhBindingSource;
        private System.Windows.Forms.BindingSource tblcongtrinhBindingSource1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button xemthongtin;
        private System.Windows.Forms.TextBox namkhoicong;
        private System.Windows.Forms.Label label4;
    }
}