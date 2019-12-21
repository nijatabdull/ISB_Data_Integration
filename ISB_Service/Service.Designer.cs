namespace ISB_Service
{
    partial class Service
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
            this.error_btn = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.verbal_grd = new System.Windows.Forms.DataGridView();
            this.incident_grd = new System.Windows.Forms.DataGridView();
            this.claim_grd = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.payment_grd = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.verbal_grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.incident_grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.claim_grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.payment_grd)).BeginInit();
            this.SuspendLayout();
            // 
            // error_btn
            // 
            this.error_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.error_btn.Location = new System.Drawing.Point(1037, 7);
            this.error_btn.Name = "error_btn";
            this.error_btn.Size = new System.Drawing.Size(95, 36);
            this.error_btn.TabIndex = 0;
            this.error_btn.Text = "Errors";
            this.error_btn.UseVisualStyleBackColor = true;
            this.error_btn.Click += new System.EventHandler(this.Error_btn_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.BackColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(1119, 9);
            this.lblError.Name = "lblError";
            this.lblError.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.lblError.Size = new System.Drawing.Size(6, 13);
            this.lblError.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1137, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // verbal_grd
            // 
            this.verbal_grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.verbal_grd.Location = new System.Drawing.Point(12, 63);
            this.verbal_grd.Name = "verbal_grd";
            this.verbal_grd.Size = new System.Drawing.Size(1107, 110);
            this.verbal_grd.TabIndex = 5;
            // 
            // incident_grd
            // 
            this.incident_grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.incident_grd.Location = new System.Drawing.Point(12, 213);
            this.incident_grd.Name = "incident_grd";
            this.incident_grd.Size = new System.Drawing.Size(1107, 120);
            this.incident_grd.TabIndex = 6;
            // 
            // claim_grd
            // 
            this.claim_grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.claim_grd.Location = new System.Drawing.Point(12, 382);
            this.claim_grd.Name = "claim_grd";
            this.claim_grd.Size = new System.Drawing.Size(1107, 114);
            this.claim_grd.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Verbal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Incident";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 359);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Claim";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 511);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Payment";
            // 
            // payment_grd
            // 
            this.payment_grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.payment_grd.Location = new System.Drawing.Point(12, 534);
            this.payment_grd.Name = "payment_grd";
            this.payment_grd.Size = new System.Drawing.Size(1107, 88);
            this.payment_grd.TabIndex = 12;
            // 
            // Service
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 634);
            this.Controls.Add(this.payment_grd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.claim_grd);
            this.Controls.Add(this.incident_grd);
            this.Controls.Add(this.verbal_grd);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.error_btn);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Service";
            this.Text = "Service";
            this.Load += new System.EventHandler(this.Service_Load);
            ((System.ComponentModel.ISupportInitialize)(this.verbal_grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.incident_grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.claim_grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.payment_grd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button error_btn;
        public System.Windows.Forms.Label lblError;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DataGridView verbal_grd;
        private System.Windows.Forms.DataGridView incident_grd;
        private System.Windows.Forms.DataGridView claim_grd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView payment_grd;
    }
}

