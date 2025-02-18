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

namespace CRUDApp
{
    public partial class MainWindow : Window
    {
        private BookService bookService = new BookService();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = bookService;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string tilteText = TitleTextBox.Text;
            string authorText = AuthorTextBox.Text;        
            if (!string.IsNullOrEmpty(tilteText) && !string.IsNullOrEmpty(authorText)) {
                Book newBook = new Book(tilteText, authorText);
                bookService.AddBook(newBook);
                TitleTextBox.Clear();
                AuthorTextBox.Clear();
                
            }
            else
            {
                MessageBox.Show("Введите данные!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedBook = BooksListView.SelectedItem as Book;
            if(selectedBook != null)
            {
                bookService.RemoveBook(selectedBook);
                TitleTextBox.Clear();
                AuthorTextBox.Clear();
                MessageBox.Show("Книга удалена", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Выберите книгу для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void BooksListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedBook = BooksListView.SelectedItem as Book;
            if (selectedBook != null)
            {
                TitleTextBox.Text = selectedBook.Title;
                AuthorTextBox.Text = selectedBook.Author;
            }
            else
            {
                TitleTextBox.Clear();
                AuthorTextBox.Clear();
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedBook = BooksListView.SelectedItem as Book;
            string titleText = TitleTextBox.Text;
            string authorText = AuthorTextBox.Text;

            if (selectedBook != null && !string.IsNullOrEmpty(titleText) && !string.IsNullOrEmpty(authorText))
            {
                selectedBook.Title = titleText;
                selectedBook.Author = authorText;
                TitleTextBox.Clear();
                AuthorTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Выберите книгу и заполните данные!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}
