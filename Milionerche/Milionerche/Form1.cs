using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Milionerche
{
    public partial class Form1 : Form
    {
        string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\viole\\AppData\\Local\\Microsoft\\Microsoft SQL Server Local DB\\Instances\\MSSQLLocalDB\\QuestionsGame.mdf\";Integrated Security=True;Connect Timeout=30";
        SqlConnection conn;
        SqlCommand command;
        SqlDataReader reader;
        int score=0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connection);
            conn.Open();
            MessageBox.Show("Open!");
            string query = "Select * from QuestionsGame";
            command = new SqlCommand(query, conn);
            reader = command.ExecuteReader();
            reader.Read();
           
            LoadRecord();
        }
        public void LoadRecord()
        {
            lblAnswear1.BackColor = SystemColors.Window;
            lblAnswear1.ForeColor = Color.Blue;
            lblAnswear2.BackColor = SystemColors.Window;
            lblAnswear2.ForeColor = Color.Blue;
            lblAnswear3.BackColor = SystemColors.Window;
            lblAnswear3.ForeColor = Color.Blue;
            lblAnswear4.BackColor = SystemColors.Window;
            lblAnswear4.ForeColor = Color.Blue;

            if (reader.Read())
            {
                lblQuestion.Text = reader[1].ToString();
                lblAnswear1.Text = reader[2].ToString();
                lblAnswear2.Text = reader[3].ToString();
                lblAnswear3.Text = reader[4].ToString();
                lblAnswear4.Text = reader[5].ToString();
            }
            else
            {
               DialogResult result= MessageBox.Show($"End!You win {score} $ Do you want to restart?", "END", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                reader.Close();
                if(result == DialogResult.Yes)
                {
                    LoadRecord();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void lblAnswear1_Click(object sender, EventArgs e)
        {
           
            if (lblAnswear1.Text == reader[6].ToString())
            {
                lblAnswear1.BackColor = Color.Green;
                score += 100;
                LoadRecord();
            }
            else
            {
                lblAnswear1.BackColor = Color.Red;
                DialogResult result = MessageBox.Show($"End! You win {score} $ Do you want to restart?", "END", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                reader.Close();
                if (result == DialogResult.Yes)
                {
                    reader = command.ExecuteReader();
                    LoadRecord();
                }
                else
                {
                    this.Close();
                }
            }
            lblAnswear3.Visible = true;
            lblAnswear2.Visible = true;
            lblAnswear4.Visible = true;
        }

        private void lblAnswear3_Click(object sender, EventArgs e)
        {
            
            if (lblAnswear3.Text == reader[6].ToString())
            {
                lblAnswear3.BackColor = Color.Green;
                score += 100;
                LoadRecord();
            }
            else
            {
                lblAnswear3.BackColor = Color.Red;
                DialogResult result = MessageBox.Show($"End! You win {score} $. Do you want to restart?", "END", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                reader.Close();
                if (result == DialogResult.Yes)
                {
                    reader = command.ExecuteReader();
                    LoadRecord();
                }
                else
                {
                    this.Close();
                }
            }
            lblAnswear1.Visible = true;
            lblAnswear2.Visible = true;
            lblAnswear4.Visible = true;
        }

        private void lblAnswear4_Click(object sender, EventArgs e)
        {
         
            if (lblAnswear4.Text == reader[6].ToString())
            {
                lblAnswear4.BackColor = Color.Green;
                score += 100;
                LoadRecord();

            }
            else
            {
                lblAnswear4.BackColor = Color.Red;
                DialogResult result = MessageBox.Show($"End! You win {score} $. Do you want to restart?", "END", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                reader.Close();
                if (result == DialogResult.Yes)
                {
                    reader = command.ExecuteReader();
                    LoadRecord();
                }
                else
                {
                    this.Close();
                }
            }
            lblAnswear1.Visible = true;
            lblAnswear2.Visible = true;
            lblAnswear3.Visible = true;
        }

        private void btbFriend_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Samon said that the correct answear is:{reader[6].ToString()} ");
            btbFriend.Enabled = false;
        }

        private void btnAudience_Click(object sender, EventArgs e)
        {
            if (lblAnswear1.Text == reader[6].ToString())
            {
                MessageBox.Show($"80% => {lblAnswear1.Text}" +
                    $"50% => {lblAnswear2.Text}" +
                    $"40% => {lblAnswear3.Text}" +
                    $"20% => {lblAnswear4.Text}");
            }
            if (lblAnswear2.Text == reader[6].ToString())
            {
                MessageBox.Show($"80% => {lblAnswear2.Text}" +
                    $"50% => {lblAnswear1.Text}" +
                    $"40% => {lblAnswear3.Text}" +
                    $"20% => {lblAnswear4.Text}");
            }
            if (lblAnswear3.Text == reader[6].ToString())
            {
                MessageBox.Show($"80% => {lblAnswear3.Text}" +
                    $"50% => {lblAnswear1.Text}" +
                    $"40% => {lblAnswear2.Text}" +
                    $"20% => {lblAnswear4.Text}");
            }
            if (lblAnswear4.Text == reader[6].ToString())
            {
                MessageBox.Show($"80% => {lblAnswear4.Text}" +
                    $"50% => {lblAnswear1.Text}" +
                    $"40% => {lblAnswear3.Text}" +
                    $"20% => {lblAnswear2.Text}");
            }
            btnAudience.Enabled = false;
        }

        private void button50_Click(object sender, EventArgs e)
        {

            if (lblAnswear1.Text != reader[6].ToString())
            {
                lblAnswear1.Visible = false;
            }
            else
            {
                lblAnswear1.Visible = true;
            }
            if (lblAnswear2.Text != reader[6].ToString())
            {
                lblAnswear2.Visible = false;
            }
            else
            {
                lblAnswear2.Visible = true;
            }
            if (lblAnswear4.Text != reader[6].ToString())
            {
                lblAnswear4.Visible = false;
            }
            else
            {
                lblAnswear4.Visible = true;
            }
            button50.Enabled = false;
        }

        private void lblAnswear2_Click(object sender, EventArgs e)
        {
            if (lblAnswear2.Text == reader[6].ToString())
            {
                lblAnswear2.BackColor = Color.Green;
                score += 100;
                lblAnswear1.BackColor = SystemColors.Window;
                LoadRecord();

            }
            else
            {
                lblAnswear2.BackColor = Color.Red;
                DialogResult result = MessageBox.Show($"End! You win {score} $. Do you want to restart?", "END", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                reader.Close();
                if (result == DialogResult.Yes)
                {
                    reader = command.ExecuteReader();
                    LoadRecord();
                }
                else
                {
                    reader = command.ExecuteReader();
                    this.Close();
                }
            }
            lblAnswear1.Visible = true;
            lblAnswear3.Visible = true;
            lblAnswear4.Visible = true;
        }
    }
}

