using Microsoft.VisualBasic;
using Microsoft.Win32;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace OpenText
{
    public partial class Window : Form
    {
        string NewFileTitle = "New File - Open Text";
        string TitleEnd = " - Open Text";
        string TempFolder = Program.DefaultPath + "\\.OpenText";
        string TempFile = "\\Unsaved.txt";
        FileHandle? OpenFile = null;

        bool Portable = false;
        bool SubWin = false;

        public Window(bool subWin = false)
        {
            InitializeComponent();
            SubWin = subWin;
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.Contains("_p"))
            {
                Portable = true;
                keepOpen_CheckBox.Enabled = false;
                TitleEnd += " Portable";
                NewFileTitle += " Portable";
            }
            if (!SubWin)
            {
                this.Text = NewFileTitle;
                RegistryKey? key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\OpenText");
                if (key != null && !Portable)
                {
                    var _KeepOpen = key.GetValue("KeepOpen");
                    if (_KeepOpen != null && _KeepOpen.ToString() == "true")
                    {
                        keepOpen_CheckBox.Checked = true;
                        var FilePath = key.GetValue("FilePath");
                        if (FilePath != null)
                        {
#pragma warning disable CS8604 // No issue with null value, we check on line above
                            Open(FilePath.ToString(), true);
#pragma warning restore CS8604
                        }
                        else
                        {
                            if (!FileHandle.DirExist(TempFolder)) FileHandle.CreateDir(TempFolder);
                            else
                            {
                                Open(TempFolder + TempFile, true);
                            }
                        }
                        var _WordWarp = key.GetValue("WordWarp");
                        if (_WordWarp != null)
                        {
                            if (_WordWarp.ToString() == "1")
                            {
                                WordWarp.Checked = true;
                                WordWarp_Click(this, new EventArgs());
                            }
                            if (_WordWarp.ToString() == "0")
                            {
                                WordWarp.Checked = false;
                                WordWarp_Click(this, new EventArgs());
                            }
                        }
                        key.Close();
                    }
                }
            }
            else
            {
                NewFileTitle += " - SubWindow";
                TitleEnd += " - SubWindow";
                this.Text = NewFileTitle;
                this.keepOpen_CheckBox.Enabled= false;
                WordWarp.Checked = Program.GetWordWarp();
            }
        }

        public bool GetWordWarp()
        {
            return WordWarp.Checked;
        }

        private void Open(string path, bool KeepOpen = false)
        {
            OpenFile = new FileHandle(path);
            if (OpenFile.IsOpen)
            {
                if (OpenFile.FileContents == "")
                {
                    OpenFile.Close(KeepOpen);
                    if (!KeepOpen) MessageBox.Show("Unable to open file");
                    this.Text =  NewFileTitle;
                }
                else {
                    inputBox.Text = OpenFile.FileContents;
                    if (path.Contains(TempFile.Replace("\\", ""))) 
                    {
                        OpenFile.Close();
                        OpenFile = null;
                    } 
                    else this.Text = OpenFile.FileName + TitleEnd;
                }
            }
            else
            {
                Program.Logger.WriteLine("!!ERROR " + OpenFile.FileContents);
                MessageBox.Show("!!ERROR " + OpenFile.FileContents);
                OpenFile.Close();
                OpenFile = null;
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            string? Path = null;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Program.DefaultPath;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = false;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Path = openFileDialog.FileName;
                }
            }

            if (Path != null)
            {
                Open(Path);
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            if (OpenFile != null)
            {
                OpenFile.Close();
                OpenFile = null;
            }
            inputBox.Text = "";
            this.Text = NewFileTitle;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (OpenFile != null)
            {
                OpenFile.Save(inputBox.Text);
                if (!OpenFile.Save(inputBox.Text))
                {
                    MessageBox.Show(OpenFile.FileContents);
                    newButton_Click(sender, e);
                }
            }
            else
            {
                saveAsButton_Click(sender, e);
            }
        }

        private void WordWarp_Click(object sender, EventArgs e)
        {
            inputBox.WordWrap = WordWarp.Checked;
        }

        private void saveAsButton_Click(object sender, EventArgs e)
        {
            string? path = null;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = Program.DefaultPath;
                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog.FileName;
                }
            }
            if (path == null) return;
            OpenFile = new(path);
            if (!OpenFile.Save(inputBox.Text))
            {
                MessageBox.Show(OpenFile.FileContents);
                newButton_Click(sender, e);
            }
            this.Text = OpenFile.FileName + TitleEnd;
        }

        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!SubWin && !Portable)
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\OpenText");
                if (key != null)
                {
                    if (keepOpen_CheckBox.Checked)
                    {
                        key.SetValue("KeepOpen", "true");
                        if (OpenFile != null)
                            key.SetValue("FilePath", OpenFile.FilePath);
                        else
                        {
                            if (key.GetValue("FilePath") != null) key.DeleteValue("FilePath");
                            OpenFile = new(TempFolder + TempFile);
                            OpenFile.Save(inputBox.Text);
                            OpenFile.Close();
                        }
                        if (WordWarp.Checked == true) key.SetValue("WordWarp", "1");
                        else key.SetValue("WordWarp", "0");
                    }
                    else
                    {
                        key.SetValue("KeepOpen", "false");
                    }
                }
                key.Close();
            }
        }

        private void newWindow_button_Click(object sender, EventArgs e)
        {
            Program.MakeSubwin();
        }
    }
}