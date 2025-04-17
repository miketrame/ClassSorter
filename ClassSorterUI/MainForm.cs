using System.Drawing.Design;

namespace ClassSorterUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void lbInputFiles_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void lbInputFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[]; // get all files droppeds  
            foreach (string file in files)
                this.lbInputFiles.Items.Add(file);
        }
        private void tbOutput_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }
        private void tbOutput_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[]; // get all files droppeds  
            string folder = files.FirstOrDefault();
            if (Directory.Exists(folder))
                this.tbOutput.Text = folder;
        }

        private void btnBrowseInput_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            using (dialog)
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in dialog.FileNames)
                        this.lbInputFiles.Items.Add(file);
                }
            }
        }
        private void btnBrowseOutputDir_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.tbOutput.Text = dialog.SelectedPath;
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ClearList();
        }
        private void removeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ClearList();
        }
        private void ClearList()
        {
            this.lbInputFiles.Items.Clear();
        }
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.lbInputFiles.Items.Remove(this.lbInputFiles.SelectedItem);
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach(string path in this.lbInputFiles.Items)
            {
                try
                {
                    string prefix = Path.GetFileNameWithoutExtension(path);
                    ClassSorter sorter = new ClassSorter(this.tbOutput.Text, prefix);
                    sorter.Sort(path);
                }
                catch
                {
                    MessageBox.Show("Error processing file: " + path);
                }
            }
            MessageBox.Show("Success!");
        }

    }
}
