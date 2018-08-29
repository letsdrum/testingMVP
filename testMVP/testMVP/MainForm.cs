using System;
using System.Windows.Forms;

namespace testMVP
{
    public interface IMainForm
    {
        string FilePath { get; }
        string Content { get; set; }
        void SetSymbolCount(int count);
        event EventHandler FileOpenClick;
        event EventHandler FileSaveClick;
        event EventHandler ContentChanged;
    }

    public partial class MainForm : Form, IMainForm
    {
        public string FilePath
        {
            get
            {
                return fldFilePath.Text;
            }
        }

        public string Content
        {
            get
            {
                return fldContent.Text;
            }

            set
            {
                fldContent.Text = value;
            }
        }

        public void SetSymbolCount(int count)
        {
            lblSymbol.Text = count.ToString();
        }

        public event EventHandler FileOpenClick;
        public event EventHandler FileSaveClick;
        public event EventHandler ContentChanged;

        public MainForm()
        {
            InitializeComponent();
            btnOpenFile.Click += new EventHandler(btnOpenFile_Click);
            btnSaveFile.Click += btnSaveFile_Click;
            fldContent.TextChanged += fldContent_TextChanged;
            btnSelectFile.Click += btnSelectFile_Click;
            numFont.ValueChanged += NumFont_ValueChanged;
                     
        }       

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            FileOpenClick?.Invoke(this, EventArgs.Empty);
        }
        
        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            FileSaveClick?.Invoke(this, EventArgs.Empty);
        }

        private void fldContent_TextChanged(object sender, EventArgs e)
        {
            ContentChanged?.Invoke(this, EventArgs.Empty);
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Текстовые файлы|*.txt|Все файлы|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fldFilePath.Text = dialog.FileName;
                FileOpenClick?.Invoke(this, EventArgs.Empty);
            }
        }

        private void NumFont_ValueChanged(object sender, EventArgs e)
        {
            fldContent.Font = new System.Drawing.Font("Calibri", (float)numFont.Value);
        }
    }
}
