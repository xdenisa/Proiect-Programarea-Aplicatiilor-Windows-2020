using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Actiune
    {
        string titlu;
        string detinator;
        float valoare;
        float dividende;

        public Actiune(string t, string d, float v, float di)
        {
            this.titlu = t;
            this.detinator = d;
            this.valoare = v;
            this.dividende = di;
        }

        public string Titlu
        {
            get { return this.titlu; }
            set
            {
                this.titlu = value;
            }
        }

        public string Detinator
        {
            get { return this.detinator; }
            set
            {
                this.detinator = value;
            }
        }

        public float Valoare
        {
            get { return this.valoare; }
            set
            {
                if (value >= 0)
                {
                   valoare = value;
                }
                else
                {
                    throw new InvalidOperationException("Valoarea actiunilor nu poate fi negativă.");
                }
            }
        }

        public float Dividende
        {
            get { return this.dividende; }
            set
            {
                if (value >= 0)
                {
                    dividende = value;
                }
                else
                {
                    throw new InvalidOperationException("Devidendele nu pot avea valoare negativă.");
                }
            }
        }

        public override string ToString()
        {
            return titlu + ", detinut de: " + detinator + " cu valoarea:" + valoare;
        }

    }
}
