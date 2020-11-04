using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Portofoliu
    {
        List<Actiune> actiuni;

        public Portofoliu()

        {
            actiuni = new List<Actiune>();
        }

        public Portofoliu(Actiune a)
        {
            actiuni.Add(a);
        }

        public List<Actiune> Actiuni
        {
            get { return this.actiuni; }
        }

        public override string ToString()
        {
            string mesaj="";
            foreach (var a in actiuni)
                mesaj += a.ToString();

            return mesaj;
        }

        public void adaugaActiune(Actiune a)
        {
            actiuni.Add(a);
        }

        public void adaugaActiune(string t, string d, float v, float de)
        {
            Actiune a = new Actiune(t, d, v, de);
            actiuni.Add(a);
        }

        public Actiune this[int index]
        {
            get
            {
                if (index >= 0 && index < actiuni.Count())
                    return this.actiuni[index];
                else
                    return null;
            }
            set
            {
                this.actiuni[index] = value;
            }
        }
    }
}
