using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schaltplan.Framework.BauElement.Bauelementeklassen
{
    public class SpannungQuelle : Bauelement
    {
        public double V = 24;
        public SpannungQuelle() : base("SpannungQuelle")
        {

        }
        public override string typeName
        {
            get
            {
                return "SpannungQuelle";
            }


        }

       

    }
}
