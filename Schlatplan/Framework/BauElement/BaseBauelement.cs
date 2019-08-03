using System;
using System.Collections.Generic;
using System.Drawing;
using Schaltplan.Framework.Gemeric;
using Schaltplan.Framework.Render;

namespace Schaltplan.Framework.BauElement
{
    public abstract class BaseBauelement :  renderinterface

    {
        // base abstracte classe for the  bauelement where i set the name/position/size of the bauelement and connect it with the drawing part
        public LinkedListNode<BaseBauelement> MyNode { get;  set;  }
        public string Name { get; set; }
        public Point Poisition { get; set; }
        public Size Size { get;  set; }
        public BaseBauelement (string name,Size size )
        {
           
            Name = name;
            Size = size;
            Poisition= new Point(0, 0);
        } 
         
        public virtual void Render(Resources resources,Graphics g)
        { 
        }
    }       
}
