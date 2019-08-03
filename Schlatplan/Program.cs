using Schaltplan.Framework.BauElement;
using Schaltplan.Framework.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Schaltplan.Framework.Gemeric;

namespace Schaltplan
{
    static class Program
    {
        public const string Caption = "Schaltplan design";
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var bauelementManger = new BauelementResource();

            using (var form = new MainForm(bauelementManger))
            {
                Application.Run(form);
            }
        }
    }
}
