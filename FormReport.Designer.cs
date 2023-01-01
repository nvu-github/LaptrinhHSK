
namespace QLNS
{
    partial class FormReport
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
            this.CrpReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CrpReport
            // 
            this.CrpReport.ActiveViewIndex = -1;
            this.CrpReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrpReport.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrpReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrpReport.Location = new System.Drawing.Point(0, 0);
            this.CrpReport.Name = "CrpReport";
            this.CrpReport.Size = new System.Drawing.Size(716, 423);
            this.CrpReport.TabIndex = 0;
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 423);
            this.Controls.Add(this.CrpReport);
            this.Name = "FormReport";
            this.Text = "FormReport";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer CrpReport;
    }
}