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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnAdd = new Button();
            txtID = new TextBox();
            txtAnimalName = new TextBox();
            txtAnimalSpecie = new TextBox();
            txtAnimalAge = new TextBox();
            txtAnimalRecovery = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvAnimalsOutput).BeginInit();
            SuspendLayout();
            // 
            // dgvAnimalsOutput
            // 
            dgvAnimalsOutput.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAnimalsOutput.Location = new Point(357, 74);
            dgvAnimalsOutput.Margin = new Padding(3, 2, 3, 2);
            dgvAnimalsOutput.Name = "dgvAnimalsOutput";
            dgvAnimalsOutput.RowHeadersWidth = 51;
            dgvAnimalsOutput.Size = new Size(802, 396);
            dgvAnimalsOutput.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 62);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 1;
            label1.Text = "ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 128);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 2;
            label2.Text = "Animal Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(42, 195);
            label3.Name = "label3";
            label3.Size = new Size(87, 15);
            label3.TabIndex = 3;
            label3.Text = "Animal Species";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(42, 268);
            label4.Name = "label4";
            label4.Size = new Size(28, 15);
            label4.TabIndex = 4;
            label4.Text = "Age";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(42, 324);
            label5.Name = "label5";
            label5.Size = new Size(87, 15);
            label5.TabIndex = 5;
            label5.Text = "Recovery Score";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(35, 392);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // txtID
            // 
            txtID.Location = new Point(195, 62);
            txtID.Name = "txtID";
            txtID.Size = new Size(100, 23);
            txtID.TabIndex = 7;
            // 
            // txtAnimalName
            // 
            txtAnimalName.Location = new Point(195, 128);
            txtAnimalName.Name = "txtAnimalName";
            txtAnimalName.Size = new Size(100, 23);
            txtAnimalName.TabIndex = 8;
            // 
            // txtAnimalSpecie
            // 
            txtAnimalSpecie.Location = new Point(195, 192);
            txtAnimalSpecie.Name = "txtAnimalSpecie";
            txtAnimalSpecie.Size = new Size(100, 23);
            txtAnimalSpecie.TabIndex = 9;
            // 
            // txtAnimalAge
            // 
            txtAnimalAge.Location = new Point(195, 265);
            txtAnimalAge.Name = "txtAnimalAge";
            txtAnimalAge.Size = new Size(100, 23);
            txtAnimalAge.TabIndex = 10;
            // 
            // txtAnimalRecovery
            // 
            txtAnimalRecovery.Location = new Point(195, 333);
            txtAnimalRecovery.Name = "txtAnimalRecovery";
            txtAnimalRecovery.Size = new Size(100, 23);
            txtAnimalRecovery.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1362, 512);
            Controls.Add(txtAnimalRecovery);
            Controls.Add(txtAnimalAge);
            Controls.Add(txtAnimalSpecie);
            Controls.Add(txtAnimalName);
            Controls.Add(txtID);
            Controls.Add(btnAdd);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvAnimalsOutput);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAnimalsOutput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvAnimalsOutput;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnAdd;
        private TextBox txtID;
        private TextBox txtAnimalName;
        private TextBox txtAnimalSpecie;
        private TextBox txtAnimalAge;
        private TextBox txtAnimalRecovery;
    }
}
