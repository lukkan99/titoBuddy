using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Threading;
using System.Media;
using System.IO;

namespace titoBuddy
{
    public struct Say
    {
        public string Text { get; set; }
        public Say(string text)
        {
            Text = text;
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Thread dickTalk;
        public void Form1_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Top = Screen.PrimaryScreen.Bounds.Height - this.Height - 40;
            this.Left = Cursor.Position.X;
            loop(sender, e);
            quote(sender, e);
        }
        public void SpeakText(string text)
        {
            dickTalk = new Thread(new ParameterizedThreadStart(o => Synth(((string)o))));
            dickTalk.Start(text);
            label1.Text = text;
        }
        public void Synth(string whatToSay)
        {
            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {

                // Configure the audio output. 
                synth.SetOutputToDefaultAudioDevice();

                // Speak a string synchronously
                synth.Speak(whatToSay);
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SpeakText("What do you want from me?");
            chooseAction.Show(Cursor.Position);
        }

        private void chooseAction_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SpeakText("It\u2019s the Nutshack! (Yee, yee)\r\nIt\u2019s the Nutshack! (What he say?)\r\nIt\u2019s the Nutshack! (Oh, yes! Yeeeah)\r\nIt\u2019s the Nutshack! (Hey, I got the Nutshack!)\r\nIt\u2019s the Nutshack! (\u2018The fuck you say, boyee?)\r\nIt\u2019s the Nutshack! (It\u2019s the Nutshack!)\r\nIt\u2019s the Nutshack! (It\u2019s the Nutshack!)\r\nIt\u2019s the Nutshack! (It\u2019s the Nutshack\u2026)\r\nIt\u2019s the Nutshack! (Hey!)\r\nIt\u2019s the Nutshack! (Piece a\u2019 nuts!)\r\nIt\u2019s the Nutshack! (Whoooa!)\r\nIt\u2019s the Nutshack!\r\nHoo-ugh!\r\nPhil\u2019s from the stone, Jack\u2019s from the pier,\r\nHoratio or Horat so beer!\r\nTito Dick \u201CDickman\u201D, baby!\r\nHe hates Phil and loves the ladies.\r\nJack\u2019s cool-ass lazy, he\u2019s still learnin\u2019.\r\nNumber one Cherry Pie, still a virgin.\r\nChita, meet da freak of da weekah!\r\nPhil\u2019s homegirl that Jack wanna keep her,\r\nBut that\u2019s not happenin\u2019, either!\r\nShakin\u2019 like a seizure, hold up, boys\r\nand spark this, take a breather.\r\nWith that reefer in my lungs,\r\nI got grapes, what you watchin\u2019, son?\r\nIt\u2019s the Nutshack! (Yah!)\r\nIt\u2019s the Nutshack! (AAAAARRRGH!)\r\nIt\u2019s the Nutshack!\r\nIt\u2019s the Nutshack!");
        }

        public async void loop(object sender, EventArgs e)
        {
            for(int x = 0; x < 1; x--)
            {
                this.Left = Cursor.Position.X - 150;
                //= Cursor.Position.X;
                await Task.Delay(10);
            }
        }

        private async void quote(object sender, EventArgs e)
        {
            while(true)
            {
                Random random = new Random();
                var names = new List<string> { "Horat or Horatio so beer!", "Your PC has a wirus call 1 800 Madarchod", "I am the strongest.", "I hate phil!", "OwO what\'s this?" };

                int index = random.Next(names.Count);
                var name = names[index];
                names.RemoveAt(index);

                SpeakText(name);
                await Task.Delay(60000);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            pictureBox1.Visible = false;
            Stream str = Properties.Resources.the;
            SoundPlayer simpleSound = new SoundPlayer(str);
            simpleSound.Play();
            label1.Text = "Thank you for calling Vindaloos technical suppoet!";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("you can not kill tito dicke!");
            e.Cancel = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox1.Visible = true;
            SpeakText("I am tito dick again!");
        }
    }
}
