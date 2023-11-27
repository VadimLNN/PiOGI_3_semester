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
using System.Text.Json;
using Microsoft.Win32;
using System.IO;
using System.Drawing;
using System.Net;
using System.Drawing.Imaging;
using Image = System.Drawing.Image;

/*
    Список мемов    Yes
        В главном окне приложения должен присутствовать LisBox, TreeView или
        другой подобный компонент со списком названий мемов. При выделении
        одного из элементов списка происходит отображение соответствующей
        картинки в ImageBox.

    Фильтрация по категории    Yes
        В главном окне должен присутствовать ComboBox со списком категорий.
        При выборе определенной категории в списке мемов должны оставаться
        только те мемы, которые относятся к выбранной категории.

    Поиск по названию    Yes
        В главном окне должно присутствовать поле ввода для поиска по названию.
        При вводе текста в это поле ввода в списке мемов должны оставаться только
        те мемы, которые содержат в названии введенный текст (без учета регистра).

    Добавление мема в каталог    Yes
        Добавление мема в каталог должно осуществляться через диалоговое окно,
        которое имеет следующие поля ввода: название мема, расположение на
        диске, категория и др. по желанию. Расположение на диске нужно указывать
        с помощью OpenFileDialog.

    Удаление мема    Yes
        В главном окне должна присутствовать кнопка «Удалить мем». При нажатии
        на эту кнопку, выделенный мем должен удаляться.
        Хранение данных о мемах должно быть реализовано с помощью json или xml
        файла. При этом в главном окне программы должны быть 2 кнопки:
        «Сохранить» и «Загрузить». При сохранении информация о добавленных
        мемах должна записаться в файл, при загрузке должен отобразиться список
        ранее сохраненных мемов.

    Доп. задания на хорошо и отлично:
        - реализовать возможность добавления мема по url;
        - реализовать возможность добавления тегов с поиском по тегам.
*/

namespace meme_catalog
{
    public partial class MainWindow : Window
    {
        // Каталог с мемами
        List<Mem> memes = new List<Mem>();
        List<Mem> temp_memes = new List<Mem>();

        // Json файл с мемами 
        static string fileName = "MemesCatalog.json";

        public MainWindow()
        {
            InitializeComponent();

            // добавдение общей категории
            meme_categories.Items.Add("all");

            if (File.Exists(fileName))
            {
                // чтение мемов из Json файла 
                List<Mem> readed_memes = JsonSerializer.Deserialize<List<Mem>>(File.ReadAllText(fileName));

                // обновление списка мемов 
                foreach (Mem mem in readed_memes)
                {
                    // добавление мемов в main список 
                    memes.Add(mem);

                    // добавление мемов в ListBox
                    meme_list.Items.Add(mem.Name);

                    // добавление категорий в ComboBox
                    if (!(meme_categories.Items.Contains(mem.Category)))
                        meme_categories.Items.Add(mem.Category);

                }
            }
        }

        private void meme_down_Click(object sender, RoutedEventArgs e)
        {
            // поиск файла img 
            OpenFileDialog dlg = new OpenFileDialog();
            if (!(bool)dlg.ShowDialog())
                return;

            // запись пути до img 
            Uri fileUri = new Uri(dlg.FileName);

            // открытие окна для записи тега и имени мема 
            Add_meme add_mem_wnd = new Add_meme();

            if (add_mem_wnd.ShowDialog() == true)
            {
                // перевод картинки в строку байт
                byte[] imageArray = System.IO.File.ReadAllBytes(dlg.FileName);
                string base64ImageRepresentation = Convert.ToBase64String(imageArray);

                // создание мема из собранных данных
                Mem mem = new Mem(add_mem_wnd.add_name_meme.Text, base64ImageRepresentation, add_mem_wnd.add_tag_meme.Text);

                // добавление мема в каталог и ListBox
                memes.Add(mem);
                meme_list.Items.Add(mem.Name);

                // добавление категорий в ComboBox
                if (!(meme_categories.Items.Contains(mem.Category)))
                    meme_categories.Items.Add(mem.Category);
            }


        }

        static ImageSource ByteToImage(byte[] imageData)
        {
            var bitmap = new BitmapImage();
            MemoryStream ms = new MemoryStream(imageData);
            bitmap.BeginInit();
            bitmap.StreamSource = ms;
            bitmap.EndInit();

            return (ImageSource)bitmap;
        }

        private void memes_save_Click(object sender, RoutedEventArgs e)
        {
            // запись мемов в файл
            string jsonString = JsonSerializer.Serialize(memes);
            File.WriteAllText(fileName, jsonString);
        }

        private void meme_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((meme_categories.SelectedIndex == -1 || meme_categories.SelectedIndex == 0) && (meme_find.Text.Length == 0 && meme_find_by_tag.Text.Length == 0))
            {
                if (meme_list.SelectedIndex != -1)
                    meme_img.Source = ByteToImage(Convert.FromBase64String(memes[meme_list.SelectedIndex].Img));
            }
            else
                if (meme_list.SelectedIndex != -1)
                    meme_img.Source = ByteToImage(Convert.FromBase64String(temp_memes[meme_list.SelectedIndex].Img));
        }

        private void meme_del_Click(object sender, RoutedEventArgs e)
        {
            if (meme_list.SelectedIndex != -1 && meme_list.Items.Count == memes.Count)
            {
                memes.Remove(memes[meme_list.SelectedIndex]);
                meme_list.Items.Clear();

                foreach (Mem mem in memes)
                    meme_list.Items.Add(mem.Name);
            }
            else
                MessageBox.Show("Select category all");
        }

        private void find_mem_Click(object sender, RoutedEventArgs e)
        {
            meme_list.Items.Clear();
            temp_memes.Clear();
            foreach (Mem mem in memes)
            {
                if (mem.Name.ToLower().Contains(meme_find.Text.ToLower()))
                {
                    meme_list.Items.Add(mem.Name);
                    temp_memes.Add(mem);
                }
            }
        }
        
        private void meme_categories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (meme_categories.SelectedIndex != -1)
            {
                meme_list.Items.Clear();
                if (meme_categories.SelectedItem.ToString().Equals("all"))
                {
                    foreach (Mem mem in memes)
                        meme_list.Items.Add(mem.Name);
                    return;
                }
                
                temp_memes.Clear();
                
                foreach (Mem mem in memes)
                {
                    if (mem.Category == meme_categories.SelectedItem.ToString())
                    {
                        meme_list.Items.Add(mem.Name);
                        temp_memes.Add(mem);
                    }    
                }
            }
        }

        private void meme_url_down_Click(object sender, RoutedEventArgs e)
        {
            Add_url_meme add_url_mem_wnd = new Add_url_meme();

            if (add_url_mem_wnd.ShowDialog() == true)
            {
                WebClient client = new WebClient();

                string imageUrl = add_url_mem_wnd.url.Text;

                byte[] imageArray = client.DownloadData(imageUrl);

                string base64ImageRepresentation = Convert.ToBase64String(imageArray);

                Mem mem = new Mem(add_url_mem_wnd.name.Text, base64ImageRepresentation, add_url_mem_wnd.tag.Text);

                // добавление мема в каталог и ListBox
                memes.Add(mem);
                meme_list.Items.Add(mem.Name);

                // добавление категорий в ComboBox
                if (!(meme_categories.Items.Contains(mem.Category)))
                    meme_categories.Items.Add(mem.Category);
            }
        }

        private void find_mem_by_tag_Click(object sender, RoutedEventArgs e)
        {
            meme_list.Items.Clear();
            temp_memes.Clear();
            foreach (Mem mem in memes)
            {
                foreach (string tag in mem.Tags)
                {
                    if (tag.ToLower().Equals(meme_find_by_tag.Text.ToLower()))
                    {
                        meme_list.Items.Add(mem.Name);
                        temp_memes.Add(mem);
                    }
                }
            }
        }

        private void add_tag_Click(object sender, RoutedEventArgs e)
        {
            if (meme_list.SelectedIndex != -1 && meme_list.Items.Count == memes.Count && meme_add_tag.Text.Length > 0)
            {
                memes[meme_list.SelectedIndex].add_tag(meme_add_tag.Text);
            }
            else
                MessageBox.Show("Select category all or fill in the tag field");
        }
    }
}