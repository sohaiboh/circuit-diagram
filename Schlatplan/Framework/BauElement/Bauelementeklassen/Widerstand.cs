using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schaltplan.Framework.Gemeric;


namespace Schaltplan.Framework.BauElement.Bauelementeklassen
{
     public class Widerstand  : Bauelement 
        
    
    {
        public Widerstand() : base("Widerstand")
        {

        }

        public override string typeName
        {
            get
            {
                return "Widerstand";
            }

           
        }
         
    
        public double R;
       


    }
}
