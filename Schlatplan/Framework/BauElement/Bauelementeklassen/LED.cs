using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schaltplan.Framework.BauElement.Bauelementeklassen
{
    class LED : Bauelement

    {
        public LED() : base("LED")
        {

        }
        public override string typeName
        {
            get
            {
                return "LED";
            }


        }
    }
}
