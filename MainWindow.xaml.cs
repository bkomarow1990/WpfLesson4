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

namespace WpfLesson4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        List<int> sizes = new List<int>();
        private void InitComboBox()
        {
            for (int i = 0; i <= 72; i+=2)
            {
                sizes.Add(i);
            }
            ComboBoxSizes.ItemsSource = sizes;
            
        }
        public MainWindow()
        {
            InitializeComponent();
            InitComboBox();
        }

        private void ItalicBtn_Click(object sender, RoutedEventArgs e)
        {
            TextRange r = new TextRange(DocRichTextBox.Selection.Start, DocRichTextBox.Selection.End);
            r.ApplyPropertyValue(TextElement.FontStyleProperty, "Italic");
        }

        private void UnderlineBtn_Click(object sender, RoutedEventArgs e)
        {
            TextRange r = new TextRange(DocRichTextBox.Selection.Start, DocRichTextBox.Selection.End);
            if (r.GetPropertyValue(Inline.TextDecorationsProperty).ToString() == "Underline")
            {

            }
            else
            {
                r.ApplyPropertyValue(Inline.TextDecorationsProperty, "Underline");
            }
            
        }

        private void BoldBtn_Click(object sender, RoutedEventArgs e)
        {
            TextRange r = new TextRange(DocRichTextBox.Selection.Start, DocRichTextBox.Selection.End);
            if (r.GetPropertyValue(TextElement.FontWeightProperty).ToString() == "Bold")
            {
                r.ApplyPropertyValue(TextElement.FontWeightProperty, "Normal");
            }
            else
            {
                r.ApplyPropertyValue(TextElement.FontWeightProperty, "Bold");
            }
            
            
        }

        private void CLearBtn_Click(object sender, RoutedEventArgs e)
        {
            TextRange r = new TextRange(DocRichTextBox.Selection.Start, DocRichTextBox.Selection.End);
            
            r.ClearAllProperties();
        }

        private void ComboBoxSizes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextRange r = new TextRange(DocRichTextBox.Selection.Start, DocRichTextBox.Selection.End);
            r.ApplyPropertyValue(TextElement.FontSizeProperty, Int32.Parse(ComboBoxSizes.SelectedItem.ToString()) );
        }
    }
}
