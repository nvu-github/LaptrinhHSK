
namespace QLNS
{
    partial class FormThongkePhongban
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
            this.btnThongkePB = new System.Windows.Forms.Button();
            this.cbTKPhongban = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgThongkePhongban = new System.Windows.Forms.DataGridView();
            this.tblphongbanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblnhanvienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pKNhanvienIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sHotenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dNgaysinhDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bGioitinhDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDiachiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDienthoaiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sChucvuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fKPhongbanIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgThongkePhongban)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblphongbanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblnhanvienBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThongkePB
            // 
            this.btnThongkePB.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnThongkePB.Location = new System.Drawing.Point(517, 41);
            this.btnThongkePB.Name = "btnThongkePB";
            this.btnThongkePB.Size = new System.Drawing.Size(145, 53);
            this.btnThongkePB.TabIndex = 5;
            this.btnThongkePB.Text = "Thống kê";
            this.btnThongkePB.UseVisualStyleBackColor = true;
            // 
            // cbTKPhongban
            // 
            this.cbTKPhongban.DataSource = this.tblphongbanBindingSource;
            this.cbTKPhongban.DisplayMember = "sTenphong";
            this.cbTKPhongban.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cbTKPhongban.FormattingEnabled = true;
            this.cbTKPhongban.Location = new System.Drawing.Point(234, 53);
            this.cbTKPhongban.Name = "cbTKPhongban";
            this.cbTKPhongban.Size = new System.Drawing.Size(177, 30);
            this.cbTKPhongban.TabIndex = 4;
            this.cbTKPhongban.ValueMember = "PK_PhongbanID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tên phòng ban";
            // 
            // dgThongkePhongban
            // 
            this.dgThongkePhongban.AutoGenerateColumns = false;
            this.dgThongkePhongban.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgThongkePhongban.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pKNhanvienIDDataGridViewTextBoxColumn,
            this.sHotenDataGridViewTextBoxColumn,
            this.dNgaysinhDataGridViewTextBoxColumn,
            this.bGioitinhDataGridViewTextBoxColumn,
            this.sDiachiDataGridViewTextBoxColumn,
            this.sDienthoaiDataGridViewTextBoxColumn,
            this.sChucvuDataGridViewTextBoxColumn,
            this.fKPhongbanIDDataGridViewTextBoxColumn});
            this.dgThongkePhongban.DataSource = this.tblnhanvienBindingSource;
            this.dgThongkePhongban.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgThongkePhongban.Location = new System.Drawing.Point(0, 137);
            this.dgThongkePhongban.Name = "dgThongkePhongban";
            this.dgThongkePhongban.RowHeadersWidth = 51;
            this.dgThongkePhongban.RowTemplate.Height = 24;
            this.dgThongkePhongban.Size = new System.Drawing.Size(800, 313);
            this.dgThongkePhongban.TabIndex = 6;
            // 
            // bTL_HSKDataSetTenPhongBan
            // 
            // 
            // tblphongbanBindingSource
            // 
            this.tblphongbanBindingSource.DataMember = "tbl_phongban";
            // 
            // tbl_phongbanTableAdapter
            // 
            // 
            // bTL_HSKDataSetNhanVienPhongBan
            // 
            // 
            // tblnhanvienBindingSource
            // 
            this.tblnhanvienBindingSource.DataMember = "tbl_nhanvien";
            // 
            // tbl_nhanvienTableAdapter
            // 
            // 
            // pKNhanvienIDDataGridViewTextBoxColumn
            // 
            this.pKNhanvienIDDataGridViewTextBoxColumn.DataPropertyName = "PK_NhanvienID";
            this.pKNhanvienIDDataGridViewTextBoxColumn.HeaderText = "PK_NhanvienID";
            this.pKNhanvienIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.pKNhanvienIDDataGridViewTextBoxColumn.Name = "pKNhanvienIDDataGridViewTextBoxColumn";
            this.pKNhanvienIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // sHotenDataGridViewTextBoxColumn
            // 
            this.sHotenDataGridViewTextBoxColumn.DataPropertyName = "sHoten";
            this.sHotenDataGridViewTextBoxColumn.HeaderText = "sHoten";
            this.sHotenDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.sHotenDataGridViewTextBoxColumn.Name = "sHotenDataGridViewTextBoxColumn";
            this.sHotenDataGridViewTextBoxColumn.Width = 125;
            // 
            // dNgaysinhDataGridViewTextBoxColumn
            // 
            this.dNgaysinhDataGridViewTextBoxColumn.DataPropertyName = "dNgaysinh";
            this.dNgaysinhDataGridViewTextBoxColumn.HeaderText = "dNgaysinh";
            this.dNgaysinhDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dNgaysinhDataGridViewTextBoxColumn.Name = "dNgaysinhDataGridViewTextBoxColumn";
            this.dNgaysinhDataGridViewTextBoxColumn.Width = 125;
            // 
            // bGioitinhDataGridViewTextBoxColumn
            // 
            this.bGioitinhDataGridViewTextBoxColumn.DataPropertyName = "bGioitinh";
            this.bGioitinhDataGridViewTextBoxColumn.HeaderText = "bGioitinh";
            this.bGioitinhDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.bGioitinhDataGridViewTextBoxColumn.Name = "bGioitinhDataGridViewTextBoxColumn";
            this.bGioitinhDataGridViewTextBoxColumn.Width = 125;
            // 
            // sDiachiDataGridViewTextBoxColumn
            // 
            this.sDiachiDataGridViewTextBoxColumn.DataPropertyName = "sDiachi";
            this.sDiachiDataGridViewTextBoxColumn.HeaderText = "sDiachi";
            this.sDiachiDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.sDiachiDataGridViewTextBoxColumn.Name = "sDiachiDataGridViewTextBoxColumn";
            this.sDiachiDataGridViewTextBoxColumn.Width = 125;
            // 
            // sDienthoaiDataGridViewTextBoxColumn
            // 
            this.sDienthoaiDataGridViewTextBoxColumn.DataPropertyName = "sDienthoai";
            this.sDienthoaiDataGridViewTextBoxColumn.HeaderText = "sDienthoai";
            this.sDienthoaiDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.sDienthoaiDataGridViewTextBoxColumn.Name = "sDienthoaiDataGridViewTextBoxColumn";
            this.sDienthoaiDataGridViewTextBoxColumn.Width = 125;
            // 
            // sChucvuDataGridViewTextBoxColumn
            // 
            this.sChucvuDataGridViewTextBoxColumn.DataPropertyName = "sChucvu";
            this.sChucvuDataGridViewTextBoxColumn.HeaderText = "sChucvu";
            this.sChucvuDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.sChucvuDataGridViewTextBoxColumn.Name = "sChucvuDataGridViewTextBoxColumn";
            this.sChucvuDataGridViewTextBoxColumn.Width = 125;
            // 
            // fKPhongbanIDDataGridViewTextBoxColumn
            // 
            this.fKPhongbanIDDataGridViewTextBoxColumn.DataPropertyName = "FK_PhongbanID";
            this.fKPhongbanIDDataGridViewTextBoxColumn.HeaderText = "FK_PhongbanID";
            this.fKPhongbanIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fKPhongbanIDDataGridViewTextBoxColumn.Name = "fKPhongbanIDDataGridViewTextBoxColumn";
            this.fKPhongbanIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // FormThongkePhongban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgThongkePhongban);
            this.Controls.Add(this.btnThongkePB);
            this.Controls.Add(this.cbTKPhongban);
            this.Controls.Add(this.label1);
            this.Name = "FormThongkePhongban";
            this.Text = "FormThongkePhongban";
            this.Load += new System.EventHandler(this.FormThongkePhongban_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgThongkePhongban)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblphongbanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblnhanvienBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThongkePB;
        private System.Windows.Forms.ComboBox cbTKPhongban;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgThongkePhongban;
        private System.Windows.Forms.BindingSource tblphongbanBindingSource;
        private System.Windows.Forms.BindingSource tblnhanvienBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn pKNhanvienIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sHotenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dNgaysinhDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bGioitinhDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDiachiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDienthoaiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sChucvuDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fKPhongbanIDDataGridViewTextBoxColumn;
    }
}