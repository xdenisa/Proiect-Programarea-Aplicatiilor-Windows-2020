using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        Portofoliu p;
        Portofoliu listBox;
        const string Sir = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Portofoliu.mdb";

        public Form5(Portofoliu p)
        {
            this.p = p;
            this.listBox = new Portofoliu();
            InitializeComponent();
            if (p.Actiuni.Count > 0)
                foreach (Actiune c in p.Actiuni)
                    listBox1.Items.Add(c.ToString());
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                listBox1.DoDragDrop(listBox1.Text, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void label1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
                e.Effect = DragDropEffects.Copy;
            else
                if ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
                e.Effect = DragDropEffects.Move;
        }

        private void label1_DragDrop(object sender, DragEventArgs e)
        {
            string curItem = listBox1.SelectedItem.ToString();
            int index = listBox1.FindString(curItem);
           // p.Actiuni.RemoveAt(index);
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

     
        private void bazaDeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox.Actiuni.Clear();
            using (var conexiune = new OleDbConnection(Sir))
            {
                conexiune.Open();
                using (var comanda = new OleDbCommand("SELECT * FROM Actiuni", conexiune))
                {
                    using (var reader = comanda.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            var actiune = new Actiune(
                                reader.GetString(0), 
                                reader.GetString(1), 
                                (float)reader.GetInt32(2), 0);
                            listBox.Actiuni.Add(actiune);
                        }
                    }
                }
            }
            AfisarePortofolii();

        }

       private void AfisarePortofolii()
        {
            listBox1.Items.Clear();
            if (listBox.Actiuni.Count > 0)
                foreach (Actiune c in listBox.Actiuni)
                    listBox1.Items.Add(c.ToString());
        }
        private void fisierTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "Fișiere text (*.txt)|*.txt|Toate fișierele (*.*)|*.*";
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    IncarcareDinFisier(dialog.FileName);
                    AfisarePortofolii();
                }
            }
        }

        private void IncarcareDinFisier(string caleFisier)
        {

            listBox.Actiuni.Clear();
            var linii = File.ReadAllLines(caleFisier);
            for (int i = 0; i < linii.Length; i++)
            {
                listBox.Actiuni.Add(new Actiune(
                    linii[i].Split(',')[0],
                    linii[i].Split(',')[1],
                    float.Parse(linii[i].Split(',')[2], CultureInfo.InvariantCulture),
                    float.Parse(linii[i].Split(',')[3], CultureInfo.InvariantCulture)));
            }
        }

        private void portofoliuCurentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (p.Actiuni.Count > 0)
                foreach (Actiune c in p.Actiuni)
                    listBox1.Items.Add(c.ToString());
        }
    }
}
