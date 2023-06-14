using Avalonia.Controls;
using ORM_00.Classes;
using ORM_00.Database;
using System;
using System.Linq;

namespace ORM_00
{
    public partial class EditAddStages : Window
    {
        Stage stage = new Stage();
        public EditAddStages()
        {
            InitializeComponent();

            this.DataContext = stage;
            SaveButt.Click += SaveButt_Click;
            Idokp.Items = DBClass.db.Okps.Select(x => new ComboBoxItem()
            {
                Content = x.Name,
                Tag = x.Id,
            }).ToList();
        }


        public EditAddStages(Stage stage)
        {
            InitializeComponent();

            this.stage = stage;
            this.DataContext = stage;
            SaveButt.Click += SaveButt_Click;

            Startday.SelectedDate = new DateTimeOffset(new DateTime(stage.Startday.Value.Year, stage.Startday.Value.Month, stage.Startday.Value.Day));
            Endday.SelectedDate = new DateTimeOffset(new DateTime(stage.Endday.Value.Year, stage.Endday.Value.Month, stage.Endday.Value.Day));

            Idokp.Items = DBClass.db.Okps.Select(x => new ComboBoxItem()
            {
                Content = x.Name,
                Tag = x.Id,
            }).ToList();
            Idokp.SelectedIndex = DBClass.db.Okps.ToList().FindIndex(x => x.Id == this.stage.Idokp);
            var test = DBClass.db.Okps.ToList().FindIndex(x => x.Id == this.stage.Idstage);
            Console.WriteLine("button");

        }

        private void SaveButt_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {

            try
            {
                this.stage.Startday = DateOnly.FromDateTime(Startday.SelectedDate.Value.DateTime);
                this.stage.Endday = DateOnly.FromDateTime(Endday.SelectedDate.Value.DateTime);
                this.stage.Idokp = (int)(Idokp.SelectedItem as ComboBoxItem).Tag;
                if (DBClass.db.Stages.Contains(this.stage) == false)
                {
                    DBClass.db.Stages.Add(this.stage);
                }
                DBClass.db.SaveChanges();
                this.Close();
            }
            catch (Exception ex) { }
        }
    }
}
