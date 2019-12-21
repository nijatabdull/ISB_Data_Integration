namespace ISB_Service
{
    partial class ErrorLogger
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
            this.errorLoggerGrid = new System.Windows.Forms.DataGridView();
            this.back_btn = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorLoggerGrid)).BeginInit();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorLoggerGrid
            // 
            this.errorLoggerGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.errorLoggerGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorLoggerGrid.Location = new System.Drawing.Point(3, 16);
            this.errorLoggerGrid.Name = "errorLoggerGrid";
            this.errorLoggerGrid.Size = new System.Drawing.Size(948, 454);
            this.errorLoggerGrid.TabIndex = 0;
            this.errorLoggerGrid.TabStop = false;
            this.errorLoggerGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.errorLoggerGrid_CellClick);
            this.errorLoggerGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.errorLoggerGrid_CellFormatting);
            // 
            // back_btn
            // 
            this.back_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back_btn.Location = new System.Drawing.Point(12, 12);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(141, 54);
            this.back_btn.TabIndex = 1;
            this.back_btn.Text = "Back";
            this.back_btn.UseVisualStyleBackColor = true;
            this.back_btn.Click += new System.EventHandler(this.back_btn_Click);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.errorLoggerGrid);
            this.groupBox.Location = new System.Drawing.Point(12, 72);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(954, 473);
            this.groupBox.TabIndex = 3;
            this.groupBox.TabStop = false;
            // 
            // ErrorLogger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 557);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.back_btn);
            this.Name = "ErrorLogger";
            this.Text = "ErrorLogger";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ErrorLogger_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.errorLoggerGrid)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView errorLoggerGrid;
        private System.Windows.Forms.Button back_btn;
        private System.Windows.Forms.GroupBox groupBox;
    }
}