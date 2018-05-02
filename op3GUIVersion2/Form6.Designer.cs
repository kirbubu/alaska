namespace CECS_328_Assignment_4
{
    partial class OP3Form
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
            this.op3 = new System.Windows.Forms.Button();
            this.userN = new System.Windows.Forms.TextBox();
            this.op3Output = new System.Windows.Forms.Label();
            this.outputLabel = new System.Windows.Forms.Label();
            this.startNumberBox = new System.Windows.Forms.TextBox();
            this.subsetSizeBox = new System.Windows.Forms.TextBox();
            this.userIthBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbo = new System.Windows.Forms.TextBox();
            this.result = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // op3
            // 
            this.op3.Location = new System.Drawing.Point(228, 40);
            this.op3.Name = "op3";
            this.op3.Size = new System.Drawing.Size(147, 23);
            this.op3.TabIndex = 0;
            this.op3.Text = "Show subset";
            this.op3.UseVisualStyleBackColor = true;
            this.op3.Click += new System.EventHandler(this.button1_Click);
            // 
            // userN
            // 
            this.userN.Location = new System.Drawing.Point(27, 40);
            this.userN.Name = "userN";
            this.userN.Size = new System.Drawing.Size(169, 22);
            this.userN.TabIndex = 1;
            this.userN.TextChanged += new System.EventHandler(this.userN_TextChanged);
            // 
            // op3Output
            // 
            this.op3Output.AutoSize = true;
            this.op3Output.Location = new System.Drawing.Point(60, 117);
            this.op3Output.Name = "op3Output";
            this.op3Output.Size = new System.Drawing.Size(0, 17);
            this.op3Output.TabIndex = 2;
            this.op3Output.Click += new System.EventHandler(this.label1_Click);
            // 
            // outputLabel
            // 
            this.outputLabel.Location = new System.Drawing.Point(247, 142);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(139, 60);
            this.outputLabel.TabIndex = 3;
            this.outputLabel.Text = "Output";
            this.outputLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // startNumberBox
            // 
            this.startNumberBox.Location = new System.Drawing.Point(27, 98);
            this.startNumberBox.Name = "startNumberBox";
            this.startNumberBox.Size = new System.Drawing.Size(169, 22);
            this.startNumberBox.TabIndex = 4;
            // 
            // subsetSizeBox
            // 
            this.subsetSizeBox.Location = new System.Drawing.Point(27, 155);
            this.subsetSizeBox.Name = "subsetSizeBox";
            this.subsetSizeBox.Size = new System.Drawing.Size(169, 22);
            this.subsetSizeBox.TabIndex = 5;
            // 
            // userIthBox
            // 
            this.userIthBox.Location = new System.Drawing.Point(27, 208);
            this.userIthBox.Name = "userIthBox";
            this.userIthBox.Size = new System.Drawing.Size(169, 22);
            this.userIthBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Starting number";
            this.label1.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ending Number(n)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Subset Size";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ith Number";
            // 
            // tbo
            // 
            this.tbo.Location = new System.Drawing.Point(239, 88);
            this.tbo.Multiline = true;
            this.tbo.Name = "tbo";
            this.tbo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbo.Size = new System.Drawing.Size(271, 222);
            this.tbo.TabIndex = 11;
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.Location = new System.Drawing.Point(27, 256);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(46, 17);
            this.result.TabIndex = 12;
            this.result.Text = "label5";
            // 
            // OP3Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 553);
            this.Controls.Add(this.result);
            this.Controls.Add(this.tbo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userIthBox);
            this.Controls.Add(this.subsetSizeBox);
            this.Controls.Add(this.startNumberBox);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.op3Output);
            this.Controls.Add(this.userN);
            this.Controls.Add(this.op3);
            this.Name = "OP3Form";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button op3;
        private System.Windows.Forms.TextBox userN;
        private System.Windows.Forms.Label op3Output;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.TextBox startNumberBox;
        private System.Windows.Forms.TextBox subsetSizeBox;
        private System.Windows.Forms.TextBox userIthBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox tbo;
        private System.Windows.Forms.Label result;
    }
}

