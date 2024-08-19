using System;
using System.Security.Principal;
using System.Windows.Forms;

namespace TIAgenerator
{
    public partial class MainForm : Form
    {
        static bool[] preset;
        public TraceWriter _writer;

        //MainForm Constructor
        public MainForm()
        {
            InitializeComponent();
            _writer = Writer(listBox1); //Object creation for the TraceWriter in the listbox
        }

        //Method for the creation fof the TraceWriter Object
        public static TraceWriter Writer(ListBox list)
        {
            TraceWriter traceWriter = new TraceWriter(list);
            return traceWriter;
        }

        //Get the number of the Steps that are available to manage inside the StartProgram Method for the TIA Portal generation
        public static bool[] GetPreset()
        {
            return preset;
        }

        //START Button event
        private void button1_Click(object sender, EventArgs e)
        {
            preset = new bool[checkedListBox1.Items.Count]; //add element to the checkboxlist if a new function will be included in the main program
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {                
                if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                {
                    preset[i] = true;
                }
                else
                {
                    preset[i] = false;
                }
            }
            Methods.UpdateLog(DateTime.Now + " | " + WindowsIdentity.GetCurrent().Name + ": " + "Start Generation");
            int station = (int)numericUpDown1.Value;
            int cpu = (int)numericUpDown2.Value;
            Program.StartProgram(ref _writer, station, cpu);
            _writer.Write("DONE");
            Methods.UpdateLog(DateTime.Now + " | " + WindowsIdentity.GetCurrent().Name + ": " + "Generation Completed");
        }

        //SELECT ALL Button event
        private void button2_Click(object sender, EventArgs e)
        {
            Methods.UpdateLog(DateTime.Now + " | " + WindowsIdentity.GetCurrent().Name + ": " + "Select All Items");
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        //EXPORT BLOCK button event
        private void button3_Click(object sender, EventArgs e)
        {
            Program.ExportBlock(textBox1.Text, (int)numericUpDown1.Value, (int)numericUpDown2.Value);
            _writer.Write("Block " + textBox1.Text + " Exported");
            Methods.UpdateLog(DateTime.Now + " | " + WindowsIdentity.GetCurrent().Name + ": " + "Export Block Command");
        }

        //MENU Generator
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panel1.Show();
            panel2.Hide();
            panel3.Hide();
        }

        //MENU Tools
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Show();
            panel3.Hide();
        }

        //MENU Test Area
        private void testAreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Show();
        }

        //DESELECT ALL button event
        private void button4_Click(object sender, EventArgs e)
        {
            Methods.UpdateLog(DateTime.Now + " | " + WindowsIdentity.GetCurrent().Name + ": " + "Deselect All Items");
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        //JSON FOLDER button event
        private void JsonFolderButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Methods.GetRelativePath(@"\Files\Json\");
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

            }
            Methods.UpdateLog(DateTime.Now + " | " + WindowsIdentity.GetCurrent().Name + ": " + "Open Json Folder");
            _writer.Write("Json Folder Opened");
        }
    }
}
