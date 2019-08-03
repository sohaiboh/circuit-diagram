using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schaltplan.Framework.BauElement.Bauelementeklassen
{
    class Spule : Bauelement
    {
        public Spule() : base("Spule")
        {

        }

        public override string typeName
        {
            get
            {
                return "Spule";
            }



        }
    }
}
