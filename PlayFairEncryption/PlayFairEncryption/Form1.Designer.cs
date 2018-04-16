using System;
namespace PlayFairEncryption
{
    partial class Form1
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
            this.keywordbtn = new System.Windows.Forms.Button();
            this.keywordtxt = new System.Windows.Forms.TextBox();
            this.ciphersrctxt = new System.Windows.Forms.TextBox();
            this.cipherbtn = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.resulttxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.writechk = new System.Windows.Forms.CheckBox();
            this.readbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // keywordbtn
            // 
            this.keywordbtn.Location = new System.Drawing.Point(263, 135);
            this.keywordbtn.Name = "keywordbtn";
            this.keywordbtn.Size = new System.Drawing.Size(119, 23);
            this.keywordbtn.TabIndex = 0;
            this.keywordbtn.Text = "Enter Keyword";
            this.keywordbtn.UseVisualStyleBackColor = true;
            this.keywordbtn.Click += new System.EventHandler(this.keywordbtn_Click);
            // 
            // keywordtxt
            // 
            this.keywordtxt.Location = new System.Drawing.Point(273, 88);
            this.keywordtxt.Name = "keywordtxt";
            this.keywordtxt.Size = new System.Drawing.Size(100, 20);
            this.keywordtxt.TabIndex = 1;
            // 
            // ciphersrctxt
            // 
            this.ciphersrctxt.Location = new System.Drawing.Point(145, 212);
            this.ciphersrctxt.Multiline = true;
            this.ciphersrctxt.Name = "ciphersrctxt";
            this.ciphersrctxt.Size = new System.Drawing.Size(352, 63);
            this.ciphersrctxt.TabIndex = 2;
            // 
            // cipherbtn
            // 
            this.cipherbtn.Location = new System.Drawing.Point(263, 409);
            this.cipherbtn.Name = "cipherbtn";
            this.cipherbtn.Size = new System.Drawing.Size(119, 23);
            this.cipherbtn.TabIndex = 3;
            this.cipherbtn.Text = "Choose mode";
            this.cipherbtn.UseVisualStyleBackColor = true;
            this.cipherbtn.Click += new System.EventHandler(this.cipherbtn_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Encrypt",
            "Decrypt"});
            this.comboBox1.Location = new System.Drawing.Point(40, 87);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // resulttxt
            // 
            this.resulttxt.Location = new System.Drawing.Point(145, 308);
            this.resulttxt.Multiline = true;
            this.resulttxt.Name = "resulttxt";
            this.resulttxt.Size = new System.Drawing.Size(352, 63);
            this.resulttxt.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Source:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 308);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Result:";
            // 
            // writechk
            // 
            this.writechk.AutoSize = true;
            this.writechk.Location = new System.Drawing.Point(504, 139);
            this.writechk.Name = "writechk";
            this.writechk.Size = new System.Drawing.Size(91, 17);
            this.writechk.TabIndex = 8;
            this.writechk.Text = "Write to a file";
            this.writechk.UseVisualStyleBackColor = true;
            // 
            // readbtn
            // 
            this.readbtn.Location = new System.Drawing.Point(504, 21);
            this.readbtn.Name = "readbtn";
            this.readbtn.Size = new System.Drawing.Size(91, 23);
            this.readbtn.TabIndex = 9;
            this.readbtn.Text = "Read from a file";
            this.readbtn.UseVisualStyleBackColor = true;
            this.readbtn.Click += new System.EventHandler(this.readbtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 485);
            this.Controls.Add(this.readbtn);
            this.Controls.Add(this.writechk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resulttxt);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.cipherbtn);
            this.Controls.Add(this.ciphersrctxt);
            this.Controls.Add(this.keywordtxt);
            this.Controls.Add(this.keywordbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Playfair Encryption";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button keywordbtn;
        private System.Windows.Forms.TextBox keywordtxt;
        private System.Windows.Forms.TextBox ciphersrctxt;
        private System.Windows.Forms.Button cipherbtn;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox resulttxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox writechk;
        private System.Windows.Forms.Button readbtn;
    }
}

