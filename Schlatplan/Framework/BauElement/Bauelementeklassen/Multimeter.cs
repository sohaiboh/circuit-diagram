using Schaltplan.Framework.Gemeric;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Schaltplan.Framework.BauElement
{  //die Klasse Multimetre erbt von der HaunptKlasse Bauelement und die beide sind dann automatisch verbunden
    public class Multimeter //:BaseBauelement
    {
       public double stage;
        /// <summary>
        /// Diese Funktionen ermitteln den DigitaZahl von einer  Konvertierung zurückgegebenen  Wert 
        /// </summary>
        /// <param name="stage"></param>
        float ZeichenOffsetX = 10;
        float ZeichenBreite = 65;
        float ZeichenDeltaX = 110;
        float ZeichenOffsetY = 45;
        float ZeichenHoehe = 65;
        float ZeichenDicke = 5;
        float StrichBreite = 2;  // oder hier das gleiche wie ZeichenDicke???
        float PunktDicke = 10;
        float PunktHoehe = 10;
        int PointIndex = -1;
        //e.Graphics.DrawEllipse(new Pen(Color.Black, StrichBreite), ZeichenOffsetX+Position*ZeichenDeltaX + ZeichenBreite+2*ZeichenDicke, ZeichenOffsetY + 2* ZeichenHoehe + ZeichenDicke - PunktDicke / 2, PunktDicke, PunktHoehe);
        public System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        public System.Drawing.Graphics formGraphics;

        private void ZeichneSegmentPunkt(Int32 Position, System.Windows.Forms.PaintEventArgs e)
        {
            
            
            
            formGraphics.FillEllipse(myBrush, new Rectangle((int)((ZeichenOffsetX + Position * ZeichenDeltaX + ZeichenBreite + 2 * ZeichenDicke)), (int)(ZeichenOffsetY + 2 * ZeichenHoehe + ZeichenDicke - PunktDicke / 2), (int)(PunktDicke), (int)(PunktHoehe)));
            myBrush.Dispose();
            formGraphics.Dispose();
        }
        private void ZeichneSegmentF(UInt32 Position, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Black, StrichBreite), ZeichenOffsetX + Position * ZeichenDeltaX, ZeichenOffsetY, ZeichenOffsetX + Position * ZeichenDeltaX + ZeichenBreite + ZeichenDicke, ZeichenOffsetY);
        }
        private void ZeichneSegmentB(UInt32 Position, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Black, StrichBreite), ZeichenOffsetX + Position * ZeichenDeltaX + ZeichenBreite + ZeichenDicke, ZeichenOffsetY + ZeichenHoehe + 2 * ZeichenDicke, ZeichenOffsetX + Position * ZeichenDeltaX + ZeichenBreite + ZeichenDicke, ZeichenOffsetY + 2 * ZeichenHoehe + 2 * ZeichenDicke);
        }
        private void ZeichneSegmentA(UInt32 Position, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Black, StrichBreite), ZeichenOffsetX + Position * ZeichenDeltaX + ZeichenBreite + ZeichenDicke, ZeichenOffsetY + ZeichenDicke, ZeichenOffsetX + Position * ZeichenDeltaX + ZeichenBreite + ZeichenDicke, ZeichenOffsetY + ZeichenHoehe + ZeichenDicke);
        }
        private void ZeichneSegmentC(UInt32 Position, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Black, StrichBreite), ZeichenOffsetX + Position * ZeichenDeltaX, ZeichenOffsetY + 2 * ZeichenHoehe + 2 * ZeichenDicke, ZeichenOffsetX + Position * ZeichenDeltaX + ZeichenBreite + ZeichenDicke, ZeichenOffsetY + 2 * ZeichenHoehe + 2 * ZeichenDicke);
        }
        private void ZeichneSegmentD(UInt32 Position, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Black, StrichBreite), ZeichenOffsetX + Position * ZeichenDeltaX, ZeichenOffsetY + ZeichenHoehe + 2 * ZeichenDicke, ZeichenOffsetX + Position * ZeichenDeltaX, ZeichenOffsetY + 2 * ZeichenHoehe + 2 * ZeichenDicke);
        }
        private void ZeichneSegmentE(UInt32 Position, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Black, StrichBreite), ZeichenOffsetX + Position * ZeichenDeltaX, ZeichenOffsetY + ZeichenDicke, ZeichenOffsetX + Position * ZeichenDeltaX, ZeichenOffsetY + ZeichenHoehe + ZeichenDicke);
        }
        private void ZeichneSegmentG(UInt32 Position, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Black, StrichBreite), ZeichenOffsetX + Position * ZeichenDeltaX, ZeichenOffsetY + ZeichenHoehe + ZeichenDicke, ZeichenOffsetX + Position * ZeichenDeltaX + ZeichenBreite + ZeichenDicke, ZeichenOffsetY + ZeichenHoehe + ZeichenDicke);
        }
        public PaintEventArgs Arg ;
        public void drawpaint(PaintEventArgs e)
        {
            Arg = e;
            if (stage == 1)
            {
                /*  if (PointIndex != -1)
                      ZeichneSegmentPunkt(PointIndex, e);*/
                ZeichneSegmentA(0, e); ZeichneSegmentB(0, e); ZeichneSegmentC(0, e); ZeichneSegmentD(0, e); ZeichneSegmentE(0, e); ZeichneSegmentF(0, e);
                ZeichneSegmentA(1, e); ZeichneSegmentB(1, e); ZeichneSegmentC(1, e); ZeichneSegmentD(1, e); ZeichneSegmentE(1, e); ZeichneSegmentF(1, e);
                ZeichneSegmentA(2, e); ZeichneSegmentB(2, e); ZeichneSegmentC(2, e); ZeichneSegmentD(2, e); ZeichneSegmentE(2, e); ZeichneSegmentF(2, e);
                ZeichneSegmentA(3, e); ZeichneSegmentB(3, e);

            }
            if (stage == 2)
            {
                //if (PointIndex != -1)
                //    ZeichneSegmentPunkt(PointIndex, e);
                ZeichneSegmentA(0, e); ZeichneSegmentB(0, e); ZeichneSegmentC(0, e); ZeichneSegmentD(0, e); ZeichneSegmentE(0, e); ZeichneSegmentF(0, e);
                ZeichneSegmentA(1, e); ZeichneSegmentB(1, e); ZeichneSegmentC(1, e); ZeichneSegmentD(1, e); ZeichneSegmentE(1, e); ZeichneSegmentF(1, e);
                ZeichneSegmentA(2, e); ZeichneSegmentB(2, e); ZeichneSegmentC(2, e); ZeichneSegmentD(2, e); ZeichneSegmentE(2, e); ZeichneSegmentF(2, e);
                ZeichneSegmentA(3, e); ZeichneSegmentC(3, e); ZeichneSegmentD(3, e); ZeichneSegmentF(3, e); ZeichneSegmentG(3, e);

            }
            if (stage == 3)
            {
                //if (PointIndex != -1)
                //    ZeichneSegmentPunkt(PointIndex, e);
                ZeichneSegmentA(0, e); ZeichneSegmentB(0, e); ZeichneSegmentC(0, e); ZeichneSegmentD(0, e); ZeichneSegmentE(0, e); ZeichneSegmentF(0, e);
                ZeichneSegmentA(1, e); ZeichneSegmentB(1, e); ZeichneSegmentC(1, e); ZeichneSegmentD(1, e); ZeichneSegmentE(1, e); ZeichneSegmentF(1, e);
                ZeichneSegmentA(2, e); ZeichneSegmentB(2, e); ZeichneSegmentC(2, e); ZeichneSegmentD(2, e); ZeichneSegmentE(2, e); ZeichneSegmentF(2, e);
                ZeichneSegmentA(3, e); ZeichneSegmentB(3, e); ZeichneSegmentC(3, e); ZeichneSegmentF(3, e); ZeichneSegmentG(3, e);

            }
            if (stage == 4)
            {
                //if (PointIndex != -1)
                //    ZeichneSegmentPunkt(PointIndex, e);
                ZeichneSegmentA(0, e); ZeichneSegmentB(0, e); ZeichneSegmentC(0, e); ZeichneSegmentD(0, e); ZeichneSegmentE(0, e); ZeichneSegmentF(0, e);
                ZeichneSegmentA(1, e); ZeichneSegmentB(1, e); ZeichneSegmentC(1, e); ZeichneSegmentD(1, e); ZeichneSegmentE(1, e); ZeichneSegmentF(1, e);
                ZeichneSegmentA(2, e); ZeichneSegmentB(2, e); ZeichneSegmentC(2, e); ZeichneSegmentD(2, e); ZeichneSegmentE(2, e); ZeichneSegmentF(2, e);
                ZeichneSegmentA(3, e); ZeichneSegmentB(3, e); ZeichneSegmentE(3, e); ZeichneSegmentG(3, e);

            }
            if (stage == 5)
            {
                //if (PointIndex != -1)
                //    ZeichneSegmentPunkt(PointIndex, e);
                ZeichneSegmentA(0, e); ZeichneSegmentB(0, e); ZeichneSegmentC(0, e); ZeichneSegmentD(0, e); ZeichneSegmentE(0, e); ZeichneSegmentF(0, e);
                ZeichneSegmentA(1, e); ZeichneSegmentB(1, e); ZeichneSegmentC(1, e); ZeichneSegmentD(1, e); ZeichneSegmentE(1, e); ZeichneSegmentF(1, e);
                ZeichneSegmentA(2, e); ZeichneSegmentB(2, e); ZeichneSegmentC(2, e); ZeichneSegmentD(2, e); ZeichneSegmentE(2, e); ZeichneSegmentF(2, e);
                ZeichneSegmentB(3, e); ZeichneSegmentC(3, e); ZeichneSegmentE(3, e); ZeichneSegmentF(3, e); ZeichneSegmentG(3, e);

            }
            if (stage == 6)
            {
                //if (PointIndex != -1)
                //    ZeichneSegmentPunkt(PointIndex, e);
                ZeichneSegmentA(0, e); ZeichneSegmentB(0, e); ZeichneSegmentC(0, e); ZeichneSegmentD(0, e); ZeichneSegmentE(0, e); ZeichneSegmentF(0, e);
                ZeichneSegmentA(1, e); ZeichneSegmentB(1, e); ZeichneSegmentC(1, e); ZeichneSegmentD(1, e); ZeichneSegmentE(1, e); ZeichneSegmentF(1, e);
                ZeichneSegmentA(2, e); ZeichneSegmentB(2, e); ZeichneSegmentC(2, e); ZeichneSegmentD(2, e); ZeichneSegmentE(2, e); ZeichneSegmentF(2, e);
                ZeichneSegmentB(3, e); ZeichneSegmentC(3, e); ZeichneSegmentD(3, e); ZeichneSegmentE(3, e); ZeichneSegmentF(3, e); ZeichneSegmentG(3, e);

            }
            if (stage == 7)
            {
                //if (PointIndex != -1)
                //    ZeichneSegmentPunkt(PointIndex, e);
                ZeichneSegmentA(0, e); ZeichneSegmentB(0, e); ZeichneSegmentC(0, e); ZeichneSegmentD(0, e); ZeichneSegmentE(0, e); ZeichneSegmentF(0, e);
                ZeichneSegmentA(1, e); ZeichneSegmentB(1, e); ZeichneSegmentC(1, e); ZeichneSegmentD(1, e); ZeichneSegmentE(1, e); ZeichneSegmentF(1, e);
                ZeichneSegmentA(2, e); ZeichneSegmentB(2, e); ZeichneSegmentC(2, e); ZeichneSegmentD(2, e); ZeichneSegmentE(2, e); ZeichneSegmentF(2, e);
                ZeichneSegmentA(3, e); ZeichneSegmentB(3, e); ZeichneSegmentF(3, e);

            }
            if (stage == 8)
            {
                //if (PointIndex != -1)
                //    ZeichneSegmentPunkt(PointIndex, e);
                ZeichneSegmentA(0, e); ZeichneSegmentB(0, e); ZeichneSegmentC(0, e); ZeichneSegmentD(0, e); ZeichneSegmentE(0, e); ZeichneSegmentF(0, e);
                ZeichneSegmentA(1, e); ZeichneSegmentB(1, e); ZeichneSegmentC(1, e); ZeichneSegmentD(1, e); ZeichneSegmentE(1, e); ZeichneSegmentF(1, e);
                ZeichneSegmentA(2, e); ZeichneSegmentB(2, e); ZeichneSegmentC(2, e); ZeichneSegmentD(2, e); ZeichneSegmentE(2, e); ZeichneSegmentF(2, e);
                ZeichneSegmentA(3, e); ZeichneSegmentB(3, e); ZeichneSegmentC(3, e); ZeichneSegmentD(3, e); ZeichneSegmentE(3, e); ZeichneSegmentF(3, e); ZeichneSegmentG(3, e);

            }
            if (stage == 9)
            {
                //if (PointIndex != -1)
                //    ZeichneSegmentPunkt(PointIndex, e);
                ZeichneSegmentA(0, e); ZeichneSegmentB(0, e); ZeichneSegmentC(0, e); ZeichneSegmentD(0, e); ZeichneSegmentE(0, e); ZeichneSegmentF(0, e);
                ZeichneSegmentA(1, e); ZeichneSegmentB(1, e); ZeichneSegmentC(1, e); ZeichneSegmentD(1, e); ZeichneSegmentE(1, e); ZeichneSegmentF(1, e);
                ZeichneSegmentA(2, e); ZeichneSegmentB(2, e); ZeichneSegmentC(2, e); ZeichneSegmentD(2, e); ZeichneSegmentE(2, e); ZeichneSegmentF(2, e);
                ZeichneSegmentA(3, e); ZeichneSegmentB(3, e); ZeichneSegmentC(3, e); ZeichneSegmentE(3, e); ZeichneSegmentF(3, e); ZeichneSegmentG(3, e);

            }
            if (stage == 0)
            {
                //if (PointIndex != -1)
                //    ZeichneSegmentPunkt(PointIndex, e);
                ZeichneSegmentA(0, e); ZeichneSegmentB(0, e); ZeichneSegmentC(0, e); ZeichneSegmentD(0, e); ZeichneSegmentE(0, e); ZeichneSegmentF(0, e);
                ZeichneSegmentA(1, e); ZeichneSegmentB(1, e); ZeichneSegmentC(1, e); ZeichneSegmentD(1, e); ZeichneSegmentE(1, e); ZeichneSegmentF(1, e);
                ZeichneSegmentA(2, e); ZeichneSegmentB(2, e); ZeichneSegmentC(2, e); ZeichneSegmentD(2, e); ZeichneSegmentE(2, e); ZeichneSegmentF(2, e);
                ZeichneSegmentA(3, e); ZeichneSegmentB(3, e); ZeichneSegmentC(3, e); ZeichneSegmentD(3, e); ZeichneSegmentE(3, e); ZeichneSegmentF(3, e);

            }

            if (stage < 10 && PointIndex != -1)
            {
                if (stage.ToString().Length == 5)
                {
                    int VorKommaZahl = int.Parse(stage.ToString().Split(',')[0]);
                    int NachKommazahl = int.Parse(stage.ToString().Split(',')[1]);
                    DrawAt(0, VorKommaZahl);
                    ZeichneSegmentPunkt(PointIndex, e);
                    switch (NachKommazahl.ToString().Length)
                    {
                        case 1:
                            DrawAt(1, 0);
                            DrawAt(2, 0);
                            DrawAt(3, int.Parse(NachKommazahl.ToString()[0].ToString()));
                            break;
                        case 2:
                            DrawAt(1, 0);
                            DrawAt(2, int.Parse(NachKommazahl.ToString()[0].ToString()));
                            DrawAt(3, int.Parse(NachKommazahl.ToString()[1].ToString()));
                            break;
                        case 3:
                            DrawAt(3, int.Parse(NachKommazahl.ToString()[2].ToString()));
                            DrawAt(2, int.Parse(NachKommazahl.ToString()[1].ToString()));
                            DrawAt(1, int.Parse(NachKommazahl.ToString()[0].ToString()));
                            break;
                        default:
                            break;
                    }


                }
                else
                {
                    int VorKommaZahl = int.Parse(stage.ToString().Split(',')[0]);
                    int NachKommazahl = int.Parse(stage.ToString().Split(',')[1]);
                    DrawAt(0, VorKommaZahl);
                    ZeichneSegmentPunkt(PointIndex, e);
                    switch (stage.ToString().Length)
                    {
                        case 3:
                            DrawAt(1, NachKommazahl);
                            DrawAt(2, 0);
                            DrawAt(3, 0);
                            break;
                        case 4:
                            DrawAt(1, 0);
                            DrawAt(2, int.Parse(NachKommazahl.ToString()[0].ToString()));
                            break;

                    }

                }
            }
            if (stage >= 10 && stage <= 9999/*&&PointIndex==-1*/)
            {
                //if (PointIndex != -1 && PointIndex > 3)
                //    ZeichneSegmentPunkt(PointIndex, e);
                int VorKommaZahl = int.Parse(stage.ToString().Split(',')[0]);
                int NachKommazahl = -1;
                if (PointIndex != -1)
                    NachKommazahl = int.Parse(stage.ToString().Split(',')[1]);

                #region Kein Komma
                if (PointIndex == -1)
                {
                    if (stage == stage / 10)
                    {

                    }
                    double tausender = (stage - stage % 1000) / 1000;
                    DrawAt(0, (int)tausender);

                    double Stage = stage - tausender * 1000;
                    double hunderter = (Stage - Stage % 100) / 100;
                    DrawAt(1, (int)hunderter);


                    Stage = Stage - hunderter * 100;
                    double zehner = (Stage - Stage % 10) / 10;
                    DrawAt(2, (int)zehner);


                    Stage = Stage - zehner * 10;
                    double einer = (Stage - Stage % 1) / 1;
                    DrawAt(3, (int)einer);


                }


                #endregion

                #region Bearbeitung von kommabehafteten Zahlen
                else
                {
                    int laenge = VorKommaZahl.ToString().Length;
                    switch (laenge)
                    {
                        case 1:
                            DrawAt(0, VorKommaZahl);
                            break;
                        case 2:
                            DrawAt(0, int.Parse(VorKommaZahl.ToString()[0].ToString()));
                            DrawAt(1, int.Parse(VorKommaZahl.ToString()[1].ToString()));
                            break;
                        default:
                            DrawAt(0, int.Parse(VorKommaZahl.ToString()[0].ToString()));
                            DrawAt(1, int.Parse(VorKommaZahl.ToString()[1].ToString()));
                            DrawAt(2, int.Parse(VorKommaZahl.ToString()[2].ToString()));
                            break;
                    }
                    laenge = NachKommazahl.ToString().Length;
                    switch (laenge)
                    {
                        case 1:
                            DrawAt(3, NachKommazahl);
                            break;
                        case 2:
                            DrawAt(3, int.Parse(NachKommazahl.ToString()[1].ToString()));
                            DrawAt(2, int.Parse(NachKommazahl.ToString()[0].ToString()));
                            break;
                        case 3:
                            DrawAt(3, int.Parse(NachKommazahl.ToString()[1].ToString()));
                            DrawAt(2, int.Parse(NachKommazahl.ToString()[0].ToString()));
                            break;
                        default:
                            DrawAt(3, int.Parse(NachKommazahl.ToString()[2].ToString()));
                            DrawAt(2, int.Parse(NachKommazahl.ToString()[1].ToString()));
                            DrawAt(1, int.Parse(NachKommazahl.ToString()[0].ToString()));
                            break;
                    }
                    ZeichneSegmentPunkt(PointIndex, e);
                }
                #endregion

            }
            if (stage > 9999)
            {
               
                ZeichneSegmentA(0, e); ZeichneSegmentB(0, e); ZeichneSegmentC(0, e); ZeichneSegmentD(0, e); ZeichneSegmentE(0, e); ZeichneSegmentF(0, e);
                ZeichneSegmentA(1, e); ZeichneSegmentB(1, e); ZeichneSegmentC(1, e); ZeichneSegmentD(1, e); ZeichneSegmentE(1, e); ZeichneSegmentF(1, e);
                ZeichneSegmentA(2, e); ZeichneSegmentB(2, e); ZeichneSegmentC(2, e); ZeichneSegmentD(2, e); ZeichneSegmentE(2, e); ZeichneSegmentF(2, e);
                ZeichneSegmentA(3, e); ZeichneSegmentB(3, e); ZeichneSegmentC(3, e); ZeichneSegmentD(3, e); ZeichneSegmentE(3, e); ZeichneSegmentF(3, e);
            }


        }

        void DrawAt(uint Position, int nbre)
        {
            if (nbre == 0)
            {
                ZeichneSegmentA(Position, Arg); ZeichneSegmentB(Position, Arg); ZeichneSegmentC(Position, Arg); ZeichneSegmentD(Position, Arg); ZeichneSegmentE(Position, Arg); ZeichneSegmentF(Position, Arg);
            }
            if (nbre == 1)
            {
                ZeichneSegmentA(Position, Arg); ZeichneSegmentB(Position, Arg);
            }
            if (nbre == 2)
            {
                ZeichneSegmentA(Position, Arg); ZeichneSegmentC(Position, Arg); ZeichneSegmentD(Position, Arg); ZeichneSegmentF(Position, Arg); ZeichneSegmentG(Position, Arg);
            }
            if (nbre == 3)
            {
                ZeichneSegmentA(Position, Arg); ZeichneSegmentB(Position, Arg); ZeichneSegmentC(Position, Arg); ZeichneSegmentF(Position, Arg); ZeichneSegmentG(Position, Arg);
            }
            if (nbre == 4)
            {
                ZeichneSegmentA(Position, Arg); ZeichneSegmentB(Position, Arg); ZeichneSegmentE(Position, Arg); ZeichneSegmentG(Position, Arg);
            }
            if (nbre == 5)
            {
                ZeichneSegmentB(Position, Arg); ZeichneSegmentC(Position, Arg); ZeichneSegmentE(Position, Arg); ZeichneSegmentF(Position, Arg); ZeichneSegmentG(Position, Arg);
            }
            if (nbre == 6)
            {
                ZeichneSegmentB(Position, Arg); ZeichneSegmentC(Position, Arg); ZeichneSegmentD(Position, Arg); ZeichneSegmentE(Position, Arg); ZeichneSegmentF(Position, Arg); ZeichneSegmentG(Position, Arg);
            }
            if (nbre == 7)
            {
                ZeichneSegmentA(Position, Arg); ZeichneSegmentB(Position, Arg); ZeichneSegmentF(Position, Arg);
            }
            if (nbre == 8)
            {
                ZeichneSegmentA(Position, Arg); ZeichneSegmentB(Position, Arg); ZeichneSegmentC(Position, Arg); ZeichneSegmentD(Position, Arg); ZeichneSegmentE(Position, Arg); ZeichneSegmentF(Position, Arg); ZeichneSegmentG(Position, Arg);
            }
            if (nbre == 9)
            {
                ZeichneSegmentA(Position, Arg); ZeichneSegmentB(Position, Arg); ZeichneSegmentC(Position, Arg); ZeichneSegmentE(Position, Arg); ZeichneSegmentF(Position, Arg); ZeichneSegmentG(Position, Arg);
            }
        }
        double ConvertToAmountFromBasis(string endEinheit, double value)
        {
            if (value < 0) throw new ArgumentOutOfRangeException("Der Wert darf nicht negativ sein");
            if (endEinheit.Length != 2 && endEinheit.Length != 1) throw new ArgumentOutOfRangeException("Falsches Einheitformat");
            if (endEinheit.Length == 1) return value;
            double? newValue;
            string Basis = endEinheit.Contains("A") ? "A" : "V";
            char einheit = endEinheit[0];
            switch (einheit)
            {
                case 'G':
                    newValue = value / 1000000000;
                    break;
                case 'M':
                    newValue = value / 1000000;
                    break;
                case 'k':
                    newValue = value / 1000;
                    break;
                case 'm':
                    newValue = value * 1000;
                    break;
                case 'μ':
                    newValue = value * 1000000;
                    break;
                case 'n':
                    newValue = value * 1000000000;
                    break;
                default:
                    throw new Exception("keine gültige Einheit");

            }
            return newValue.Value;
        }
        string[] AmpereEiheiten = { "GA", "MA", "kA", "A", "mA", "μA", "nA" };
        string[] VoltEinheiten = { "GV", "MV", "kV", "V", "mV", "μV", "nV" };
        double ConvertToBasisAmount(string startEinheit, double value)
        {
            if (value < 0) throw new ArgumentOutOfRangeException("Der Wert darf nicht negativ sein");
            if (startEinheit.Length != 2 && startEinheit.Length != 1) throw new ArgumentOutOfRangeException("Falsches Einheitformat");
            if (startEinheit.Length == 1) return value;
            double? newValue;

            //Untereinheit extrahieren
            char einheit = startEinheit[0];


            //verschiedene Konvertierungsmöglichkeiten
            switch (einheit)
            {
                case 'G':
                    newValue = value * 1000000000;
                    break;
                case 'M':
                    newValue = value * 1000000;
                    break;
                case 'k':
                    newValue = value * 1000;
                    break;
                case 'm':
                    newValue = value / 1000;
                    break;
                case 'μ':
                    newValue = value / 1000000;
                    break;
                case 'n':
                    newValue = value / 1000000000;
                    break;
                default:
                    throw new Exception("keine gültige Einheit");

            }
            return newValue.Value;
        }
        double EinheitConverter(string startEinheit, string endEinheit, double value)
        {
            // Es nimmt keinen negativen Wert an
            if (value < 0) throw new ArgumentOutOfRangeException("Der Wert darf nicht negativ sein");

            //Die Start- und Endeinheiten müssen entweder ein-Zeichen oder zwei-Zeichen sein
            if (startEinheit.Length != 2 && endEinheit.Length != 2 && startEinheit.Length != 1 && endEinheit.Length != 1) throw new ArgumentOutOfRangeException("Falsches Einheitformat");
            //Wenn die Einheiten gleich sind, dann ist keine Konvertierung mehr nötig
            if (startEinheit == endEinheit) return value;

            //Untereinheit extrahieren 
            char einheit = startEinheit[0];
            //Kovertierung der Starteinheit zu Basiseinheit, fals das nicht so war 
            if (einheit != 'V' && einheit != 'A') value = ConvertToBasisAmount(startEinheit, value);
            //den neuen Wert zurückgeben
            return ConvertToAmountFromBasis(endEinheit, value);

        }
        public void callmulti(string WertVonBauelement)
        {
            string eingabe = WertVonBauelement; // value wird in 'eingabe' gespeichert
            eingabe = eingabe.Replace('.', ',');
            double wert;
            bool convert = double.TryParse(eingabe, out wert); // 'eingabe' wird hier als double convertiert 

            if (convert)
            {
                //wert = EinheitConverter(StartEinheit_cmbbx.Text, EndEinheit_cmbbx.Text, wert);
                wert = Math.Round(wert, 0);// fals noetig wird 'eingabe gerundert'
                                           //label1.Text = wert.ToString() + " " + EndEinheit_cmbbx.SelectedItem.ToString(); // 'eingabe wird als string zurueck gegeben'


                try
                {
                    stage = wert;   // Int32.Parse(TextBox.Text);
                    string Nbre = wert.ToString();
                    if (Nbre.Contains("."))
                        PointIndex = Nbre.IndexOf('.');
                    else if (Nbre.Contains(",")) PointIndex = Nbre.IndexOf(',') - 1;
                    else PointIndex = -1;
                    
                  

                }
                catch (Exception)
                {
                }
            }
            else
            {
                //label1.Text = "Ihre Eingabe ist falsch";
            }
        }
        /*
        private readonly BauelementResource _resource;
        public BauelementResource Resource { get { return _resource; } }


        public Multimeter(string name) : base(name, new Size(800, 600))
        {
            _resource = BauelementResource.Create("Multimeter");
            new Size(_resource.Width, _resource.Height);

        }

        public  void Render(Resources resource, Graphics g)
        {
            g.DrawImage(_resource.Image, new Rectangle(Poisition, Size));
            if (!string.IsNullOrWhiteSpace(Name))
            {
                var size = g.MeasureString(Name, resource.TextFont);
                g.DrawString(Name, resource.TextFont, Brushes.Black, Poisition.X + (float)size.Width / 2,
                    Poisition.Y - size.Height);
            }
        }

    */

    }
}
