using System.IO;
using System.Windows;
using System.Windows.Documents;
using Microsoft.Win32;

namespace NotePad_for_Test {
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow {
		public MainWindow() {
			InitializeComponent();
		}


		private void SaveMenu(object sender, RoutedEventArgs e) {
			var save = new SaveFileDialog { Filter = "Файл .TXT (*.txt)|*.txt" };

			if (save.ShowDialog() != true)
				return;
			var documentTextRange = new TextRange(RichTextBox.Document.ContentStart, RichTextBox.Document.ContentEnd);

			using (var fs = File.Create(save.FileName)) {
				var extension = Path.GetExtension(save.FileName);
				if (extension != null && extension.ToLower() == ".txt") {
					documentTextRange.Save(fs, DataFormats.Text);
				}
			}
		}


		private void OpenMenu(object sender, RoutedEventArgs e) {
			var openFile = new OpenFileDialog { Filter = "Файл .TXT (*.txt)|*.txt|All files (*.*)|*.*" };

			if (openFile.ShowDialog() != true)
				return;
			var textRange = new TextRange(RichTextBox.Document.ContentStart, RichTextBox.Document.ContentEnd);

			using (var fs = File.Open(openFile.FileName, FileMode.Open)) {
				textRange.Load(fs, DataFormats.Text);
			}
		}
		private void NewMenu (object sender, RoutedEventArgs e) {
			RichTextBox.Document = new FlowDocument();
		}

		private void ExitMenu(object sender, RoutedEventArgs e) {
			Application.Current.Shutdown();
		}
	}
}