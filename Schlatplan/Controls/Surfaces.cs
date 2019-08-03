using System.Drawing;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using Schaltplan.Framework.BauElement;
using Schaltplan.Framework.Forms;
using Schaltplan.Framework.Gemeric;
using Schaltplan.Framework.BauElement.Bauelementeklassen;

namespace Schaltplan.Controls
{
    public delegate void BauelementSelectionChangedEvent(BaseBauelement bauelement);

    public delegate void BauelementLöschenEvent(BaseBauelement bauelement);
    public partial class Surfaces : UserControl 
    {

        private schaltplan _schaltplan;
        public Multimeter msl;
        
        private Point _dragOrigin = new Point(0, 0);
        private bool _isDragging = false;
        private ContextMenu menu = new ContextMenu();
        public schaltplan Schaltplan
         
        {
            // surfacce of the schaltplan
            get { return _schaltplan; }
            set
            {
                _schaltplan = value;
                Invalidate();
            }
        }
        public BaseBauelement SelectedElementFirst = null;
        public BaseBauelement SelectedElementLast = null;
        public Bauelement comp1 = null;
        public Bauelement comp2 = null;
        private LinkedList<BaseBauelement> _AlleBauelemente = null;

        public LinkedList<BaseBauelement> AlleBauelemente
        {
            get { return _AlleBauelemente; }
            set
            {
                _AlleBauelemente = value;
                Invalidate();
            }
        }

        

        private BaseBauelement _selectedBauelement = null;
        public BaseBauelement SelecBauelement
        {  get { return _selectedBauelement; }
            set
            {
                _selectedBauelement = value;
                if (BauelementSelectionChanged != null)
                    BauelementSelectionChanged(_selectedBauelement);
                Invalidate();

            }
        }
        // Events 
        
        public event BauelementSelectionChangedEvent BauelementSelectionChanged;
        private readonly  Resources _resource = new Resources();

       
        public Surfaces()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SizeChanged += (sender, e) => Invalidate();
        }

        // paint with bauelement with the given size
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Gray);
            var bounds = GetSurfaceBounds();
            e.Graphics.FillRectangle(Brushes.White, bounds);
            if ( Schaltplan != null) { 
                var _bauelemente = Schaltplan.bauelements;
                if (_bauelemente != null)
                {

                    foreach (var bauelement in _bauelemente)
                    {
                        var rect = new Rectangle(bauelement.Poisition, bauelement.Size);
                        if (bounds.Contains(rect))
                        {

                            bauelement.Render(_resource, e.Graphics);

                            if (bauelement == SelectedElementFirst)
                            {
                                rect.Inflate(-1, -1);
                                e.Graphics.DrawRectangle(Pens.Green, rect);
                            }
                            if (bauelement == SelectedElementLast)
                            {
                                rect.Inflate(-1, -1);
                                e.Graphics.DrawRectangle(Pens.Blue, rect);
                            }
                        }
                    }
                    var _connection = Schaltplan.connections;
                    foreach (var connection in _connection)
                    {
                        connection.Render(_resource, e.Graphics);
                    }
                }
            }
           
        }
      
        private Point _surfaceOffset = new Point(0, 0); // Der aktuelle Versatz innerhalb der Oberfläche
    
        private Size _surfaceSize = new Size(960 + 1, 800 + 1); //  Die Größe der gesamten Oberfläche

        private Rectangle GetSurfaceBounds()
        {
            return new Rectangle(
                _surfaceOffset.X,
                _surfaceOffset.Y,
                _surfaceSize.Width,
                _surfaceSize.Height);
        }

   // user könnte bauelement bewegen
        protected override void OnMouseDown(MouseEventArgs e)
        {
           if (e.Button == MouseButtons.Right)
            {
                OnRightClick(e);
                return;
            }
           
            bool ElementFound = false;
           
            for (var Node = _AlleBauelemente.Last; Node != null; Node = Node.Previous)
            {
                var rect=new Rectangle(Node.Value.Poisition,Node.Value.Size);
                // prüft ob der mousepoisiton passt mit bauelement position
                if (rect.Contains(e.Location))
                {
                    SelecBauelement = Node.Value;
                    if (e.Button == MouseButtons.Left)
                    {
                        _isDragging = true;
                        _dragOrigin=new Point(e.Location.X - Node.Value.Poisition.X, e.Location.Y-Node.Value.Poisition.Y);

                        // MousePoisition ist auf Bauelement
                        if (SelectedElementFirst != Node.Value)
                        {
                            SelectedElementLast = SelectedElementFirst;
                            SelectedElementFirst = Node.Value;
                            comp1 = (Bauelement) SelectedElementFirst;
                            comp2 = (Bauelement) SelectedElementLast;
                            
                        }
                     
                        
                        ElementFound = true;
                    }
               
                    break;
                }
            }
            if (!ElementFound)
            {
                SelecBauelement = null;
                SelectedElementLast = SelectedElementFirst;
                SelectedElementFirst = null;

                
            }
         
        

            
        }

        private void OnRightClick(MouseEventArgs args)
        {
           // prüft ob bauelement wird gewählt
            if (SelectedElementFirst != null)
            {
                // prüft ob zwei bauelementé werden gewählt
                if (SelectedElementFirst != null && SelectedElementLast != null)
                {
                    // wenn zwei bauelement wird gewählt man kann " verbinden " . 
                    menu.MenuItems.Add(new MenuItem("Verbinden", (sender, ev) =>
                    {
                        // prüft ob diese connection schon existieren , wenn ja wird nicht nochmal gebaut.

                        bool existieren = false;
                        for (int i=0;Schaltplan.connections.Count>i;i++)
                        {
                            if(Schaltplan.connections[i].StartElement==comp2 &&
                            Schaltplan.connections[i].EndElement == comp1)
                            {
                                existieren = true;
                               
                            }
                        }
                        if (!existieren)
                        {
                            var connection = new Connection(comp2, comp1);
                            Schaltplan.connections.Add(connection);
                            Invalidate();
                           
                        }
                        existieren = false;
                    }));
                    menu.MenuItems.Add(new MenuItem("MultiMeter Anschlißen( Spannung AnZeigen )  " ,(sender,ev)=>
                    {
                        string wert = (comp2.U ).ToString();
                       // MessageBox.Show(wert);
                        msl.callmulti(wert);

                        //  (this.Parent as MainForm).Controls["panel2"].Invalidate();
                        (this.Parent as MainForm).Controls["panel2"].Refresh();



                    }));
                    //zeigt die menubox neben das bauelement
                    menu.Show(this, new Point(SelectedElementFirst.Poisition.X + 20, SelectedElementFirst.Poisition.Y + 20));
                }
                
                menu.MenuItems.Clear();
                // wenn ein bauelement wird gewählt man kann es löschen
                menu.MenuItems.Add("löschen", (sender, ev) =>
                {
                    if (Baseform.MsgWarn("Möchten sie diese bauelement löschen?", MessageBoxButtons.YesNo) ==
                        DialogResult.Yes)
                    {
                        var connectors = Schaltplan.connections.Where(c => (c.StartElement == comp1) || (c.EndElement == comp1)).ToList();
                        for (int i = 0; i < connectors.Count(); i++)
                        {
                            Schaltplan.connections.Remove(connectors[i]);
                        }


                        Schaltplan.bauelements.Remove(comp1);
                        Invalidate();
                    }
                });
                // menuitem für strom anzeigen mithilfe 7-segment
                menu.MenuItems.Add(new MenuItem("MultiMeter Anschlißen( Strom AnZeigen )  ", (sender, ev) =>
                {
                    var wert = comp1.I.ToString();
                    msl.callmulti(wert);
                    (this.Parent as MainForm).Controls["panel2"].Refresh();


                }));

                menu.Show(this, new Point(SelectedElementFirst.Poisition.X + 20, SelectedElementFirst.Poisition.Y + 20));
            }
            
          
          
            menu.MenuItems.Clear();
            
          
        }
        public  void WiderstandSelected(int value)
        {
            // prüft ob die gewählt bauelemt ist widerstand und wenn ja dann der bekommt der wert ( value ) 
            if(SelecBauelement != null)
            {
                if (SelectedElementFirst.Name.Contains("Widerstand"))
                {
                    
                    Widerstand BauelementWiderstand = new Widerstand();
                    BauelementWiderstand = (Widerstand)SelectedElementFirst;
                    BauelementWiderstand.R = value;
                    



                }
                
            }
        }
        
        protected override void OnMouseUp(MouseEventArgs e)
        {

            _isDragging = false; 
        }
        // user kann bauelement bewegen 
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_isDragging && SelecBauelement != null)
            {
                var newPt=new Point(e.Location.X- _dragOrigin.X  ,e.Location.Y- _dragOrigin.Y );
                SelecBauelement.Poisition = newPt;
                
                Invalidate();

            }

        }
        







    }
    




}
