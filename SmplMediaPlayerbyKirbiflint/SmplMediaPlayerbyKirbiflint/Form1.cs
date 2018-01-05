using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace SmplMediaPlayerbyKirbiflint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

     

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            ///  Stream stream = null;
            OpenFileDialog ApriMedia = new OpenFileDialog();
            ApriMedia.InitialDirectory = "C:\\";
            ApriMedia.Title = "Open your media";
            ApriMedia.Filter = "Music | *.mp3; *.wave| Video | *.avi; *.mp4; *.webm; *.flv; *.m4v;"; 
            ///ApriMedia.ShowDialog(); 



            if (ApriMedia.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {



                // label1.Text = ApriMedia.FileName;
                axWindowsMediaPlayer1.URL = ApriMedia.FileName;




            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

