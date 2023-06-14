using Avalonia.Controls;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;
using ORM_00.Classes;
using ORM_00.Database;
using System;
using System.IO;
using System.Linq;

namespace ORM_00
{
    public partial class AddDocuments : Window
    {

        private Documentsduringstage documentsduringstage = new Documentsduringstage();
        public AddDocuments()
        {
            InitializeComponent();
            adddoc.Click += Adddoc_Click;
            SaveDoc.Click += SaveDoc_Click;
            this.DataContext = documentsduringstage;

            numberstage.Items = DBClass.db.Stages.Select(x => new ComboBoxItem()
            {
                Content = x.Stagename,
                Tag = x.Idstage
            }).ToList();
            numberstage.SelectionChanged += Numberstage_SelectionChanged;

        }

        private void Numberstage_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            this.documentsduringstage.Idstage = (int)(numberstage.SelectedItem as ComboBoxItem).Tag;
        }

        private void SaveDoc_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            try
            {
                DBClass.db.Add(this.documentsduringstage);
                DBClass.db.SaveChanges();
                this.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private async void Adddoc_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            var path = await dialog.ShowAsync(this);
            if (path == null) { return; }
            if (
                Path.GetExtension(path[0]) != ".docx" & Path.GetExtension(path[0]) != ".pdf")
            {
                return;
            }
            docpath.Text = path[0];

            documentsduringstage.Documents = File.ReadAllBytes(path[0]);
            documentsduringstage.Formatdocument = Path.GetExtension(path[0]);
        }
    }
}
