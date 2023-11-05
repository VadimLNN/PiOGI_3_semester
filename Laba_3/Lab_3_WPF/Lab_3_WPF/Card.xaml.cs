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

namespace Lab_3_WPF
{
    public partial class Card : UserControl
    {
        public static readonly DependencyProperty CardNameProperty = DependencyProperty.Register(
                                                                 "Name", // имя параметра в разметке
                                                                 typeof(string), // тип данных параметра
                                                                 typeof(Card), // тип данных элемента управления
                                                                 // метаданные - значение параметра по умолчанию и обработчик изменения параметра
                                                                 new PropertyMetadata(string.Empty, NameChanged));

        public static readonly DependencyProperty CardPicProperty = DependencyProperty.Register(
                                                                 "CardPic", // имя параметра в разметке
                                                                 typeof(ImageSource), // тип данных параметра
                                                                 typeof(Card), // тип данных элемента управления
                                                                 // метаданные - значение параметра по умолчанию и обработчик изменения параметра
                                                                 new PropertyMetadata(null, PicChanged));

        public string Cardname
        {
            get { return (string)GetValue(CardNameProperty); }
            set { SetValue(CardNameProperty, value); }
        }

        public ImageSource Pic
        {
            get { return (ImageSource)GetValue(CardPicProperty); }
            set { SetValue(CardPicProperty, value); }
        }


        public static void NameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var loginForm = d as Card;
            loginForm.Name.Content = loginForm.Cardname;
        }
        public static void PicChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var loginForm = d as Card;
            loginForm.CardPic.Source = loginForm.Pic;
        }

        public Card()
        {
            InitializeComponent();
        }
    }
}
