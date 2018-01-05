using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Lame;
using System.Speech.Synthesis;
using System.Diagnostics;

//using WaveLib;
///using Yeti.MMedia;
//////using Yeti.MMedia.Mp3;

namespace SmplMediaPlayerbyKirbiflint
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        OpenFileDialog media;
        OpenFileDialog save;       //Music | *.mp3; *.wave| Video | *.avi; *.mp4; *.webm; *.flv; *.m4v;";
       /* string mp3 = ".mp3";
        string wave = ".wave";
        string avi = ".avi";
        string mp4 = ".mp4";
        string webm = ".webm";
        string flv = ".flv";
        string m4v = ".m4v";*/





        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Any(c => c < 48 || c > 57))
            {

                MessageBox.Show("First clean the directory and retry!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }


            else if (String.IsNullOrEmpty(textBox1.Text))

            {
                try
                {

                    media = new OpenFileDialog();
                    media.Title = "Open your media";
                    media.Filter = "Music | *.mp3; *.wave| Video | *.avi; *.mp4; *.webm; *.flv; *.m4v;";

                    if (media.ShowDialog() == DialogResult.OK)
                    {


                        textBox1.Text = media.FileName;


                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Sorry something went wrong. Retry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ////progressBar1.Value = progressBar1.Value + 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {



            if (String.IsNullOrEmpty(textBox2.Text) && String.IsNullOrEmpty(textBox1.Text) && String.IsNullOrEmpty(textBox3.Text))

            {
                MessageBox.Show("Enter the file directory, the format and the save path!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (textBox1.Text.Any(c => c < 48 || c > 57) && String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Enter the format first!", "Invalid format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBox2.Text.Any(c => c < 48 || c > 57) && textBox1.Text.Any(c => c < 48 || c > 57) && String.IsNullOrEmpty(textBox3.Text))
            {

                MessageBox.Show("Enter the save path!", "Invalid save path", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            if (textBox2.Text.Any(c => c < 48 || c > 57) && textBox1.Text.Any(c => c < 48 || c > 57) && textBox3.Text.Any(c => c < 48 || c > 57))
            {

                if (textBox2.Text == ".mp4")
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        var converter = new NReco.VideoConverter.FFMpegConverter();
                        converter.ConvertMedia(textBox1.Text, textBox3.Text + "videoconverted.mp4", NReco.VideoConverter.Format.mp4);
                        MessageBox.Show("Conversion done.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Cursor = Cursors.Default;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Sorry something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Cursor = Cursors.Default;

                    }
                    







                    ////MessageBox.Show("Sorry something went wrong. Retry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                

                else if (textBox2.Text == ".avi")
                {

                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        var converter = new NReco.VideoConverter.FFMpegConverter();
                        //timer1.Start();



                        converter.ConvertMedia(textBox1.Text, textBox3.Text + "videoconverted.avi", NReco.VideoConverter.Format.avi);

                        MessageBox.Show("Conversion done.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Cursor = Cursors.Default;
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Sorry something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Cursor = Cursors.Default;
                    }




                    //    MessageBox.Show("Sorry something went wrong. Retry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);











                }
                else if (textBox2.Text == ".m4v")
                {



                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        var converter = new NReco.VideoConverter.FFMpegConverter();
                        //timer1.Start();



                        converter.ConvertMedia(textBox1.Text, textBox3.Text + "videoconverted.m4v", NReco.VideoConverter.Format.m4v);

                        MessageBox.Show("Conversion done.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Cursor = Cursors.Default;
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Sorry something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Cursor = Cursors.Default;
                    }




                }
                if (textBox2.Text.Contains(".flv"))
                {

                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        var converter = new NReco.VideoConverter.FFMpegConverter();
                        //timer1.Start();



                        converter.ConvertMedia(textBox1.Text, textBox3.Text + "videoconverted.flv", NReco.VideoConverter.Format.flv);

                        MessageBox.Show("Conversion done.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Cursor = Cursors.Default;
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Sorry something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Cursor = Cursors.Default;
                    }


                }




                else if (textBox2.Text == ".webm")
                {


                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        var converter = new NReco.VideoConverter.FFMpegConverter();
                        //timer1.Start();



                        converter.ConvertMedia(textBox1.Text, textBox3.Text + "videoconverted.webm", NReco.VideoConverter.Format.webm);

                        MessageBox.Show("Conversion done.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Cursor = Cursors.Default;
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Sorry something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Cursor = Cursors.Default;
                    }

                }

                else if (textBox2.Text == ".wave")
                {

                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        
                        using (Mp3FileReader f = new Mp3FileReader(textBox1.Text))
                        {
                            using (WaveStream pcm = WaveFormatConversionStream.CreatePcmStream(f))
                            {
                                WaveFileWriter.CreateWaveFile(textBox3.Text + "audioconverted.wave", pcm);
                                MessageBox.Show("Conversion done.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.Cursor = Cursors.Default;
                            }
                        }






                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Sorry something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Cursor = Cursors.Default;
                    }


                }
                else if (textBox2.Text == ".mp3")
                {

                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        cnv(textBox1.Text, textBox3.Text + "audioconverted.mp3");
                        MessageBox.Show("Conversion done.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Cursor = Cursors.Default;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Sorry something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Cursor = Cursors.Default;
                    }




                }


                /*DsReader dr = new DsReader(textBox1.Text);
                IntPtr formatPcm = dr.ReadFormat();
                byte[] dataPcm = dr.ReadData();
                dr.Close();
                IntPtr formatMp3 = AudioCompressionManager.GetCompatibleFormat(formatPcm,
                    AudioCompressionManager.MpegLayer3FormatTag);
                byte[] dataMp3 = AudioCompressionManager.Convert(formatPcm, formatMp3, dataPcm, false);
                Mp3Writer mw = new Mp3Writer(File.Create(textBox3.Text + "audioconverted.mp3"));

                mw.WriteData(dataMp3);
                mw.Close();
                MessageBox.Show("Done");*/









            }





        }









        private void button3_Click(object sender, EventArgs e)
        {
            string n = "/";
            FolderBrowserDialog save = new FolderBrowserDialog();
            save.ShowDialog();
            textBox3.Text = save.SelectedPath + n;
        }


        /*public static void ConvertWavStreamToMp3File(ref MemoryStream ms, string savetofilename)
        {
            //rewind to beginning of stream
            ms.Seek(0, SeekOrigin.Begin);
            
            using (var retMs = new MemoryStream())
            using (var rdr = new WaveFileReader(ms))
            using (var wtr = new LameMP3FileWriter(savetofilename, rdr.WaveFormat, LAMEPreset.VBR_90))
            {
                rdr.CopyTo(wtr);
            }*/





        public void cnv(string sourceFilename, string targetFilename)
        {
            using (var reader = new NAudio.Wave.AudioFileReader(sourceFilename))
            using (var writer = new NAudio.Lame.LameMP3FileWriter(targetFilename, reader.WaveFormat, NAudio.Lame.LAMEPreset.STANDARD))
            {
                reader.CopyTo(writer);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

