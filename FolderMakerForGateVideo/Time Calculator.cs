 using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FolderMakerForGateVideo
{
    public partial class Time_Calculator : Form
    {
        List<string> timeList = new List<string>();
        public Time_Calculator()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("No.", "No.");
            dataGridView1.Columns.Add("Time", "Time");
            dataGridView1.Columns[0].Width = 25;
            dataGridView1.Font = new System.Drawing.Font("Microsoft Sans Serif",12, System.Drawing.FontStyle.Bold) ;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(secondsList.Count>0)
            {
                if (e.RowIndex != secondsList.Count)
                {
                    hoursList.RemoveAt(e.RowIndex);
                    minutesList.RemoveAt(e.RowIndex);
                    secondsList.RemoveAt(e.RowIndex);
                    bindGrid();
                }
                else
                {
                    string totalTimeString=(string)dataGridView1[e.ColumnIndex, e.RowIndex].Value+" H";
                    Clipboard.SetText(totalTimeString);
                    MessageBox.Show("Total time is copied to clipboard","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
        }
        List<int> hoursList = new List<int>();
        List<int> minutesList = new List<int>();
        List<int> secondsList = new List<int>();
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            string key = e.KeyCode.ToString();
            if ( key== "Add" || key=="Subtract")
            {
                string text = textBox1.Text;
                Regex regex = new Regex("[^0-9]");
                text=regex.Replace(text, "");
                switch (text.Length)
                {
                    case 1:
                    case 2:
                        hoursList.Add(0);
                        minutesList.Add(0);
                        secondsList.Add(Convert.ToInt32(text));
                        break;
                    case 3:
                        hoursList.Add(0);
                        minutesList.Add(Convert.ToInt32(text.Substring(0, 1)));
                        secondsList.Add(Convert.ToInt32(text.Substring(1)));
                        break;
                    case 4:
                        hoursList.Add(0);
                        minutesList.Add(Convert.ToInt32(text.Substring(0, 2)));
                        secondsList.Add(Convert.ToInt32(text.Substring(2, 2)));
                        break;
                    case 5:
                        hoursList.Add(Convert.ToInt32(text.Substring(0, 1)));
                        minutesList.Add(Convert.ToInt32(text.Substring(1, 2)));
                        secondsList.Add(Convert.ToInt32(text.Substring(3, 2)));
                        break;
                    case 6:
                        hoursList.Add(Convert.ToInt32(text.Substring(0, 2)));
                        minutesList.Add(Convert.ToInt32(text.Substring(2, 2)));
                        secondsList.Add(Convert.ToInt32(text.Substring(4, 2)));
                        break;
                    default:
                        break;
                }
                if(key=="Subtract")
                {
                    int lastIndex = hoursList.Count-1;
                    hoursList[lastIndex] = hoursList[lastIndex] * -1;
                    minutesList[lastIndex] = minutesList[lastIndex] * -1;
                    secondsList[lastIndex] = secondsList[lastIndex] * -1;
                }
                bindGrid();
                textBox1.Text = "";
            }
        }
        private void bindGrid()
        {
            int totalHours = 0, totalMinutes = 0, totalSeconds = 0;
            dataGridView1.Rows.Clear();
            for (int i = 0; i < secondsList.Count; i++)
            {
                totalHours += hoursList[i];
                totalMinutes += minutesList[i];
                totalSeconds += secondsList[i];

                if (totalSeconds > 59)
                {
                    totalMinutes += totalSeconds / 60;
                    totalSeconds = totalSeconds % 60;
                }
                else if (totalMinutes < 0)
                {
                    totalMinutes -= minutesList[i];
                    totalMinutes += 60;
                    totalMinutes += minutesList[i];
                    totalHours--;
                }
                if (totalMinutes > 59)
                {
                    totalHours += totalMinutes / 60;
                    totalMinutes = totalMinutes % 60;
                }
                else if (totalSeconds < 0)
                {
                    totalSeconds -= secondsList[i];
                    totalSeconds += 60;
                    totalSeconds += secondsList[i];
                    totalMinutes--;
                }
                //dataGridView1.Rows.Add("- " + getTwoDigitTime(hoursList[i] * -1) + ":" + getTwoDigitTime(minutesList[i] * -1) + ":" + getTwoDigitTime(secondsList[i] * -1));
                //else
                dataGridView1.Rows.Add(i+1,getTwoDigitTime(hoursList[i]) + ":" + getTwoDigitTime(minutesList[i]) + ":" + getTwoDigitTime(secondsList[i]));
            }
            dataGridView1.Rows.Add("Total:", getTwoDigitTime(totalHours) + ":" + getTwoDigitTime(totalMinutes) + ":" + getTwoDigitTime(totalSeconds));
        }
        private string getTwoDigitTime(int time)
        {
            if (time < 0)
                time *= -1;
            if (time < 10)
                return "0" + time;
            return time + "";
        }
    }
}