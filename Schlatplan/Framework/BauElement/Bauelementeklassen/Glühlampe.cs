using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schaltplan.Framework.BauElement.Bauelementeklassen
{
    class Glühlampe : Bauelement
    {
        public Glühlampe() : base("Glühlampe")
        {

        }
        public override string typeName
        {
            get
            {
                return "Glühlampe";
            }


        }
    }
}
