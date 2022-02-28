
namespace CentralApplication.Forms
{
    partial class frmRegistration_AE
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbPR = new System.Windows.Forms.RadioButton();
            this.rbLPA = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBookletCount = new System.Windows.Forms.NumericUpDown();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCLose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBookletCount)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbLPA);
            this.groupBox1.Controls.Add(this.rbPR);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "&Document Type";
            // 
            // rbPR
            // 
            this.rbPR.AutoSize = true;
            this.rbPR.Checked = true;
            this.rbPR.Location = new System.Drawing.Point(20, 31);
            this.rbPR.Name = "rbPR";
            this.rbPR.Size = new System.Drawing.Size(123, 17);
            this.rbPR.TabIndex = 0;
            this.rbPR.TabStop = true;
            this.rbPR.Text = "Provisionary Reciept";
            this.rbPR.UseVisualStyleBackColor = true;
            // 
            // rbLPA
            // 
            this.rbLPA.AutoSize = true;
            this.rbLPA.Location = new System.Drawing.Point(20, 54);
            this.rbLPA.Name = "rbLPA";
            this.rbLPA.Size = new System.Drawing.Size(147, 17);
            this.rbLPA.TabIndex = 1;
            this.rbLPA.Text = "Life Plan Application Form";
            this.rbLPA.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Booklet Issue Count";
            // 
            // txtBookletCount
            // 
            this.txtBookletCount.Location = new System.Drawing.Point(13, 147);
            this.txtBookletCount.Name = "txtBookletCount";
            this.txtBookletCount.Size = new System.Drawing.Size(199, 21);
            this.txtBookletCount.TabIndex = 2;
            this.txtBookletCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(56, 194);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "&Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCLose
            // 
            this.btnCLose.Location = new System.Drawing.Point(137, 194);
            this.btnCLose.Name = "btnCLose";
            this.btnCLose.Size = new System.Drawing.Size(75, 23);
            this.btnCLose.TabIndex = 4;
            this.btnCLose.Text = "&Close";
            this.btnCLose.UseVisualStyleBackColor = true;
            this.btnCLose.Click += new System.EventHandler(this.btnCLose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(13, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(199, 10);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // frmRegistration_AE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 227);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCLose);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtBookletCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmRegistration_AE";
            this.Text = "frmRegistration_AE";
            this.Load += new System.EventHandler(this.frmRegistration_AE_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBookletCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbLPA;
        private System.Windows.Forms.RadioButton rbPR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtBookletCount;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCLose;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}