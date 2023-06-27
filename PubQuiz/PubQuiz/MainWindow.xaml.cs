using M.Core.Application.ControlHelpers;
using M.Core.Application.WPF.MessageBox;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PubQuiz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<vragen> Nieuwgemaaktevragen = new List<vragen>();
        private DataGridControl<vragen> _AlleEditVragen;
        private DataGridControl<vragen> _AlleVragen;
        private DataGridControl<Antwoorden> _AlleAntwoorden;
        private ListBoxControl<quizes> _Allequizes;
        public List<Antwoorden> Antwoorden = new List<Antwoorden>();
        public quizes GeselecteerdeQuiz;
        public List<vragen> vragenVanGekozenQuiz = new List<vragen>();
        private vragen GeselectedeerdeVraag;
        public WindowState previousWindowState;
        public int QuizID = 0;
        public string Titel;
        public FileDialog Foto;


        public MainWindow()
        {
            InitializeComponent();

            _AlleVragen = new DataGridControl<vragen>(AlleVragen, true);
            _AlleVragen.CreateTextColumn($"Vraag", nameof(vragen.Vragen), 160);
            _AlleVragen.CreateTextColumn($"Correcte Antwoord", nameof(vragen.GoedeAntwoord), 140);
            _AlleVragen.CreateTextColumn($"Foute antwoord", nameof(vragen.Fouteantwoordeen), 140);
            _AlleVragen.CreateTextColumn($"Foute antwoord", nameof(vragen.Fouteantwoordtwee), 140);
            _AlleVragen.CreateTextColumn($"Foute antwoord", nameof(vragen.Fouteantwoorddrie), 140);
            _AlleVragen.UseVisualTemplateLines();

            _AlleEditVragen = new DataGridControl<vragen>(AlleEditVragen, true);
            _AlleEditVragen.CreateTextColumn($"Vraag", nameof(vragen.Vragen), 160);
            _AlleEditVragen.CreateTextColumn($"Correcte Antwoord", nameof(vragen.GoedeAntwoord), 140);
            _AlleEditVragen.CreateTextColumn($"Foute antwoord", nameof(vragen.Fouteantwoordeen), 140);
            _AlleEditVragen.CreateTextColumn($"Foute antwoord", nameof(vragen.Fouteantwoordtwee), 140);
            _AlleEditVragen.CreateTextColumn($"Foute antwoord", nameof(vragen.Fouteantwoorddrie), 140);
            _AlleEditVragen.UseVisualTemplateLines();

            _AlleAntwoorden = new DataGridControl<Antwoorden>(AlleAntwoorden, true);
            _AlleAntwoorden.CreateTextColumn($"Vraag", nameof(PubQuiz.Antwoorden.Vraag), 250);
            _AlleAntwoorden.CreateTextColumn($"ABCD", nameof(PubQuiz.Antwoorden.ABCD), 120);
            _AlleAntwoorden.CreateTextColumn($"Correcte Antwoord", nameof(PubQuiz.Antwoorden.Antwoord), 250);
            _AlleAntwoorden.UseVisualTemplateLines();

            _Allequizes = new ListBoxControl<quizes>(AlleQuizzes);

            SetHomeScherm();
        }
        public void SetHomeScherm()
        {
            HoofdScherm.Visibility = Visibility.Visible;
            EditQuiz.Visibility = Visibility.Hidden;
            MaakQuiz.Visibility = Visibility.Hidden;
            EindeQuiz.Visibility = Visibility.Hidden;
            SpeelQuiz.Visibility = Visibility.Hidden;
            QuizSpelen.Visibility = Visibility.Hidden;
            SpeelTitel.Visibility = Visibility.Hidden;

            var Savedquizes = jsons.quizLezen();
            _Allequizes.SetItemsSource(Savedquizes);
        }
        public void ZetEditScherm()
        {
            List<vragen> listSavedvragen = jsons.LeesVragen();
            List<vragen> AllvragenOfSelectedQuiz = new List<vragen>();

            foreach (var Question in listSavedvragen)
            {
                if (Question.quizid == GeselecteerdeQuiz.quizid)
                    AllvragenOfSelectedQuiz.Add(Question);
            }

            tbEditVraag.Text = string.Empty;
            tbEditGoedeAntwoord.Text = string.Empty;
            tbEditFouteAntwoordEen.Text = string.Empty;
            tbEditFouteAntwoordTwee.Text = string.Empty;
            tbEditFouteAntwoordDrie.Text = string.Empty;
            Foto = null;
            tbEditTijd.Text = string.Empty;
            OpslaanVraag.IsEnabled = false;

            _AlleEditVragen.SetDataSource(AllvragenOfSelectedQuiz);
        }
        private void MaakQuizzen_Click(object sender, RoutedEventArgs e)
        {
            HoofdScherm.Visibility = Visibility.Hidden;
            MaakQuiz.Visibility = Visibility.Visible;
        }
        private void PasQuizAan_Click(object sender, RoutedEventArgs e)
        {
            GeselecteerdeQuiz = _Allequizes.GetSelection();
            if (GeselecteerdeQuiz == null)
                return;

            HoofdScherm.Visibility = Visibility.Hidden;
            EditQuiz.Visibility = Visibility.Visible;

            var Savedvragen = jsons.LeesVragen();

            List<vragen> AllvragenOfSelectedQuiz = new List<vragen>();

            foreach (var Question in Savedvragen)
            {
                if (Question.quizid == GeselecteerdeQuiz.quizid)
                    AllvragenOfSelectedQuiz.Add(Question);
            }

            tbEditTitel.Text = GeselecteerdeQuiz.Titel;
            OpslaanVraag.IsEnabled = false;
            _AlleEditVragen.SetDataSource(AllvragenOfSelectedQuiz);

        }
        private void SpeelQuizzes_Click(object sender, RoutedEventArgs e)
        {
            GeselecteerdeQuiz = _Allequizes.GetSelection();
            if (GeselecteerdeQuiz == null)
                return;
            HoofdScherm.Visibility = Visibility.Hidden;
            SpeelQuiz.Visibility = Visibility.Visible;
            lblTitel.Content = GeselecteerdeQuiz.Titel;
            var Savedvragen = jsons.LeesVragen();

            foreach (var Question in Savedvragen)
            {
                if (Question.quizid == GeselecteerdeQuiz.quizid)
                    vragenVanGekozenQuiz.Add(Question);
            }

            lblvragen.Content = $"Aantal Vragen: {vragenVanGekozenQuiz.Count}";

            // Save the previous window state
            previousWindowState = WindowState;
            // Switch to fullscreen mode
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
            ResizeMode = ResizeMode.NoResize;


            adminPanel adminPanelWindow = new adminPanel();
            adminPanel.mwMainWindow = this;
            adminPanelWindow.ShowDialog();
        }
        private void SlaQuizOp_Click(object sender, RoutedEventArgs e)
        {
            if (Nieuwgemaaktevragen.Count == 0 || Nieuwgemaaktevragen == null)
            {
                MBox.ShowWarning("Er zijn geen vragen toegevoegd.\nKan de quiz niet opslaan");
                return;
            }
            if (Titel == string.Empty)
            {
                MBox.ShowWarning("Er is geen titel toegevoegd.\nKan de quiz niet opslaan");
                return;
            }
            List<quizes> Listquizes = new List<quizes>();

            Listquizes.Add(new quizes { Titel = Titel, quizid = Nieuwgemaaktevragen.First().quizid });

            var SavedQuizes = jsons.quizLezen();
            SavedQuizes.AddRange(Listquizes);
            jsons.quizOpslaan(SavedQuizes);

            var Savedvragen = jsons.LeesVragen();
            Savedvragen.AddRange(Nieuwgemaaktevragen);
            jsons.vragenOpslaan(Savedvragen);

            QuizID = 0;
            Nieuwgemaaktevragen.Clear();

            SetHomeScherm();
        }
        private void VerwijderVraag_Click(object sender, RoutedEventArgs e)
        {
            vragen SelectedQuestion = _AlleVragen.GetSelectedItem();
            if (SelectedQuestion == null) return;

            Nieuwgemaaktevragen.Remove(SelectedQuestion);

            _AlleVragen.SetDataSource(null);
            _AlleVragen.SetDataSource(Nieuwgemaaktevragen);
        }
        private void VoegVraag_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbVraag.Text) || string.IsNullOrEmpty(tbGoedeAntwoord.Text) || string.IsNullOrEmpty(tbFouteAntwoordDrie.Text) || string.IsNullOrEmpty(tbFouteAntwoordEen.Text) || string.IsNullOrEmpty(tbFouteAntwoordTwee.Text))
            {
                MessageBox.Show("Er mist informatie.\nZorg ervoor dat alles is ingevuld.");
                return;
            }

            if (QuizID == 0)
                QuizID = Id.nieuwID();

            Titel = tbTitel.Text;
            string FotosFolder = string.Empty;

            if (Foto != null)
            {
                FotosFolder = jsons.PakFotoFolder() + $"\\{Foto.SafeFileName}";

                if (!File.Exists(FotosFolder))
                    File.Copy(Foto.FileName, FotosFolder);
            }
            int Tijd = 0;
            int.TryParse(tbTijd.Text, out Tijd);

            Nieuwgemaaktevragen.Add(new vragen { quizid = QuizID, Tijd = Tijd, Foto = FotosFolder, Vragen = tbVraag.Text, GoedeAntwoord = tbGoedeAntwoord.Text, Fouteantwoordeen = tbFouteAntwoordEen.Text, Fouteantwoordtwee = tbFouteAntwoordTwee.Text, Fouteantwoorddrie = tbFouteAntwoordDrie.Text, });

            tbVraag.Text = "";
            tbGoedeAntwoord.Text = "";
            tbFouteAntwoordEen.Text = "";
            tbFouteAntwoordTwee.Text = "";
            tbFouteAntwoordDrie.Text = "";
            tbTijd.Text = "";
            Foto = null;

            _AlleVragen.SetDataSource(null);
            _AlleVragen.SetDataSource(Nieuwgemaaktevragen);
        }
        private void Afbeelding_Click(object sender, RoutedEventArgs e)
        {
            var OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Multiselect = false;
            if (!(bool)OpenFileDialog.ShowDialog()) return;

            Foto = OpenFileDialog;
        }
        private void OpslaanVraag_Click(object sender, RoutedEventArgs e)
        {
            var Savedvragen = jsons.LeesVragen();

            foreach (var Question in Savedvragen)
            {
                if (Question.Vragen == GeselectedeerdeVraag.Vragen && Question.GoedeAntwoord == GeselectedeerdeVraag.GoedeAntwoord)
                {
                    Question.Vragen = tbEditVraag.Text;
                    Question.GoedeAntwoord = tbEditGoedeAntwoord.Text;
                    Question.Fouteantwoordeen = tbEditFouteAntwoordEen.Text;
                    Question.Fouteantwoordtwee = tbEditFouteAntwoordTwee.Text;
                    Question.Fouteantwoorddrie = tbEditFouteAntwoordDrie.Text;
                    int Tijd = 0;
                    int.TryParse(tbEditTijd.Text, out Tijd);
                    Question.Tijd = Tijd;

                    if (Foto != null)
                    {
                        var FotosFolder = jsons.PakFotoFolder() + $"\\{Foto.SafeFileName}";

                        if (!File.Exists(FotosFolder))
                            File.Copy(Foto.FileName, FotosFolder);

                        Question.Foto = FotosFolder;
                    }
                    break;
                }
            }
            jsons.vragenOpslaan(Savedvragen);

            ZetEditScherm();
        }
        private void SlaEditQuizOp_Click(object sender, RoutedEventArgs e)
        {
            if (tbEditTitel.Text == string.Empty)
            {
                MBox.ShowWarning("Er is geen titel toegevoegd.\nKan de quiz niet opslaan");
                return;
            }

            if (GeselecteerdeQuiz.Titel != tbEditTitel.Text)
            {
                var Savedquizes = jsons.quizLezen();

                foreach (var Quiz in Savedquizes)
                {
                    if (Quiz.quizid == GeselecteerdeQuiz.quizid)
                    {
                        Quiz.Titel = tbEditTitel.Text;
                        break;
                    }
                }
                jsons.quizOpslaan(Savedquizes);
            }
            SetHomeScherm();
        }
        private void VerwijderEditVraag_Click(object sender, RoutedEventArgs e)
        {
            var SelectedQuiz = _AlleEditVragen.GetFirstSelectedItem();
            if (SelectedQuiz == null)
                return;

            List<vragen> CheckForSingleQuestion = _AlleEditVragen.GetDataSource();
            if (CheckForSingleQuestion.Count == 0)
            {
                MBox.ShowWarning("Kan niet de enige vraag die in de quiz zit verwijderen.");
                return;
            }

            if (!MBox.ShowQuestionWarning("Weet u zeker dat u deze vraag wilt verwijderen."))
                return;

            var Savedvragen = jsons.LeesVragen();
            List<vragen> AboutToBeDeletedvragen = new List<vragen>();

            foreach (var ID in Savedvragen)
            {
                if (ID.Vragen == SelectedQuiz.Vragen && ID.GoedeAntwoord == SelectedQuiz.GoedeAntwoord)
                {
                    AboutToBeDeletedvragen.Add(ID);
                    break;
                }
            }

            List<vragen> WriteToQuestionFile = Savedvragen.Except(AboutToBeDeletedvragen).ToList();
            jsons.vragenOpslaan(WriteToQuestionFile);

            ZetEditScherm();
        }
        private void EditVraag_Click(object sender, RoutedEventArgs e)
        {
            GeselectedeerdeVraag = _AlleEditVragen.GetSelectedItem();
            if (GeselectedeerdeVraag == null)
                return;
            SlaEditQuizOp.IsEnabled = true;
            tbEditVraag.Text = GeselectedeerdeVraag.Vragen;
            tbEditGoedeAntwoord.Text = GeselectedeerdeVraag.GoedeAntwoord;
            tbEditFouteAntwoordEen.Text = GeselectedeerdeVraag.Fouteantwoordeen;
            tbEditFouteAntwoordTwee.Text = GeselectedeerdeVraag.Fouteantwoordtwee;
            tbEditFouteAntwoordDrie.Text = GeselectedeerdeVraag.Fouteantwoorddrie;
            tbEditTijd.Text = GeselectedeerdeVraag.Tijd.ToString();
            OpslaanVraag.IsEnabled = true;
        }
        private void TerugNaarBegin_Click(object sender, RoutedEventArgs e)
        {
            EindeQuiz.Visibility = Visibility.Hidden;
            HoofdScherm.Visibility = Visibility.Visible;
        }
        private void LaatAlleAntwoordenZien_Click(object sender, RoutedEventArgs e)
        {
            AccepteerEinde.Visibility = Visibility.Hidden;
            EindeQuiz.Visibility = Visibility.Visible;

            vragenVanGekozenQuiz.Clear();
            _AlleAntwoorden.SetDataSource(Antwoorden);
        }
    }
}
