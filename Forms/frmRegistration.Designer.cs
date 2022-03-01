
namespace CentralApplication.Forms
{
    partial class frmRegistration
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
            this.lvRecord = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lvRecord
            // 
            this.lvRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRecord.GridLines = true;
            this.lvRecord.HideSelection = false;
            this.lvRecord.Location = new System.Drawing.Point(5, 5);
            this.lvRecord.Name = "lvRecord";
            this.lvRecord.Size = new System.Drawing.Size(790, 440);
            this.lvRecord.TabIndex = 0;
            this.lvRecord.UseCompatibleStateImageBehavior = false;
            // 
            // frmRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lvRecord);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmRegistration";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Tag = "Registration";
            this.Text = "Registration List";
            this.Load += new System.EventHandler(this.frmRegistration_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvRecord;
    }
}