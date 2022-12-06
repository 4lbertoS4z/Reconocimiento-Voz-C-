using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace reconocimientoVozAlpha
{

    public partial class Form1 : Form
    {
        SpeechRecognitionEngine recognitionEngine = new SpeechRecognitionEngine();
        SpeechRecognitionEngine recogCity = new SpeechRecognitionEngine();

        SpeechSynthesizer synthesizer = new SpeechSynthesizer();


        public Form1()
        {
            InitializeComponent();
            recognitionEngine.SetInputToDefaultAudioDevice();
            recognitionEngine.LoadGrammar(new DictationGrammar());
            recognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
            recognitionEngine.SpeechRecognized += Detection;
        }

        private void Detection(object sender, SpeechRecognizedEventArgs e)
        {
            textBox1.Text = e.Result.Text;
            string speech = e.Result.Text;
            switch (speech.ToLower())
            {
                case "navegador":
                    synthesizer.Speak("Abriendo navegador");

                    System.Diagnostics.Process.Start("https://www.google.com/");

                    break;

                case "jugar":
                    synthesizer.Speak("Abriendo steam");
                    System.Diagnostics.Process.Start(@"C:\Program Files (x86)\Steam\steam.exe");
                    break;
                case "hora":

                    synthesizer.Speak(DateTime.Now.ToString("F"));
                    break;
                case "tiempo":

                    Form1_Load(sender, e);
                    break;

                case "adiós":
                    synthesizer.Speak("Hasta pronto");
                    Application.Exit();
                    break;
                default:

                    break;
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            form2.FormClosed += Form2_FormClosed;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }

}

