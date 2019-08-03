using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices; //required for dll import

namespace Unicode_Typing_Tool_For_Mizo
{
      

    public partial class Form1 : Form
    {
        // DLL libraries used to manage hotkeys
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public Form1()
        {
            InitializeComponent();
            // Modifier keys codes: Alt = 1, Ctrl = 2, Shift = 4, Win = 8
            // Compute the addition of each combination of the keys you want to be pressed
            // ALT+CTRL = 1 + 2 = 3 , CTRL+SHIFT = 2 + 4 = 6...
            RegisterHotKey(this.Handle, 1, 6, (int)Keys.T);
            RegisterHotKey(this.Handle, 2, 2, (int)Keys.T);
            RegisterHotKey(this.Handle, 3, 2, (int)Keys.Q);
            RegisterHotKey(this.Handle, 4, 2, (int)Keys.Y);

        }



        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == 1)
            {
                SendKeys.Send("\u1e6c");
            }
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == 2)
            {
                SendKeys.Send("\u1e6d");

            }
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == 3)
            {
                SendKeys.Send("\u0302");

            }
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == 4)
            {
                SendKeys.Send("\u030c");

            }
            base.WndProc(ref m);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            
            MessageBoxButtons butts = MessageBoxButtons.YesNo;
            DialogResult res = MessageBox.Show("Are You Sure?", "Exit", butts);
            if(res == DialogResult.Yes)
            {
                this.Close();
            }
            
        }

        private void osk_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

      
    }
}

    


