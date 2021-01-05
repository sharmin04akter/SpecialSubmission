using News.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace News
{
    public partial class Form1 : Form
    {
        public static int Bid = 0;
        public static List<NewsEntity> NewsEntities = new List<NewsEntity>();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewsEntity NewsEntity = new NewsEntity { Id = ++Bid, NewsPaperName = textBox1.Text, day = dateTimePicker1.Value };
            NewsEntities.Add(NewsEntity);
            MessageBox.Show("News Added");
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewsEntity oldNews = NewsEntities.Where(w => w.Id == Int32.Parse(label8.Text)).FirstOrDefault();
            oldNews.NewsName = textBox4.Text;
            Newsflight.day = dateTimePicker2.Value;
            MessageBox.Show("News Updated");
            Form1 f = new Form1();
            f.Show();
            this.Hide();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NewsEntity oldNews = NewsEntities.Where(w => w.Id == Int32.Parse(label8.Text)).FirstOrDefault();
            NewsEntities.Remove(oldNews);
            MessageBox.Show("Deleted");
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label8.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            dateTimePicker1.Value = (DateTime)dataGridView1.Rows[e.RowIndex].Cells[2].Value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = NewsEntities;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1054, 427);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }
    }
}
