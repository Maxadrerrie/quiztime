using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PubQuiz
{
    /// <summary>
    /// Interaction logic for adminPanel.xaml
    /// </summary>
    public partial class adminPanel : Window
    {
    
        bool volgendeVraag = false;
        public bool laatsteVraag = false;
        private double pauzeTimer;
        public static MainWindow mwMainWindow;
        int randomGetal;
        int getalVraag = 0;
        private DispatcherTimer Timer;
        private double dbtime = 0;
        private DateTime startTime;
        bool timerStart = false;
        List<int> listRandomInts = new List<int>();
        public adminPanel()
        {
            InitializeComponent();
            adminpaneel();
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            Timer.Tick += Timer_Tick;
        }
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            double tijd = dbtime;
            DateTime tijdStip = DateTime.Now;
            TimeSpan TimeSpan = tijdStip.Subtract(startTime);
            double tijdOver = tijd - TimeSpan.TotalSeconds;
            TimeSpan TimeSpanTimeLeft = TimeSpan.FromSeconds(tijdOver);

            pauzeTimer = tijdOver;

            mwMainWindow.lblCountdownTimer.Content = TimeSpanTimeLeft.ToString("mm\\:ss");
            if (tijdOver <= 0 && volgendeVraag)
            {
                volgendeBtn(null, null);
                startTime = DateTime.Now;
            }
            if (tijdOver <= 0 && !volgendeVraag)
            {
                Timer.Stop();
                startTime = DateTime.Now;
            }
        }

        public void adminpaneel()
        {
            btnStartQuiz.Visibility = Visibility.Visible;
            btnEndQuiz.IsEnabled = false;
            btnNext.IsEnabled = false;
            btnPause.IsEnabled = false;
            btnShowAwnser.IsEnabled = false;
            btnPrevious.IsEnabled = false;
            cbAutoNext.IsEnabled = false;
        }
        private void volgendeBtn(object sender, RoutedEventArgs e)
        {
            zwarteLabels();
            getalVraag++;
            if (getalVraag == mwMainWindow.vragenVanGekozenQuiz.Count - 1)
            {
                btnEndQuiz.IsEnabled = true;
                btnNext.IsEnabled = false;
            }
            if (getalVraag > mwMainWindow.vragenVanGekozenQuiz.Count - 1)
                laatsteVraag = true;

            if (laatsteVraag && volgendeVraag)
                eindeQuiz(null, null);

            if (btnPrevious.IsEnabled == false)
                btnPrevious.IsEnabled = true;
            if (!laatsteVraag)
                MakeNewQuestion();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            if (timerStart)
            {
                Timer.Stop();
                dbtime = pauzeTimer;
                btnPause.Content = "▶";
                timerStart = false;
            }
            else
            {
                startTime = DateTime.Now;

                Timer.Start();
                btnPause.Content = "||";
                timerStart = true;
            }
        }
        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            zwarteLabels();
            getalVraag--;
            btnEndQuiz.IsEnabled = false;
            btnNext.IsEnabled = true;
            laatsteVraag = false;
            if (getalVraag == 0)
                btnPrevious.IsEnabled = false;
            MakeNewQuestion();
        }
        private void btnShowAwnser_Click(object sender, RoutedEventArgs e)
        {
            if (randomGetal == 1)
            {
                mwMainWindow.lblAwnserOne.Foreground = Brushes.Green;
            }
            if (randomGetal == 2)
            {
                mwMainWindow.lblAwnserTwo.Foreground = Brushes.Green;
            }
            if (randomGetal == 3)
            {
                mwMainWindow.lblAwnserThree.Foreground = Brushes.Green;
            }
            if (randomGetal == 4)
            {
                mwMainWindow.lblAwnserFour.Foreground = Brushes.Green;
            }
        }
        private void zwarteLabels()
        {
            mwMainWindow.lblAwnserOne.Foreground = Brushes.Black;
            mwMainWindow.lblAwnserTwo.Foreground = Brushes.Black;
            mwMainWindow.lblAwnserThree.Foreground = Brushes.Black;
            mwMainWindow.lblAwnserFour.Foreground = Brushes.Black;
        }
        private void randomGetalLijst()
        {
            Random rnd = new Random();
            for (int i = 0; i <= mwMainWindow.vragenVanGekozenQuiz.Count; i++)
            {
                listRandomInts.Add(rnd.Next(1, 4));
            }
        }
        private void MakeNewQuestion()
        {
            Timer.Stop();
            startTime = DateTime.Now;
            mwMainWindow.lblQuestion.Content = mwMainWindow.vragenVanGekozenQuiz.Skip(getalVraag).First().Vragen;
            lblQuestionCount.Content = $"{getalVraag + 1}/{mwMainWindow.vragenVanGekozenQuiz.Count}";
            dbtime = mwMainWindow.vragenVanGekozenQuiz.Skip(getalVraag).First().Tijd + 1;
            Uri FotoUri = new Uri(mwMainWindow.vragenVanGekozenQuiz.Skip(getalVraag).First().Foto, UriKind.RelativeOrAbsolute);
            BitmapImage bitmapFoto = new BitmapImage(FotoUri);
            mwMainWindow.imgImage.Source = bitmapFoto;

            randomGetal = listRandomInts.Skip(getalVraag).First();
            Timer.Start();
            timerStart = true;

            if (randomGetal == 1)
            {
                mwMainWindow.lblAwnserOne.Content = "A. " + mwMainWindow.vragenVanGekozenQuiz.Skip(getalVraag).First().GoedeAntwoord;
                mwMainWindow.lblAwnserTwo.Content = "B. " + mwMainWindow.vragenVanGekozenQuiz.Skip(getalVraag).First().Fouteantwoordeen;
                mwMainWindow.lblAwnserThree.Content = "C. " + mwMainWindow.vragenVanGekozenQuiz.Skip(getalVraag).First().Fouteantwoordtwee;
                mwMainWindow.lblAwnserFour.Content = "D. " + mwMainWindow.vragenVanGekozenQuiz.Skip(getalVraag).First().Fouteantwoorddrie;

            }
            if (randomGetal == 2)
            {
                mwMainWindow.lblAwnserOne.Content = "A. " + mwMainWindow.vragenVanGekozenQuiz.Skip(getalVraag).First().Fouteantwoorddrie;
                mwMainWindow.lblAwnserTwo.Content = "B. " + mwMainWindow.vragenVanGekozenQuiz.Skip(getalVraag).First().GoedeAntwoord;
                mwMainWindow.lblAwnserThree.Content = "C. " + mwMainWindow.vragenVanGekozenQuiz.Skip(getalVraag).First().Fouteantwoordeen;
                mwMainWindow.lblAwnserFour.Content = "D. " + mwMainWindow.vragenVanGekozenQuiz.Skip(getalVraag).First().Fouteantwoordtwee;
            }
            if (randomGetal == 3)
            {
                mwMainWindow.lblAwnserOne.Content = "A. " + mwMainWindow.vragenVanGekozenQuiz.Skip(getalVraag).First().Fouteantwoordtwee;
                mwMainWindow.lblAwnserTwo.Content = "B. " + mwMainWindow.vragenVanGekozenQuiz.Skip(getalVraag).First().Fouteantwoorddrie;
                mwMainWindow.lblAwnserThree.Content = "C. " + mwMainWindow.vragenVanGekozenQuiz.Skip(getalVraag).First().GoedeAntwoord;
                mwMainWindow.lblAwnserFour.Content = "D. " + mwMainWindow.vragenVanGekozenQuiz.Skip(getalVraag).First().Fouteantwoordeen;
            }
            if (randomGetal == 4)
            {
                mwMainWindow.lblAwnserOne.Content = "A. " + mwMainWindow.vragenVanGekozenQuiz.Skip(getalVraag).First().Fouteantwoordeen;
                mwMainWindow.lblAwnserTwo.Content = "B. " + mwMainWindow.vragenVanGekozenQuiz.Skip(getalVraag).First().Fouteantwoordtwee;
                mwMainWindow.lblAwnserThree.Content = "C. " + mwMainWindow.vragenVanGekozenQuiz.Skip(getalVraag).First().Fouteantwoorddrie;
                mwMainWindow.lblAwnserFour.Content = "D. " + mwMainWindow.vragenVanGekozenQuiz.Skip(getalVraag).First().GoedeAntwoord;
            }
            if (1 == mwMainWindow.vragenVanGekozenQuiz.Count)
            {
                btnEndQuiz.IsEnabled = true;
                btnNext.IsEnabled = false;
            }
        }
        private void btnStartQuiz_Click(object sender, RoutedEventArgs e)
        {
            btnStartQuiz.Visibility = Visibility.Hidden;
            mwMainWindow.SpeelQuiz.Visibility = Visibility.Hidden;
            mwMainWindow.QuizSpelen.Visibility = Visibility.Visible;
            mwMainWindow.SpeelTitel.Visibility = Visibility.Visible;
            btnNext.IsEnabled = true;
            btnPause.IsEnabled = true;
            btnShowAwnser.IsEnabled = true;
            cbAutoNext.IsEnabled = true;
            zwarteLabels();
            randomGetalLijst();
            MakeNewQuestion();
        }
        private List<Antwoorden> antwoordenOphalen()
        {
            List<Antwoorden> listAntwoorden = new List<Antwoorden>();
            for (int i = 0; i <= mwMainWindow.vragenVanGekozenQuiz.Count; i++)
            {
                if (i == mwMainWindow.vragenVanGekozenQuiz.Count)
                    break;

                if (listRandomInts.Skip(i).First() == 1)
                {
                    listAntwoorden.Add(new Antwoorden { Antwoord = mwMainWindow.vragenVanGekozenQuiz.Skip(i).First().GoedeAntwoord, ABCD = "A", Vraag = mwMainWindow.vragenVanGekozenQuiz.Skip(i).First().Vragen });
                    continue;
                }
                if (listRandomInts.Skip(i).First() == 2)
                {
                    listAntwoorden.Add(new Antwoorden { Antwoord = mwMainWindow.vragenVanGekozenQuiz.Skip(i).First().GoedeAntwoord, ABCD = "B", Vraag = mwMainWindow.vragenVanGekozenQuiz.Skip(i).First().Vragen });
                    continue;
                }
                if (listRandomInts.Skip(i).First() == 3)
                {
                    listAntwoorden.Add(new Antwoorden { Antwoord = mwMainWindow.vragenVanGekozenQuiz.Skip(i).First().GoedeAntwoord, ABCD = "C", Vraag = mwMainWindow.vragenVanGekozenQuiz.Skip(i).First().Vragen });
                    continue;
                }
                if (listRandomInts.Skip(i).First() == 4)
                {
                    listAntwoorden.Add(new Antwoorden { Antwoord = mwMainWindow.vragenVanGekozenQuiz.Skip(i).First().GoedeAntwoord, ABCD = "D", Vraag = mwMainWindow.vragenVanGekozenQuiz.Skip(i).First().Vragen });
                    continue;
                }
            }
            return listAntwoorden;
        }
        private void eindeQuiz(object sender, RoutedEventArgs e)
        {
            List<Antwoorden> ListOfAntwoorden = antwoordenOphalen();
            mwMainWindow.Antwoorden = ListOfAntwoorden;
            mwMainWindow.QuizSpelen.Visibility = Visibility.Hidden;
            mwMainWindow.SpeelTitel.Visibility = Visibility.Hidden;
            mwMainWindow.AccepteerEinde.Visibility = Visibility.Visible;
            mwMainWindow.WindowState = mwMainWindow.previousWindowState;
            mwMainWindow.WindowStyle = WindowStyle.SingleBorderWindow;
            mwMainWindow.ResizeMode = ResizeMode.CanResize;
            Timer.Stop();
            adminPanel adminPanelWindow = new adminPanel();
            adminPanelWindow.Close();
            this.Close();
        }
        private void cbAutoNext_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)cbAutoNext.IsChecked)
                volgendeVraag = true;
            else volgendeVraag = false;
        }
    }
}
