using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schaltplan.Framework.BauElement.Bauelementeklassen
{
    public class Diode : Bauelement
    {
        public Diode() : base("Diode")
        {

        }
        public override string typeName
        {
            get
            {
                return "Diode";
            }
        }
    }
}
