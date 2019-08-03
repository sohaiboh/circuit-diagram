using System.Collections.Generic;
using System.Drawing;
using Schaltplan.Framework.BauElement.Bauelementeklassen;
using Schaltplan.Framework.Gemeric;

namespace Schaltplan.Framework.BauElement
{
    public class Bauelement : BaseBauelement 

    {
        // class  bauelement that connected with the basebauelement abstracte classe 
        private readonly BauelementResource _resource;

        public double U;
        public double I; 

        
        public BauelementResource Resource {get { return _resource; } }
        public virtual string typeName
            
        { get; set; }

    

        public Bauelement(string name) : base(name, new Size(31, 20))
        {
            _resource = BauelementResource.Create(typeName);
            new Size(_resource.Width, _resource.Height);
         
        }

        public override void Render(Resources resource, Graphics g)
        {
            g.DrawImage(_resource.Image, new Rectangle(Poisition, Size));
            if (!string.IsNullOrWhiteSpace(Name))
            {
                var size = g.MeasureString(Name, resource.TextFont);
                g.DrawString(Name, resource.TextFont, Brushes.Black, Poisition.X + (float) size.Width / 2,
                    Poisition.Y - size.Height);
            }
        }
    }
}
