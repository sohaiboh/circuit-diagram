using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schaltplan.Framework.BauElement.Bauelementeklassen

{ 
   class Kondensator : Bauelement
    { 
        public Kondensator() : base("Kondensator")
        {

        }
        public override string typeName
        {
            get
            {
                return "Kondensator";
            }


        }
    
  }
}
