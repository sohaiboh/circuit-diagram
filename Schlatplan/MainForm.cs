using Schaltplan.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using Schaltplan.Framework.BauElement;
using Schaltplan.Framework.BauElement.Bauelementeklassen;
using Schaltplan.Framework.Forms;
using Schaltplan.Framework.Gemeric;
using System.IO;

namespace Schaltplan
{

    public partial class 
        MainForm : Baseform
    {
        private readonly LinkedList<BaseBauelement> aktuellBauelementListe;
        public int selWidth;
        public int selHeight;
        schaltplan akuelleSchaltplan = new schaltplan();
        private List<BauelementResource> elementList;
        public string Pathdirectory;
        
      
        public MainForm(BauelementResource baueleBauelementManger)
            
            
        {
            
            
            // Liste von alle Sourcebauelemente 
            elementList = new List<BauelementResource>(BauelementResource.AllElements);
            InitializeComponent(); 
            // Gitter wird gebaut , große 1/10 von surface
             selWidth = surface.Size.Width / 10;
             selHeight = surface.Size.Height /10 ;
            // ein liste wird gebaut mit alle bauelemente die in schaltplan sind
            var list = akuelleSchaltplan.bauelements;
            aktuellBauelementListe =new LinkedList<BaseBauelement>();
            
            surface.Schaltplan = akuelleSchaltplan;
            surface.AlleBauelemente = aktuellBauelementListe;
            surface.BauelementSelectionChanged += SurfaceBauelementSelectionChanged;
            surface.msl = msl;
            
           

           
        }
        

        //Bringt das letzte Bauelement nach vorne auf die aktuellBauelementListe
        private void SurfaceBauelementSelectionChanged(BaseBauelement bauelement)
        {
            if (bauelement != null && bauelement != aktuellBauelementListe.Last.Value && aktuellBauelementListe.Count > 1)
            {
                var lastNode = aktuellBauelementListe.Last;
                aktuellBauelementListe.Remove(lastNode);
                aktuellBauelementListe.AddBefore(bauelement.MyNode , lastNode);
                aktuellBauelementListe.Remove(bauelement.MyNode);
                bauelement.MyNode = aktuellBauelementListe.AddLast(bauelement);
            }
        }
        // funktion wo man kann ein bauelement mitkey löschen
       protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Delete && surface.SelecBauelement != null &&
                MsgWarn(string.Format("Möshten sie diese Bauelement löschen?"), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var item = surface.SelecBauelement;
                surface.SelecBauelement = null;
              

                aktuellBauelementListe.Remove(item.MyNode);
                var comp = (Bauelement) item;
                var connectors = akuelleSchaltplan.connections.Where(c => (c.StartElement == comp) || (c.EndElement == comp)).ToList();
                for (int i = 0; i < connectors.Count(); i++)
                {
                    surface.Schaltplan.connections.Remove(connectors[i]);
                }
                surface.Schaltplan.bauelements.Remove(comp);
                
                surface.Invalidate();




            }
            return base.ProcessCmdKey(ref msg, keyData);

        }



        Multimeter msl = new Multimeter();
        private void Form1_Load(object sender, EventArgs e)
        {
            

            // bauelement werden auf Listview gebaut 
            for (int i = 0; i < elementList.Count; i++)
            {
                var comp = new ListViewItem(elementList[i].Name);
                comp.ImageIndex = i;
                listView1.Items.Add(comp);
            }
            listView1.Select();
            
            

            

           

        }

       
        private void showGridToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            // listView1.SelectedItems[0]
            
           // DoDragDrop(listView1.SelectedItems[0], DragDropEffects.Copy);
        }

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            //listView1.DoDragDrop(listView1.SelectedItems, DragDropEffects.Copy);
        }

    
        void listView1_DragEnter(object sender, DragEventArgs e)
        {
           // e.Effect = DragDropEffects.Copy;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // prüft welche bauelement wird gewählt
            for (int i = 0; i < listView1.SelectedItems.Count; i++)
            {
                var componentresource = elementList[listView1.SelectedItems[i].Index];
                string BauelementTyp = componentresource.Name;
                TypeDasBauelement(BauelementTyp);
            }
               
            // liste von alle bauelemente
            var list = akuelleSchaltplan.bauelements;
            BautSchaltplan(list);

          




            //bauelement wird auf gitter gezeichnet



            surface.Schaltplan = akuelleSchaltplan;
            surface.BauelementSelectionChanged += SurfaceBauelementSelectionChanged;
            surface.AlleBauelemente = aktuellBauelementListe;
            this.Refresh();
        
        }
        public void TypeDasBauelement(string BauelementTyp)
        {
            // prüft welche bauelement wird gewählt
           
                
                if (BauelementTyp == "LED")
                {
                    var component = new LED();
                    component.Name = "LED" + Guid.NewGuid().ToString();
                    akuelleSchaltplan.bauelements.Add(component);
                    component.MyNode = aktuellBauelementListe.AddLast(component);


                }
                if (BauelementTyp == "Widerstand")
                {
                    var component = new Widerstand();
                    component.Name = "Widerstand" + Guid.NewGuid().ToString();
                 akuelleSchaltplan.bauelements.Add(component);
                    component.MyNode = aktuellBauelementListe.AddLast(component);

                }
                if (BauelementTyp == "Diode")
                {
                    var component = new Diode();
                    component.Name = "Diode" + Guid.NewGuid().ToString();
                    akuelleSchaltplan.bauelements.Add(component);
                    component.MyNode = aktuellBauelementListe.AddLast(component);
                }
                if (BauelementTyp == "Glühlampen")
                {
                    var component = new Glühlampe();
                    component.Name = "Glühlampe" + Guid.NewGuid().ToString();
                    akuelleSchaltplan.bauelements.Add(component);
                    component.MyNode = aktuellBauelementListe.AddLast(component);
                }
                if (BauelementTyp == "SpannungQuelle")
                {
                    var component = new SpannungQuelle();
                    component.Name = "SpannungQuelle" + Guid.NewGuid().ToString();
                    akuelleSchaltplan.bauelements.Add(component);
                    component.MyNode = aktuellBauelementListe.AddLast(component);
                }
                if (BauelementTyp == "Kondensator")
                {
                    var component = new Kondensator();
                    component.Name = "Konsenator" + Guid.NewGuid().ToString();
                    akuelleSchaltplan.bauelements.Add(component);
                    component.MyNode = aktuellBauelementListe.AddLast(component);
                }

                if (BauelementTyp == "Spule")
                {
                    var component = new Spule();
                    component.Name = "Spule" + Guid.NewGuid().ToString();
                    akuelleSchaltplan.bauelements.Add(component);
                    component.MyNode = aktuellBauelementListe.AddLast(component);
                }
        }

        public void BautSchaltplan(List<Bauelement> list)
        {
            // baut die bauelemente auf die oberfläche in ordnung
            for (int i = 0; i < list.Count; i++)
            {

                var bauelement = list[i];

                if (bauelement.Poisition.X == 0 || bauelement.Poisition.Y == 0)
                {
                    var pos = new Point(
                        selHeight * (i % 10),
                        selWidth * (i / 10));
                    bauelement.Poisition = pos;

                }

                bauelement.MyNode = aktuellBauelementListe.AddLast(bauelement);

            }

            for (int i = 0; i < akuelleSchaltplan.connections.Count; i++)
            {
                
                var startpoint = akuelleSchaltplan.connections[i].StartElement.Poisition;
                var endpoint = akuelleSchaltplan.connections[i].EndElement.Poisition;


            }
        }

    
        
        private void button2_Click(object sender, EventArgs e)
        {
            // durchlauft der schaltplan und prüft, ob die hat mind. 1 spannungquelle
            var counter = 1;
            for (int i = 0; akuelleSchaltplan.bauelements.Count > i; i++)
            {
                if (akuelleSchaltplan.bauelements[i].typeName == "SpannungQuelle")
                {
                    counter++;
                }  
            }
            if (counter == 1)
            {
                MessageBox.Show("Ein Schaltplan muss mindestens ein Spannungquelle haben");
                return;
            }
            
            bool[,] Verbindung = new bool[2,akuelleSchaltplan.bauelements.Count];
            for(int q=0; akuelleSchaltplan.bauelements.Count > q;q++)
            {
                Verbindung[0, q] = false;
                Verbindung[1, q] = false;

            }

            for (int i = 0; akuelleSchaltplan.bauelements.Count > i; i++)
            {
                // dürchlaüft alle connections und prüft ob gibt es überhaupt connection
                if (akuelleSchaltplan.connections.Count < 1)
                {
                    MessageBox.Show("Bitte Verbinden Sie die Bauelemente");
                    return;
                }
                // durchlaüft alle bauelemente und prüft ob alle sind mind. einmal als startelemente/endelement erstellt
                for (int j = 0; akuelleSchaltplan.connections.Count > j; j++)
                {
                    if (akuelleSchaltplan.connections[j].StartElement.Name == akuelleSchaltplan.bauelements[i].Name)
                    {
                        Verbindung[0, i] = true;
                        
                    }
                    if (akuelleSchaltplan.connections[j].EndElement.Name == akuelleSchaltplan.bauelements[i].Name)
                    {
                        Verbindung[1, i] = true;
                        
                    }
                }
            }
           
            for (int d = 0; akuelleSchaltplan.bauelements.Count > d; d++)
            {
                if (Verbindung[0, d] == false || Verbindung[1, d] == false)
                {
                    MessageBox.Show("Bitte Prüfen Sie, ob alle Bauelemente richtig verbunden haben");
                    return;
                }
            }
            // sucht die spannungquelle/battery aus die schaltplan
            var Battery=akuelleSchaltplan.FindStartElement();
            
            var summe=0.1;
            //vorbreitet die schaltplan für die schaltplan berechnung ( R(Ges) ) 
            akuelleSchaltplan.prepare();

            summe =akuelleSchaltplan.CalculateLayerResistance(Battery);
            MessageBox.Show(summe.ToString() + "R(Ges)");
            var I = Berechnung.Stromberechnung(230, summe);

           MessageBox.Show(I.ToString() + "I(Ges)");
        // vorbreitet die schaltplan für die schaltplan berechnung teil (spannung)
           akuelleSchaltplan.prepare();

            Battery.I = I;
            // Battery/SpannungQuelle spannung ist immer 230 
            Battery.U = 230;
            akuelleSchaltplan.CalculateLayer(Battery, I, 230);
            
           

           













        }
       
       

        private void surface_Load(object sender, EventArgs e)
        {

        }
        private XmlDocument Save()
        {
            // baut XML document
            var xmlDoc = new XmlDocument();

            var schaltLPlanXml = xmlDoc.CreateElement("Schaltplan");

            xmlDoc.AppendChild(schaltLPlanXml);
            var componentNodeXml = xmlDoc.CreateElement("Bauelements");

            schaltLPlanXml.AppendChild(componentNodeXml);

            var connectionsNodeXml = xmlDoc.CreateElement("Connections");

            schaltLPlanXml.AppendChild(connectionsNodeXml);


            // Durchlaufen aller bauelemente
            foreach (var component in akuelleSchaltplan.bauelements)
            {
                var bauelementDoc = xmlDoc.CreateElement("bauelement");
                if (bauelementDoc != null)
                {
                    bauelementDoc.SetAttribute("Name", component.Name);
                    bauelementDoc.SetAttribute("TypeName", component.typeName);
                    bauelementDoc.SetAttribute("X", component.Poisition.X.ToString());
                    bauelementDoc.SetAttribute("Y", component.Poisition.Y.ToString());
                    componentNodeXml.AppendChild(bauelementDoc);
                }


            }


            // Durchlaufen aller connections
        
            foreach (var Connection in akuelleSchaltplan.connections)
            {
                var ConnectionXML = xmlDoc.CreateElement("Connection");
                if (ConnectionXML != null)
                {
                    ConnectionXML.SetAttribute("StartElement", Connection.StartElement.Name);
                    ConnectionXML.SetAttribute("EndElement", Connection.EndElement.Name);
                }

                connectionsNodeXml.AppendChild(ConnectionXML);

                // ...

            }
            return xmlDoc;
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // prüft ob user hat schön ein "platz" gewält wo er wunsch diese xml datei  zu speicerhn . wenn nein dann rüft die save dialogwindow an.

            var xmlDoc = new XmlDocument();
            xmlDoc = Save();
            if (Pathdirectory == null)
            {
                saveAsToolStripMenuItem_Click(sender, e);
               
            }
            else
            {
                xmlDoc.Save(Pathdirectory);
            }
            


        }

                
      

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            var xmlDoc = new XmlDocument();
            xmlDoc = Save();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML-File | *.xml";
            



            // prüft ob user möchte die XML  datei in diese "platz" speichern.
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Pathdirectory = saveFileDialog.FileName;
                xmlDoc.Save(saveFileDialog.FileName);
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // wenn user EReihe14 wählt
            label1.Text = "";
            EReihe12.Show();
            EReihe24.Hide();
            textBox1.Hide();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            // wenn user EReihe24wählt
            label1.Text = "";
            EReihe24.Show();
            EReihe12.Hide();
            textBox1.Hide();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = ".";
            // offnet nur XMl datei
            openFileDialog1.Filter = "Xml files (*.xml)|*.xml";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            string name = null;
            int i = 0;
            int zahl1 = 0;
            int zahl2 = 0;
            // user könnte datei wählen 
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // XML reader der leset die xml datei
                    XmlReader reader = XmlReader.Create(openFileDialog1.FileName);
                    // macht aktuelleschaltplan liste leer 
                    akuelleSchaltplan.bauelements.Clear();
                    akuelleSchaltplan.connections.Clear();
                    Refresh();

                    while (reader.Read())
                    {
                        // sucht "Bauelement" aus xml datei
                            if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "bauelement"))

                        {
                            //prüft ob gibt es attributes für diese bauelement 
                            if (reader.HasAttributes)
                            {
                                // speichern alle wichtige information von die xml datei
                                TypeDasBauelement(reader.GetAttribute("TypeName"));
                                var BauelementPt = new Point(Convert.ToInt32(reader.GetAttribute("X")), Convert.ToInt32(reader.GetAttribute("Y")));
                                akuelleSchaltplan.bauelements[i].Poisition = BauelementPt;
                                akuelleSchaltplan.bauelements[i].Name = reader.GetAttribute("Name");
                                Refresh();
                                i++;

                            }
                        }
                            // sucht " connection" aus xml datei
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Connection"))
                        {
                            // prüft ob gibt es attributes für diese bauelement 

                            if (reader.HasAttributes)
                            {
                                // speichert die wichtige information
                                var comp1 = reader.GetAttribute("StartElement");
                                var comp2 = reader.GetAttribute("EndElement");
                                // sucht die bauelemnte aus bauelemente liste 
                                for (int j = 0; j < akuelleSchaltplan.bauelements.Count(); j++)




                                {
                                    
                                    if (comp1 == akuelleSchaltplan.bauelements[j].Name)
                                    {
                                        zahl1 = j;
                                       // MessageBox.Show(Convert.ToString(zahl1));

                                    }
                                    if (comp2 == akuelleSchaltplan.bauelements[j].Name)
                                    {
                                        zahl2 = j;
                                      //  MessageBox.Show(Convert.ToString(zahl2));
                                    }
                                }
                            }
                            // baut das schaltplan 
                            var connection = new Connection(akuelleSchaltplan.bauelements[zahl1], akuelleSchaltplan.bauelements[zahl2]);
                            akuelleSchaltplan.connections.Add(connection);
                            Refresh();
                            Invalidate();
                        }


                                









                    }
                }



                catch (Exception ex)
                {

                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }

            
            

            }

        }

        private void EReihe12_Scroll(object sender, ScrollEventArgs e)
        {
            
            switch (EReihe12.Value)
            {
                //Werte fuer Widerstand
                case 1:
                    surface.WiderstandSelected(100);
                    label1.Text = "R=100 Ohm";
                    break;
                case 2:
                    surface.WiderstandSelected(200);
                    label1.Text = "R=200 Ohm";
                    break;
                case 3:
                    surface.WiderstandSelected(300);
                    label1.Text = "R=300 Ohm";
                    break;
                case 4:
                    surface.WiderstandSelected(1000);
                    label1.Text = "R=1000 Ohm";
                    break;
                case 5:
                    surface.WiderstandSelected(10000);
                    label1.Text = "R=10000 Ohm";
                    break;

        }
            
            
        
            
        }






        private void EReihe24_Scroll(object sender, ScrollEventArgs e)
        {
           
            switch (EReihe24.Value)
        {
                //Werte fuer Widerstand
            case 1:
                surface.WiderstandSelected(100);
                    label1.Text = "R=100 Ohm";
                    
                    
                    break;
            case 2:
                surface.WiderstandSelected(200);
                    label1.Text = "R=200 Ohm";
                  
                    
                    break;
            case 3:
                surface.WiderstandSelected(300);
                    label1.Text = "R=300 Ohm";
                    
                   
                    break;
            case 4:
                surface.WiderstandSelected(1000);
                    label1.Text = "R=1000 Ohm";
                 
                  
                    break;
            case 5:
                surface.WiderstandSelected(10000);
                    label1.Text = "R=10000 Ohm";
                    
                    
                    break;

        }
           
        }

        private void surface_Paint(object sender, PaintEventArgs e)
        {
            // verbendet die surface mit multimeter
            msl.formGraphics = this.CreateGraphics();
            msl.drawpaint(e);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
           // verbendet die panel mit multimeter
            msl.formGraphics = this.CreateGraphics();
        
            msl.drawpaint(e);
        }
        //Neue Schaltplan waehlen 
        private void neuSchaltplanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            akuelleSchaltplan.bauelements.Clear();
            akuelleSchaltplan.connections.Clear();
            Refresh();
        }

        private void wertEingebenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EReihe12.Hide();
            EReihe24.Hide();
            textBox1.Show();
           




        }

        private void button3_Click(object sender, EventArgs e)
        {
            var wert = textBox1.Text;
            surface.WiderstandSelected(Convert.ToInt32(wert));
                
        }
    }



      


    }
    
        
    

