
namespace CodeSandBox
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
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.filePathLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.readAccesscheckBox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.untrustedAssemblyTxt = new System.Windows.Forms.TextBox();
            this.untrustedAssmblyLbl = new System.Windows.Forms.Label();
            this.executeButton = new System.Windows.Forms.Button();
            this.untrustedClassLbl = new System.Windows.Forms.Label();
            this.untrustedClassTxt = new System.Windows.Forms.TextBox();
            this.entryPointTxt = new System.Windows.Forms.TextBox();
            this.entryPointLbl = new System.Windows.Forms.Label();
            this.parameterLbl = new System.Windows.Forms.Label();
            this.parameterTxt = new System.Windows.Forms.TextBox();
            this.writeAccesscheckBox = new System.Windows.Forms.CheckBox();
            this.executionAccesscheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Location = new System.Drawing.Point(156, 25);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new System.Drawing.Size(305, 20);
            this.filePathTextBox.TabIndex = 0;
            // 
            // filePathLabel
            // 
            this.filePathLabel.AutoSize = true;
            this.filePathLabel.Location = new System.Drawing.Point(90, 28);
            this.filePathLabel.Name = "filePathLabel";
            this.filePathLabel.Size = new System.Drawing.Size(48, 13);
            this.filePathLabel.TabIndex = 1;
            this.filePathLabel.Text = "File Path";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Restrictions";
            // 
            // readAccesscheckBox
            // 
            this.readAccesscheckBox.AutoSize = true;
            this.readAccesscheckBox.Location = new System.Drawing.Point(132, 237);
            this.readAccesscheckBox.Name = "readAccesscheckBox";
            this.readAccesscheckBox.Size = new System.Drawing.Size(90, 17);
            this.readAccesscheckBox.TabIndex = 3;
            this.readAccesscheckBox.Text = "Read Access";
            this.readAccesscheckBox.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(487, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // untrustedAssemblyTxt
            // 
            this.untrustedAssemblyTxt.Location = new System.Drawing.Point(150, 67);
            this.untrustedAssemblyTxt.Name = "untrustedAssemblyTxt";
            this.untrustedAssemblyTxt.Size = new System.Drawing.Size(311, 20);
            this.untrustedAssemblyTxt.TabIndex = 5;
            // 
            // untrustedAssmblyLbl
            // 
            this.untrustedAssmblyLbl.AutoSize = true;
            this.untrustedAssmblyLbl.Location = new System.Drawing.Point(44, 70);
            this.untrustedAssmblyLbl.Name = "untrustedAssmblyLbl";
            this.untrustedAssmblyLbl.Size = new System.Drawing.Size(100, 13);
            this.untrustedAssmblyLbl.TabIndex = 6;
            this.untrustedAssmblyLbl.Text = "Untrusted Assembly";
            // 
            // executeButton
            // 
            this.executeButton.Location = new System.Drawing.Point(165, 355);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(282, 32);
            this.executeButton.TabIndex = 7;
            this.executeButton.Text = "Execute";
            this.executeButton.UseVisualStyleBackColor = true;
            // 
            // untrustedClassLbl
            // 
            this.untrustedClassLbl.AutoSize = true;
            this.untrustedClassLbl.Location = new System.Drawing.Point(55, 104);
            this.untrustedClassLbl.Name = "untrustedClassLbl";
            this.untrustedClassLbl.Size = new System.Drawing.Size(81, 13);
            this.untrustedClassLbl.TabIndex = 8;
            this.untrustedClassLbl.Text = "Untrusted Class";
            // 
            // untrustedClassTxt
            // 
            this.untrustedClassTxt.Location = new System.Drawing.Point(150, 104);
            this.untrustedClassTxt.Name = "untrustedClassTxt";
            this.untrustedClassTxt.Size = new System.Drawing.Size(311, 20);
            this.untrustedClassTxt.TabIndex = 9;
            // 
            // entryPointTxt
            // 
            this.entryPointTxt.Location = new System.Drawing.Point(150, 140);
            this.entryPointTxt.Name = "entryPointTxt";
            this.entryPointTxt.Size = new System.Drawing.Size(311, 20);
            this.entryPointTxt.TabIndex = 10;
            // 
            // entryPointLbl
            // 
            this.entryPointLbl.AutoSize = true;
            this.entryPointLbl.Location = new System.Drawing.Point(68, 147);
            this.entryPointLbl.Name = "entryPointLbl";
            this.entryPointLbl.Size = new System.Drawing.Size(58, 13);
            this.entryPointLbl.TabIndex = 11;
            this.entryPointLbl.Text = "Entry Point";
            // 
            // parameterLbl
            // 
            this.parameterLbl.AutoSize = true;
            this.parameterLbl.Location = new System.Drawing.Point(68, 176);
            this.parameterLbl.Name = "parameterLbl";
            this.parameterLbl.Size = new System.Drawing.Size(60, 13);
            this.parameterLbl.TabIndex = 12;
            this.parameterLbl.Text = "Parameters";
            // 
            // parameterTxt
            // 
            this.parameterTxt.Location = new System.Drawing.Point(150, 176);
            this.parameterTxt.Name = "parameterTxt";
            this.parameterTxt.Size = new System.Drawing.Size(311, 20);
            this.parameterTxt.TabIndex = 13;
            // 
            // writeAccesscheckBox
            // 
            this.writeAccesscheckBox.AutoSize = true;
            this.writeAccesscheckBox.Location = new System.Drawing.Point(243, 237);
            this.writeAccesscheckBox.Name = "writeAccesscheckBox";
            this.writeAccesscheckBox.Size = new System.Drawing.Size(89, 17);
            this.writeAccesscheckBox.TabIndex = 14;
            this.writeAccesscheckBox.Text = "Write Access";
            this.writeAccesscheckBox.UseVisualStyleBackColor = true;
            // 
            // executionAccesscheckBox
            // 
            this.executionAccesscheckBox.AutoSize = true;
            this.executionAccesscheckBox.Location = new System.Drawing.Point(367, 237);
            this.executionAccesscheckBox.Name = "executionAccesscheckBox";
            this.executionAccesscheckBox.Size = new System.Drawing.Size(111, 17);
            this.executionAccesscheckBox.TabIndex = 15;
            this.executionAccesscheckBox.Text = "Execution Access";
            this.executionAccesscheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.executionAccesscheckBox);
            this.Controls.Add(this.writeAccesscheckBox);
            this.Controls.Add(this.parameterTxt);
            this.Controls.Add(this.parameterLbl);
            this.Controls.Add(this.entryPointLbl);
            this.Controls.Add(this.entryPointTxt);
            this.Controls.Add(this.untrustedClassTxt);
            this.Controls.Add(this.untrustedClassLbl);
            this.Controls.Add(this.executeButton);
            this.Controls.Add(this.untrustedAssmblyLbl);
            this.Controls.Add(this.untrustedAssemblyTxt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.readAccesscheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filePathLabel);
            this.Controls.Add(this.filePathTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.Label filePathLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox readAccesscheckBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox untrustedAssemblyTxt;
        private System.Windows.Forms.Label untrustedAssmblyLbl;
        private System.Windows.Forms.Button executeButton;
        private System.Windows.Forms.Label untrustedClassLbl;
        private System.Windows.Forms.TextBox untrustedClassTxt;
        private System.Windows.Forms.TextBox entryPointTxt;
        private System.Windows.Forms.Label entryPointLbl;
        private System.Windows.Forms.Label parameterLbl;
        private System.Windows.Forms.TextBox parameterTxt;
        private System.Windows.Forms.CheckBox writeAccesscheckBox;
        private System.Windows.Forms.CheckBox executionAccesscheckBox;
    }
}

