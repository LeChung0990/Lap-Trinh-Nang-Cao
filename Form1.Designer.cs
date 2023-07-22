
namespace WordToPdf
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
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.btnConvertToPdf = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(289, 145);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(169, 23);
            this.btnSelectFile.TabIndex = 0;
            this.btnSelectFile.Text = "Select File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // btnConvertToPdf
            // 
            this.btnConvertToPdf.Location = new System.Drawing.Point(289, 227);
            this.btnConvertToPdf.Name = "btnConvertToPdf";
            this.btnConvertToPdf.Size = new System.Drawing.Size(169, 23);
            this.btnConvertToPdf.TabIndex = 1;
            this.btnConvertToPdf.Text = "Convert To Pdf";
            this.btnConvertToPdf.UseVisualStyleBackColor = true;
            this.btnConvertToPdf.Click += new System.EventHandler(this.btnConvertToPdf_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(70, 313);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(599, 22);
            this.txtFilePath.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 511);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnConvertToPdf);
            this.Controls.Add(this.btnSelectFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Button btnConvertToPdf;
        private System.Windows.Forms.TextBox txtFilePath;
    }
}

