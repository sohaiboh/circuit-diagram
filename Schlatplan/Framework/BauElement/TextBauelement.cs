using System;
using System.Collections.Generic;
using System.Drawing;
using Schaltplan.Framework.Gemeric;

namespace Schaltplan.Framework.BauElement
{
    // test bauelement  
    class TextBauelement :  BaseBauelement
    {
        private string _text;
       

        public string text
        {
            get { return _text; }
            set { _text =  value; }         
        }
        public TextBauelement (Point pos) :
            this(pos, String.Empty)
        {
            
        }
        public TextBauelement (Point pos, string text) :
            base("text",new Size(0,0))
        {
            Poisition = pos;
            _text = text;
        }
        public override void Render(Resources resources,Graphics g)
       {
            g.DrawString(_text, resources.TextFont, Brushes.White, base.Poisition);
            
             
   
       }


            
    }
} 
