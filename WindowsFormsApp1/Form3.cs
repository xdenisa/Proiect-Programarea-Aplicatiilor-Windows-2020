using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        Portofoliu p;
        const string Sir = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Denisa\Desktop\C\PROIECTPAW\PROIECT\WindowsFormsApp1\Portofoliu.mdb";
        public Form3(Portofoliu p)
        {
            this.p = p;
            InitializeComponent();

        }

        private void Form3_Deactivate(object sender, EventArgs e)
        {
            
        }

        private void Form3_Leave(object sender, EventArgs e)
        {
          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'portofoliuDataSet.Actiuni' table. You can move, or remove it, as needed.
            this.actiuniTableAdapter.Fill(this.portofoliuDataSet.Actiuni);
            

        }

       

        private void adaugaActiuneNouaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Actiune a = new Actiune(textBox1.Text, textBox2.Text, float.Parse(textBox3.Text), float.Parse(textBox4.Text));
                using (var conexiune = new OleDbConnection(Sir))
                {
                    conexiune.Open();
                    using (var comanda = new OleDbCommand("INSERT INTO Actiuni VALUES (?,?,?,?)", conexiune))
                    {
                        comanda.Parameters.Add("Titlu", OleDbType.VarChar).Value = a.Titlu;
                        comanda.Parameters.Add("Detinator", OleDbType.VarChar).Value = a.Detinator;
                        comanda.Parameters.Add("Valoare", OleDbType.Numeric).Value = a.Valoare;
                        comanda.Parameters.Add("Dividende", OleDbType.Numeric).Value = a.Dividende;
                        comanda.ExecuteNonQuery();

                        MessageBox.Show("Actiune adaugata in baza de date");
                        this.actiuniTableAdapter.Fill(this.portofoliuDataSet.Actiuni);
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        errorProvider1.Clear();

                    }
                }
            }
            catch
            {               

                if (textBox1.Text == "")
                    errorProvider1.SetError(textBox1, "Introduceti titlu!");
                if (textBox2.Text == "")
                    errorProvider1.SetError(textBox2, "Introduceti detinator!");
                if (textBox3.Text == "")
                    errorProvider1.SetError(textBox3, "Introduceti valoare!");
                if (textBox4.Text == "")
                    errorProvider1.SetError(textBox4, "Introduceti dividende!");
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void salveazaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
                errorProvider1.SetError(textBox5, "Introduceti titlu!");
            else
            {

                using (var conexiune = new OleDbConnection(Sir))
                {
                    conexiune.Open();
                    using (var comanda = new OleDbCommand("DELETE FROM Actiuni WHERE Titlu=? ", conexiune))
                    {
                        comanda.Parameters.Add("?", OleDbType.VarChar).Value = textBox5.Text;
                        comanda.ExecuteNonQuery();

                        MessageBox.Show("Actiune stearsa");
                        
                        this.actiuniTableAdapter.Fill(this.portofoliuDataSet.Actiuni);
                        textBox5.Clear();
                        errorProvider1.Clear();
                    }
                }

            }
            
               
            
        }

        private void stergeActiuneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
                
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dataGridView1.Invalidate();
        }
    }
}
