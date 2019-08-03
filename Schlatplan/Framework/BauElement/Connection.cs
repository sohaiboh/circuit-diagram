using System.Drawing;
using System.Drawing.Drawing2D;
using Schaltplan.Framework.Gemeric;

namespace Schaltplan.Framework.BauElement
{
    public class Connection : Render.renderinterface
    {
       

        public Bauelement StartElement { get  ; set; }
        public Bauelement EndElement { get; set; }
        public double I { get; set; }

        

        public Connection(Bauelement start, Bauelement end)
        {
            StartElement = start;
            EndElement = end;
        }


        // draw line between start and end poistion

        public void Render(Resources resource, Graphics g)
        {
            // draw line from the middle of the bauelement position
             var endPositionX = EndElement.Poisition.X ;
            var endPositonY = EndElement.Poisition.Y ;
            
            
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(4, 4);
            Pen p = new Pen(Color.Black, 3);
            p.CustomEndCap = bigArrow;
            p.StartCap = LineCap.RoundAnchor;
           // p.EndCap = LineCap.ArrowAnchor;


            g.DrawLine(p, StartElement.Poisition.X, StartElement.Poisition.Y , endPositionX, StartElement.Poisition.Y );
            g.DrawLine(p, EndElement.Poisition.X, StartElement.Poisition.Y , EndElement.Poisition.X, endPositonY);
        }
    }
}