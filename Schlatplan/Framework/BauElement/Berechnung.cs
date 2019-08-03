using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schaltplan.Framework.BauElement
{
    class Berechnung
    {



        public static double Stromberechnung(double U,double R)
        {
            return (U / R);
        }

        public static double Spannungberechnung(double I, double R)
        {
            return (I * R);
        }

        public static double berechnungfuerParallel(double R1, double R2)
        {
            return ((R1 * R2) / (R1 + R2));
        }
        public static double berechnungfuerReihe(double R1,double R2)
        {
            return (R1 + R2);
        }
        

    }
}
