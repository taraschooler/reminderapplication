using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Reminder_and_Note_Taking_Application
{
    public partial class TaskBuddy : Form
    {
        DataTable notes = new DataTable();
        bool editing = false;

        System.Timers.Timer timer;

        string CalcTotal;
        int num1;
        int num2;
        string option;
        int result;

        public TaskBuddy()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //void - this is the label (written words)
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (editing)
            {
                notes.Rows[noteHistory.CurrentCell.RowIndex]["Subject"] = subjectBox.Text;  
                notes.Rows[noteHistory.CurrentCell.RowIndex]["Note"] = noteBox.Text;
            }
            else
            {
                notes.Rows.Add(subjectBox.Text, noteBox.Text);
            }
            subjectBox.Text = ""; //allows text to be entered
            noteBox.Text = ""; //allows text to be entered
            editing = false;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            subjectBox.Text = ""; //allows text to be entered
            noteBox.Text = ""; //allows text to be entered

        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            subjectBox.Text = notes.Rows[noteHistory.CurrentCell.RowIndex].ItemArray[0].ToString();
            noteBox.Text = notes.Rows[noteHistory.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true; //allows
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                notes.Rows[noteHistory.CurrentCell.RowIndex].Delete(); //deletes Cell
            }
            catch (Exception) { Console.WriteLine("Not Valid"); }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)  //VOID double click
        {
            //VOID
        }

        private void subjectBox_TextChanged(object sender, EventArgs e)
        {
            //VOID
        }

        private void noteBox_TextChanged(object sender, EventArgs e)
        {
            //VOID
        }
        private void TaskBuddy_Load(object sender, EventArgs e)
        {
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            notes.Columns.Add("Subject");  //add Subject line to grid
            notes.Columns.Add("Note");  //add Note line to grid

            noteHistory.DataSource = notes; //display Note History

            timer = new System.Timers.Timer(); //TIMER FOR REMINDER SYSTEM
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed; 
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            DateTime userTime = dateTimePicker1.Value;
            if (currentTime.Hour == userTime.Hour && currentTime.Minute == userTime.Minute && currentTime.Second == userTime.Second)
            {
                timer.Stop();
                UpdateLbl upd = UpdateDataLbl;
                if (lblStatus.InvokeRequired)
                    Invoke(upd, lblStatus, "Stop");
                MessageBox.Show("Reminder:", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        delegate void UpdateLbl(Label lbl, string value);

        void UpdateDataLbl(Label lbl, string value)
        {
            lbl.Text = value;
        }


        private void noteHistory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)  //LOAD NOTE HISTORY
        {
            subjectBox.Text = notes.Rows[noteHistory.CurrentCell.RowIndex].ItemArray[0].ToString();
            noteBox.Text = notes.Rows[noteHistory.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true; //allows
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //VOID
        }

        private void setButton_Click(object sender, EventArgs e)  //SET BUTTON REMINDER
        {
            timer.Start();
            lblStatus.Text = "Reminder Set";
        }

        private void stopButton_Click(object sender, EventArgs e)  //STOP TIMER
        {
            timer.Stop();
            lblStatus.Text = "";
        }

        private void label4_Click(object sender, EventArgs e)
        {
            //VOID REMINDER LABEL
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //accidental click added button out of order
            textBox1.Text = textBox1.Text + "9";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "8";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "0";
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            option = "+";
            num1 = int.Parse(textBox1.Text);

            textBox1.Clear();
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            option = "-";
            num1 = int.Parse(textBox1.Text);

            textBox1.Clear();
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            option = "*";
            num1 = int.Parse(textBox1.Text);

            textBox1.Clear();
        }

        private void buttonDivision_Click(object sender, EventArgs e)
        {
            option = "/";
            num1 = int.Parse(textBox1.Text);

            textBox1.Clear();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            num2 = int.Parse(textBox1.Text);

            if (option.Equals("+"))
                result = num1 + num2;

            if (option.Equals("-"))
                result = num1 - num2;

            if (option.Equals("*"))
                result = num1 * num2;

            if (option.Equals("/"))
                result = num1 / num2;

            textBox1.Text = result + "";
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to quit?", "Exit Application", MessageBoxButtons.YesNo);
            exitMethod(result);
        }

        private static void exitMethod(DialogResult result)
        {
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
    }
       

