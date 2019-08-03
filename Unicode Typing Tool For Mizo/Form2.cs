using System;
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
    public partial class Form2 : Form
    {
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags,
        UIntPtr dwExtraInfo);

        private const int WS_EX_NOACTIVATE = 0x08000000;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle = createParams.ExStyle | WS_EX_NOACTIVATE;
                return createParams;
            }
        }

        private const int WM_MOUSEACTIVATE = 0x0021;
        private const int MA_NOACTIVATE = 0x0003;
        protected override void WndProc(ref Message m)
        {
            //If we're being activated because the mouse clicked on us...
            if (m.Msg == WM_MOUSEACTIVATE)
            {
                //Then refuse to be activated, but allow the click event to pass through (don't use MA_NOACTIVATEEAT)
                m.Result = (IntPtr)MA_NOACTIVATE;
            }
            else
            {
                base.WndProc(ref m);
            }
            
        }

    
        public Form2()
        {
            InitializeComponent();
            this.TopMost = true;
            Rectangle r = Screen.PrimaryScreen.WorkingArea;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox8.Checked || checkBox2.Checked)
            {
                SendKeys.Send("!");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else if(checkBox4.Checked)
            {
                SendKeys.Send("{F1}");
            }
            else
            {
                SendKeys.Send("1");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(checkBox2.Checked || checkBox8.Checked)
            {
            
                SendKeys.Send("{~}");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                SendKeys.Send("`");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("{+}");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else if (checkBox4.Checked)
            {
                SendKeys.Send("{F12}");
            }
            else
            {
                SendKeys.Send("=");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                const int KEYEVENTF_EXTENDEDKEY = 0x1;
                const int KEYEVENTF_KEYUP = 0x2;
                keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
                keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP,(UIntPtr)0);
            }
            else
            {
                const int KEYEVENTF_EXTENDEDKEY = 0x1;
                const int KEYEVENTF_KEYUP = 0x2;
                keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
                keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{Tab}");
        }

        private void button61_Click(object sender, EventArgs e)
        {
            SendKeys.Send(" ");
        }

        private void button29_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{ENTER}");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{BS}");
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked)
            {
                checkBox8.Checked = true;
                if(checkBox3.Checked)
                {
                    showSpecials();
                }
                else
                    showUpperCase();
            }
            else
            {
                if (checkBox3.Checked)
                {
                    showSpecials();
                }
                else
                    showLowerCase();
                checkBox8.Checked = false;
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            {
                checkBox2.Checked = true;
                if(checkBox3.Checked)
                {
                    showSpecials();
                }
                else
                    showUpperCase();
            }
            else
            {
                checkBox2.Checked = false;
                showLowerCase();
            }
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                showFn();
            }
            else
            {
                showNum();
            }
        }

        public void showUpperCase()
        {
            //First row
            button1.Text = "~";
            button2.Text = "!";
            button3.Text = "@";
            button4.Text = "#";
            button5.Text = "$";
            button6.Text = "%";
            button7.Text = "^";
            button8.Text = "&&";
            button9.Text = "*";
            button10.Text = "(";
            button11.Text = ")";
            button12.Text = "_";
            button13.Text = "+";
            button14.Text = "|";
            //second row
            button17.Text = "Q";
            button18.Text = "W";
            button19.Text = "E";
            button20.Text = "R";
            button21.Text = "T";
            button22.Text = "Y";
            button23.Text = "U";
            button24.Text = "I";
            button25.Text = "O";
            button26.Text = "P";
            button27.Text = "{";
            button28.Text = "}";
            //Third row
            button41.Text = "A";
            button40.Text = "S";
            button39.Text = "D";
            button38.Text = "F";
            button37.Text = "G";
            button36.Text = "H";
            button35.Text = "J";
            button34.Text = "K";
            button33.Text = "L";
            button32.Text = ":";
            button31.Text = "\"";
            //Fourth row
            button52.Text = "Z";
            button51.Text = "X";
            button50.Text = "C";
            button49.Text = "V";
            button48.Text = "B";
            button47.Text = "N";
            button46.Text = "M";
            button45.Text = "<";
            button44.Text = ">";
            button43.Text = "?";
        }
        public void showLowerCase()
        {
            //First row
            button1.Text = "`";
            button2.Text = "1";
            button3.Text = "2";
            button4.Text = "3";
            button5.Text = "4";
            button6.Text = "5";
            button7.Text = "6";
            button8.Text = "7";
            button9.Text = "8";
            button10.Text = "9";
            button11.Text = "0";
            button12.Text = "-";
            button13.Text = "=";
            button14.Text = "\\";
            //second row
            button17.Text = "q";
            button18.Text = "w";
            button19.Text = "e";
            button20.Text = "r";
            button21.Text = "t";
            button22.Text = "y";
            button23.Text = "u";
            button24.Text = "i";
            button25.Text = "o";
            button26.Text = "p";
            button27.Text = "[";
            button28.Text = "]";
            //Third Row
            button41.Text = "a";
            button40.Text = "s";
            button39.Text = "d";
            button38.Text = "f";
            button37.Text = "g";
            button36.Text = "h";
            button35.Text = "j";
            button34.Text = "k";
            button33.Text = "l";
            button32.Text = ";";
            button31.Text = "'";
            //Fourth row
            button52.Text = "z";
            button51.Text = "x";
            button50.Text = "c";
            button49.Text = "v";
            button48.Text = "b";
            button47.Text = "n";
            button46.Text = "m";
            button45.Text = ",";
            button44.Text = ".";
            button43.Text = "/";

        }
        public void showFn()
        {
            button2.Text = "F1";
            button3.Text = "F2";
            button4.Text = "F3";
            button5.Text = "F4";
            button6.Text = "F5";
            button7.Text = "F6";
            button8.Text = "F7";
            button9.Text = "F8";
            button10.Text = "F9";
            button11.Text = "F10";
            button12.Text = "F11";
            button13.Text = "F12";

        }
        public void showNum()
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {
                button2.Text = "!";
                button3.Text = "@";
                button4.Text = "#";
                button5.Text = "$";
                button6.Text = "%";
                button7.Text = "^";
                button8.Text = "&&";
                button9.Text = "*";
                button10.Text = "(";
                button11.Text = ")";
                button12.Text = "_";
                button13.Text = "+";
            }
            else
            {
                button2.Text = "1";
                button3.Text = "2";
                button4.Text = "3";
                button5.Text = "4";
                button6.Text = "5";
                button7.Text = "6";
                button8.Text = "7";
                button9.Text = "8";
                button10.Text = "9";
                button11.Text = "0";
                button12.Text = "-";
                button13.Text = "=";
            }
        }

        private void button54_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked && checkBox2.Checked)
            {
                SendKeys.Send("^(+{ESC})");
                checkBox3.Checked = false;
                checkBox2.Checked = false;
            }
            else
                SendKeys.Send("{ESC}");
        }

        private void button67_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{DEL}");
        }

        private void button56_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{UP}");
        }

        private void button57_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{DOWN}");
        }

        private void button66_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{LEFT}");
        }

        private void button55_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{RIGHT}");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("@");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else if(checkBox4.Checked)
            {
                SendKeys.Send("{F2}");
            }
            else
            {
                SendKeys.Send("2");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("#");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else if (checkBox4.Checked)
            {
                SendKeys.Send("{F3}");
            }
            else
            {
                SendKeys.Send("3");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("$");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else if (checkBox4.Checked)
            {
                if (checkBox5.Checked || checkBox6.Checked)
                {
                    SendKeys.Send("%({F4})");
                    checkBox4.Checked = false;
                    checkBox5.Checked = false;
                }
                else
                    SendKeys.Send("{F4}");
            }
            else
            {
                SendKeys.Send("4");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("{%}");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else if (checkBox4.Checked)
            {
                SendKeys.Send("{F5}");
            }
            else
            {
                SendKeys.Send("5");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("{^}");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else if (checkBox4.Checked)
            {
                SendKeys.Send("{F6}");
            }
            else
            {
                SendKeys.Send("6");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("&");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else if (checkBox4.Checked)
            {
                SendKeys.Send("{F7}");
            }
            else
            {
                SendKeys.Send("7");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("*");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else if (checkBox4.Checked)
            {
                SendKeys.Send("{F8}");
            }
            else
            {
                SendKeys.Send("8");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("{(}");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else if (checkBox4.Checked)
            {
                SendKeys.Send("{F9}");
            }
            else
            {
                SendKeys.Send("9");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("{)}");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else if (checkBox4.Checked)
            {
                SendKeys.Send("{F10}");
            }
            else
            {
                SendKeys.Send("0");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("{_}");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else if (checkBox4.Checked)
            {
                SendKeys.Send("{F11}");
            }
            else
            {
                SendKeys.Send("-");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("{|}");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                SendKeys.Send("\\");
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox3.Checked)
            {
                checkBox7.Checked = true;
                showSpecials();
            }
            else
            {
                checkBox7.Checked = false;
                showRegular();
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                checkBox3.Checked = true;
                showSpecials();
            }
            else
            {
                checkBox3.Checked = false;
                showRegular();
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked || checkBox7.Checked)
            {
                if (checkBox2.Checked || checkBox8.Checked)
                {

                    SendKeys.Send("\u1e6c");
                    checkBox2.Checked = false;
                    checkBox8.Checked = false;
                }
                else
                {
                    SendKeys.Send("\u1e6d");
                }
                checkBox3.Checked = false;
                checkBox7.Checked = false;
            }
            else
            {
                if (checkBox2.Checked || checkBox8.Checked)
                {

                    SendKeys.Send("T");
                    checkBox2.Checked = false;
                    checkBox8.Checked = false;
                }
                else
                {
                    SendKeys.Send("t");
                }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked || checkBox7.Checked)
            {
                SendKeys.Send("\u0302");
                checkBox3.Checked = false;
                checkBox7.Checked = false;
            }
            else
            {
                if (checkBox2.Checked || checkBox8.Checked)
                {

                    SendKeys.Send("Q");
                    checkBox2.Checked = false;
                    checkBox8.Checked = false;
                }
                else
                {
                    SendKeys.Send("q");
                }
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked || checkBox7.Checked)
            {
                SendKeys.Send("\u030c");
                checkBox3.Checked = false;
                checkBox7.Checked = false;
            }
            else
            {
                if (checkBox2.Checked || checkBox8.Checked)
                {

                    SendKeys.Send("Y");
                    checkBox2.Checked = false;
                    checkBox8.Checked = false;
                }
                else
                {
                    SendKeys.Send("y");
                }
            }
        }

        public void showSpecials()
        {
            button17.Text = "◌̂";
            button22.Text = "◌̌ ";
            if (checkBox2.Checked || checkBox8.Checked)
                button21.Text = "\u1e6c";
            else
                button21.Text = "\u1e6d";

        }
        
        public void showRegular()
        {
            button17.Text = "q";
            button22.Text = "y";
            if (checkBox2.Checked || checkBox8.Checked)
                button21.Text = "T";
            else
                button21.Text = "t";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("W");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                SendKeys.Send("w");
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("E");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                SendKeys.Send("e");
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("R");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                SendKeys.Send("r");
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("U");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                SendKeys.Send("u");
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("I");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                SendKeys.Send("i");
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("O");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                SendKeys.Send("o");
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("P");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                SendKeys.Send("p");
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("{{}");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                SendKeys.Send("{[}");
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("{}}");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                SendKeys.Send("{]}");
            }
        }

        private void button41_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("A");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                SendKeys.Send("a");
            }
        }

        private void button40_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("S");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                SendKeys.Send("s");
            }
        }

        private void button39_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("D");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                SendKeys.Send("d");
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("F");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                SendKeys.Send("f");
            }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("G");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                SendKeys.Send("g");
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("H");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                SendKeys.Send("h");
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("J");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                SendKeys.Send("j");
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("K");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                SendKeys.Send("k");
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("L");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                SendKeys.Send("l");
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("{:}");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                SendKeys.Send("{;}");
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("\"");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                SendKeys.Send("'");
            }
        }

        private void button52_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("Z");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                SendKeys.Send("z");
            }
        }

        private void button51_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("X");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                SendKeys.Send("x");
            }
        }

        private void button50_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("C");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                SendKeys.Send("c");
            }
        }

        private void button49_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("V");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                SendKeys.Send("v");
            }
        }

        private void button48_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("B");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                SendKeys.Send("b");
            }
        }

        private void button47_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("N");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                SendKeys.Send("n");
            }
        }

        private void button46_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("M");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                SendKeys.Send("m");
            }
        }

        private void button45_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("{<}");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                SendKeys.Send("{,}");
            }
        }

        private void button44_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("{>}");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                SendKeys.Send("{.}");
            }
        }

        private void button43_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox8.Checked)
            {

                SendKeys.Send("{?}");
                checkBox2.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                SendKeys.Send("{/}");
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox5.Checked)
            {
                checkBox6.Checked = true;

            }
            else
            {
                checkBox6.Checked = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                checkBox5.Checked = true;
            }
            else
            {
                checkBox5.Checked = false;
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
           SendKeys.Send("^({ESC})");   
        }
    }
}
