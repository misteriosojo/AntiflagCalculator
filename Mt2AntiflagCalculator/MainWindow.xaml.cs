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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mt2AntiflagCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CheckBox[] checkBox;

        public MainWindow()
        {
            InitializeComponent();
            InitCheckBox();
            InitTriggers();
        }

        /// <summary>
        /// Init each single checkbox
        /// </summary>
        private void InitCheckBox()
        {
            checkBox = new CheckBox[] {
                ITEM_ANTIFLAG_FEMALE,
                ITEM_ANTIFLAG_MALE,
                ITEM_ANTIFLAG_WARRIOR,
                ITEM_ANTIFLAG_ASSASSIN,
                ITEM_ANTIFLAG_SURA,
                ITEM_ANTIFLAG_SHAMAN,
                ITEM_ANTIFLAG_GET,
                ITEM_ANTIFLAG_DROP,
                ITEM_ANTIFLAG_SELL,
                ITEM_ANTIFLAG_EMPIRE_A,
                ITEM_ANTIFLAG_EMPIRE_B,
                ITEM_ANTIFLAG_EMPIRE_C,
                ITEM_ANTIFLAG_SAVE,
                ITEM_ANTIFLAG_GIVE,
                ITEM_ANTIFLAG_PKDROP,
                ITEM_ANTIFLAG_STACK,
                ITEM_ANTIFLAG_MYSHOP,
                ITEM_ANTIFLAG_SAFEBOX,
                ITEM_ANTIFLAG_WOLFMAN,
                ITEM_ANTIFLAG_BIND,
                ITEM_ANTIFLAG_MY_OFFLINE_SHOP
            };

            foreach (CheckBox cb in checkBox)
            {
                cb.Checked += CheckBoxStatusChanged;
                cb.Unchecked += CheckBoxStatusChanged;

                if (!cb.IsChecked.Value)
                    cb.IsChecked = true;
            }
        }

        private void InitTriggers()
        {
            IntegerValue.TextChanged += new TextChangedEventHandler(NumberChanged);
        }

        /// <summary>
        /// Trigger for Checkbox status changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxStatusChanged(object sender, RoutedEventArgs e)
        {
            CalcIntegerValue();
        }

        /// <summary>
        /// Calculate the integer value corresponding to the current antiflag combination
        /// </summary>
        private void CalcIntegerValue()
        {
            int tmp = 0;

            for (int i = 0; i < checkBox.Length; i++)
                if (!checkBox[i].IsChecked.Value)
                    tmp += (int)Math.Pow(2, i);

            IntegerValue.Text = "" + tmp;
        }

        /// <summary>
        /// Trigger for Number value changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberChanged(object sender, TextChangedEventArgs e)
        {
            CalcNumber();
        }

        /// <summary>
        /// Calculate the flags corresponding to the current integer number written
        /// </summary>
        private void CalcNumber()
        {
            if ((IntegerValue.Text == null) || (IntegerValue.Text.Length == 0))
                return;

            int parsed;
            try { parsed = Int32.Parse(IntegerValue.Text); }
            catch (FormatException) { return; }

            int tmp = 0;

            for (int i = 0; i < checkBox.Length; i++)
            {
                tmp = (int)Math.Pow(2, i);
                checkBox[i].IsChecked = ((parsed & tmp) != tmp);
            }
        }
    }
}
