using Aspose.Words;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordToPdf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Word Documents|*.doc;*.docx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog.FileName;
            }
        }
        private void btnConvertToPdf_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFilePath.Text))
            {
                string wordFilePath = txtFilePath.Text;
                string pdfFilePath = Path.ChangeExtension(wordFilePath, ".pdf");

                Document document = new Document(wordFilePath);
                document.Save(pdfFilePath, SaveFormat.Pdf);

                MessageBox.Show("Chuyển đổi thành công!");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tệp tin Word trước.");
            }
        }

    }
}
