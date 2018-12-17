using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Authed;
using Jose.jwe;
using Newtonsoft.Json;

namespace AuthedAdder
{
    public partial class Form1 : Form
    {
        Auth auth = new Auth();


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public Form1()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox2.Text;
            string password = textBox3.Text;
            string email = textBox4.Text;
            string token = textBox5.Text;
            bool register = auth.Register(username, password, email, token);

            bool authed = auth.Authenticate(textBox1.Text);

            if (authed != true) 
            {
                MessageBox.Show("Please contact the Administration", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

            if (register == true && authed == true)
            {
                MessageBox.Show("User " + username + " successfully registered!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error please check your Informations", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
