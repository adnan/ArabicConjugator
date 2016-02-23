using System.Windows;
using System.Windows.Controls;

namespace ArabicConjugator.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        Conjugator _conjugator = null;

        string _root1 = string.Empty;
        string _root2 = string.Empty;
        string _root3 = string.Empty;
        string _tense = string.Empty;
        string _type = string.Empty;
        string _form = string.Empty;
        string _base = string.Empty;
        string _pronoun = string.Empty;
        string _verbType = string.Empty;
        public MainWindow()
        {
            InitializeComponent();

            _conjugator = new Conjugator();

            GetPatterns();
        }


        private void GetPatterns()
        {

            RootOne.SelectedItem = "ف";
            RootTwo.Tag = "ع";
            RootThree.Tag = "ل";

            _root1 = "ف";
            _root2 = "ع";
            _root3 = "ل";
        }

        private void RootOne_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbxRootOne = RootOne.SelectedValue as ComboBoxItem;

            _root1 = cbxRootOne.Content.ToString();
        }
        private void RootTwo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbxRootTwo = RootTwo.SelectedValue as ComboBoxItem;
            _root2 = cbxRootTwo.Content.ToString();
        }
        private void RootThree_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbxRootThree = RootThree.SelectedValue as ComboBoxItem;
            _root3 = cbxRootThree.Content.ToString();
        }

        private void VerbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbxVerbType = VerbType.SelectedValue as ComboBoxItem;
            string verbType = cbxVerbType.Content.ToString();

            switch (verbType)
            {
                case "I - fa'ala - فعل":
                    _verbType = "I";
                    break;
                case "II - fa''ala - فعّل":
                    _verbType = "II";
                    break;
                case "III - faa'ala - فاعل":
                    _verbType = "III";
                    break;
                case "IV - af'ala - أفعل":
                    _verbType = "IV";
                    break;
                case "V - tafa''ala - تفعّل":
                    _verbType = "V";
                    break;
                case "VI - tafaa'ala - تفاعل":
                    _verbType = "VI";
                    break;
                case "VII - infa'ala - انفعل":
                    _verbType = "VII";
                    break;
                case "VIII - ittaf'ala - افتعل":
                    _verbType = "VIII";
                    break;
                case "IX - if'alla - افعلّ":
                    _verbType = "IX";
                    break;
                case "X - istaf'ala - استفعل":
                    _verbType = "X";
                    break;
                default:
                    _verbType = "I";
                    break;
            }
        }
        private void btnConjugate_Click(object sender, RoutedEventArgs e)
        {
            PerfectActiveList.Items.Clear();
            PerfectPassiveList.Items.Clear();
            ImperfectActiveList.Items.Clear();
            ImperfectPassiveList.Items.Clear();

            foreach (var item in _conjugator.Conjugate(_root1, _root2, _root3, "Perfect", "Active", _verbType))
            {
                PerfectActiveList.Items.Add(item);
            }

            foreach (var item in _conjugator.Conjugate(_root1, _root2, _root3, "Perfect", "Passive", _verbType))
            {
                PerfectPassiveList.Items.Add(item);
            }

            foreach (var item in _conjugator.Conjugate(_root1, _root2, _root3, "Imperfect", "Active", _verbType))
            {
                ImperfectActiveList.Items.Add(item);
            }

            foreach (var item in _conjugator.Conjugate(_root1, _root2, _root3, "Imperfect", "Passive", _verbType))
            {
                ImperfectPassiveList.Items.Add(item);
            }
        }
    }
}
