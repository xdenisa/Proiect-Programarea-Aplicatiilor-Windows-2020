using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace WindowsFormsApp1
{
    public partial class Form7 : Form
    {
        Portofoliu p;
        string u;
        public Form7(Portofoliu p,string ut)
        {
            this.p = p;
            this.u = ut;
            InitializeComponent();
            AfisarePortofolii();
        }

        public void AfisarePortofolii()
        {
            listView1.Items.Clear();

            foreach (var actiune in p.Actiuni)
            {
                var item = new ListViewItem(new string[]{

                    actiune.Titlu.ToString(),
                    actiune.Detinator.ToString(),
                    actiune.Valoare.ToString(),
                   actiune.Dividende.ToString()});
                item.Tag = actiune;

                listView1.Items.Add(item);
            }

           
        }

        private void Form7_Load(object sender, EventArgs e)
        {
           

        }

        private void adaugareActiuneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form6 formular = new Form6(p,u))
            {
                formular.ShowDialog();
                this.p = formular.p;
                AfisarePortofolii();
            }


        }

        private void stergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Selected)
                {
                    var rezultat = MessageBox.Show(this,
                    $"Sunteți sigur că doriți ștergerea ?",
                    "Ștergere actiune",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                    if (rezultat == DialogResult.Yes)
                    {
                        listView1.Items.Remove(item);
                        p.Actiuni.Clear();
                        foreach(ListViewItem item2 in listView1.Items)
                        {
                            p.adaugaActiune((Actiune)item2.Tag);
                        }
                    }
                }
            }
        }

        private void salvatiPortofoliuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "Fișiere text (*.txt)|*.txt|Toate fișierele (*.*)|*.*";
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    SalvareInFisier(dialog.FileName);
                }
            }
        }

        private void SalvareInFisier(string caleFisier)
        {
            var continut = new StringBuilder();
            foreach (var actiune in p.Actiuni)
            {
                continut.Append(actiune.Titlu);
                continut.Append(",");
                continut.Append(actiune.Detinator);
                continut.Append(",");
                continut.Append(actiune.Valoare.ToString(CultureInfo.InvariantCulture));
                continut.Append(",");
                continut.Append(actiune.Dividende.ToString(CultureInfo.InvariantCulture));
                continut.AppendLine();
            }
            File.WriteAllText(caleFisier, continut.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
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
           

            var linii = File.ReadAllLines(caleFisier);
            for (int i = 0; i < linii.Length; i++)
            {
                p.Actiuni.Add(new Actiune(
                    linii[i].Split(',')[0],
                    linii[i].Split(',')[1],
                    float.Parse(linii[i].Split(',')[2], CultureInfo.InvariantCulture),
                    float.Parse(linii[i].Split(',')[3], CultureInfo.InvariantCulture)));
            }
        }

      

        //private void button2_Click(object sender, EventArgs e)
        //{
                       
            
       // }

        //private void uC_PAW1_Click(object sender, EventArgs e)
        //{
            
        //}
    }
}
