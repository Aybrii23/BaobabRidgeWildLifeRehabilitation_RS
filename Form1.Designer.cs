namespace BaobabRidgeWildlifeRehabilitation_RS
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvAnimalsOutput = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvAnimalsOutput).BeginInit();
            SuspendLayout();
            // 
            // dgvAnimalsOutput
            // 
            dgvAnimalsOutput.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAnimalsOutput.Location = new Point(201, 99);
            dgvAnimalsOutput.Name = "dgvAnimalsOutput";
            dgvAnimalsOutput.RowHeadersWidth = 51;
            dgvAnimalsOutput.Size = new Size(1123, 528);
            dgvAnimalsOutput.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1556, 682);
            Controls.Add(dgvAnimalsOutput);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAnimalsOutput).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvAnimalsOutput;
    }
}
