using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schaltplan.Framework.BauElement;
using Schaltplan.Framework.BauElement.Bauelementeklassen;
using System.Windows.Forms;

namespace Schaltplan.Framework.Gemeric
{
    // main class schaltplan that made off bauelements + connections 
    public class schaltplan
    {

        List<Bauelement> TODO = new List<Bauelement>();
        List<Bauelement> DONE = new List<Bauelement>();
        private List<Bauelement> _bauelements = new List<Bauelement>();
        private List<Connection> _connections = new List<Connection>();
        public List<Bauelement> bauelements
        {
            get
            {
                return _bauelements;
            }
            
            
        }
        public List<Connection> connections
        {
            get { return _connections; }
        }

        public List<Bauelement> LoadAllConnectionTheSameEndElement(schaltplan schaltplan, Bauelement bauelement)
        {
           
            var childelementseeee = new List<Bauelement>();

            for (int j = 0; schaltplan.connections.Count > j; j++)
            {
                if (bauelement == schaltplan.connections[j].EndElement)
                {
                    if (schaltplan.connections[j].EndElement.typeName == "Widerstand")
                    {



                        childelementseeee.Add(schaltplan.connections[j].StartElement);
                        
                    }

            }
        }
            return childelementseeee;
        }
       // ladet alle endelemente für ein bestimmte startelement in eine bestimmte schaltplan
        public List<Bauelement> LoadAllConnectionSameStartElement(schaltplan schaltplan , Bauelement bauelement)

        {
            var schonda = false;
            var childelements = new List<Bauelement>();

            for (int j = 0; schaltplan.connections.Count > j; j++)
            {
                if ( (bauelement == schaltplan.connections[j].StartElement) 
                    && (schaltplan.connections[j].EndElement.typeName == "Widerstand") )
                {
                    childelements.Add(schaltplan.connections[j].EndElement);
                }
            }

            return childelements;
        }
        // rechnet die summe für die parallel widerstande
        public double WiderstandS(List<Bauelement> TODO)
        {
            double summe = 0;
            if (TODO.Count > 0)
            {
                for (int i = 0; TODO.Count > i; i++)

                {
                    var element = (Widerstand) TODO[i];

                    summe += 1 / element.R;

                    //MessageBox.Show(summe.ToString());

                }
                return 1 / summe;
            }
            return 0;
        }
          // schickt züruck die spannungquelle bauelement ( startelement von ein schaltplan)
        public Bauelement FindStartElement()
        {
            for (int j = 0; this.bauelements.Count > j; j++)
            {
                if(this.bauelements[j].typeName== "SpannungQuelle")
                {
                    return this.bauelements[j];
                }
                
            }
            return null;

        }
        // vorbereitet  TODO/DONE list für neue "CalulateLayer" also neue berechnung
        public void prepare()
        {
            DONE.Clear();
            TODO.Clear();
        }
       

        //
        public double CalculateLayerResistance(Bauelement startElement)
        {
            var nextLayerResistance = 0.0;
            var totalResistance = 0.0;

            if (!DONE.Contains(startElement))
            {
                // LoadAll... puts all items in a child elements list
                var childelements = this.LoadAllConnectionSameStartElement(this, startElement);
                
                // For each child element
               
                foreach (var item in childelements)
                {
                    var endelements = this.LoadAllConnectionTheSameEndElement(this, item);
                    
                    if (endelements.Any(e => e != item))
                        nextLayerResistance = CalculateLayerResistance(item);
                }
                DONE.Add(startElement);
                var thisLayerResistance = this.WiderstandS(childelements);
                // once you have done all child elements, add this element's resistance layer
                totalResistance+= nextLayerResistance + thisLayerResistance;
            }
           
            return totalResistance;
        }
        //
        public void  CalculateLayer(Bauelement startElement, double i,double v)
        {
           

            if (!DONE.Contains(startElement))
            {
                DONE.Add(startElement);

                // LoadAll... puts all items in a child elements list
                var childelements = this.LoadAllConnectionSameStartElement(this, startElement);


                // once you have done all child elements, add this element's resistance layer
                if (childelements.Count != 0)
                {
                    var totalresistence = this.WiderstandS(childelements);
                    var spannung = Berechnung.Spannungberechnung(startElement.I, totalresistence);
                    startElement.U = spannung;
                
                    
                }

               
                // For each child element
                foreach (var item in childelements)
                {
                    Double R = ((Widerstand)item).R;
                    item.I = Berechnung.Stromberechnung(startElement.U, R);
                    item.U = v;
                    CalculateLayer(item, startElement.I, item.U);
                    //MessageBox.Show(startElement.U.ToString());

                    //  MessageBox.Show(item.I.ToString()+"I");


                }
            }

           
        }


    }
}
