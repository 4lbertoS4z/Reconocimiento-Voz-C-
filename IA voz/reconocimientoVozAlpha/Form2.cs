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

    public partial class Form2 : Form
    {
        SpeechRecognitionEngine recogCity = new SpeechRecognitionEngine();
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        public Form2()
        {
            InitializeComponent();
            synthesizer.Speak("¿Que ciudad quieres comprobar?");
            recogCity.SetInputToDefaultAudioDevice();
            recogCity.LoadGrammar(new DictationGrammar());
            recogCity.RecognizeAsync(RecognizeMode.Multiple);
            recogCity.SpeechRecognized += Detection;

        }

        private void Detection(object sender, SpeechRecognizedEventArgs e)
        {

            string ciudad = e.Result.Text;
            string respuesta;
            respuesta = ciudad;
            synthesizer.Speak("Abriendo web del tiempo");
            System.Diagnostics.Process.Start("https://www.eltiempo.es/" + respuesta + ".html");
            recogCity.RecognizeAsyncStop();
            this.Close();
        }
        private void Form2_Closed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
