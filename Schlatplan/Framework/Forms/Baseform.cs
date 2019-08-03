﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schaltplan.Framework.Forms
{
    public class Baseform : Form 
    {
        // errors with loading the file path

        public static DialogResult MsgWarn(string message , MessageBoxButtons mb= MessageBoxButtons.OK)
        {
            return MessageBox.Show(message, Program.Caption, mb, MessageBoxIcon.Warning);
        }
        public static DialogResult Msginfo(string message, MessageBoxButtons mb = MessageBoxButtons.OK)
        {
            return MessageBox.Show(message, Program.Caption, mb, MessageBoxIcon.Information);
        }
        public static DialogResult MsgError(string message, MessageBoxButtons mb = MessageBoxButtons.OK)
        {
            return MessageBox.Show(message, Program.Caption, mb, MessageBoxIcon.Error);
        }



    }
}
