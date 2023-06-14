using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ORM_00.Classes;
using ORM_00.Database;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ORM_00;

public partial class StageWindow : Window
{
    public StageWindow()
    {
        InitializeComponent();
        InitElementss();
        loadDatas();
    }

    public void InitElementss()
    {
        backButt.Click += BackButt_Click;
        HisButt.Click += HisButt_Click;
        addButt.Click += AddButt_Click;
        searchBox.AddHandler(KeyUpEvent, SearchBox_KeyUp, Avalonia.Interactivity.RoutingStrategies.Tunnel);
        sortBox.SelectionChanged += SortBox_SelectionChanged;
        filtBox.SelectionChanged += FiltBox_SelectionChanged;
        loadDatas();
    }

    private async void AddButt_Click(object? sender, RoutedEventArgs e)
    {
        EditAddStages editAddStages = new EditAddStages();
        await editAddStages.ShowDialog(this);
        loadDatas();
    }

    private void HisButt_Click(object? sender, RoutedEventArgs e)
    {
        
    }
    private void GoinButt_Click(object? sender, RoutedEventArgs e)
    {
        Documenst documenst = new Documenst();
        documenst.Show();
        this.Close();
    }
    

    private void FiltBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        loadDatas();
    }

    private void SortBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        loadDatas();
    }

    private void SearchBox_KeyUp(object? sender, Avalonia.Input.KeyEventArgs e)
    {
        loadDatas();
    }

    //Реализация удаления
    private void DelButt_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        int Rem = (int)(sender as Button).Tag;
        DBClass.db.Stages.Remove(DBClass.db.Stages
                                                    .Find(Rem));
        DBClass.db.SaveChanges();
        loadDatas();
    }

    private async void EditButt_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        int id = (int)(sender as Button).Tag;
        EditAddStages addEditWindow = new EditAddStages(DBClass.db.Stages.FirstOrDefault(x => x.Idstage == id));
        await addEditWindow.ShowDialog(this);
        loadDatas();
    }



    private void BackButt_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        this.Close();
    }

    public void loadDatas()
    {
        //Лист с таблицей продукции
        List<Stage> stages = new List<Stage>();
        //Заполенение листа
        stages = DBClass.db.Stages.ToList();
        List<STGclass> STGclasses = new List<STGclass>();
        int count;

        //Реализация поиска
        string search = searchBox.Text ?? "";
        if (!string.IsNullOrEmpty(search))
        {
            stages = stages.Where(x => x.Stagename.Trim()
                                                        .ToLower()
                                                        .Contains(search
                                                        .Trim()
                                                        .ToLower())).ToList();

                                                        //||
                                                        //x.Numberstage.Trim()
                                                        //                    .ToLower()
                                                        //                    .Contains(search
                                                        //                    .Trim()
                                                        //                    .ToLower())).ToList();
        }

        //Реализация сортировки
        switch (sortBox.SelectedIndex)
        {
            case 0:
                stages = stages.ToList();
                break;

            case 1:
                stages = stages.OrderBy(x => x.Startday)
                                                                         .ToList();
                break;
            case 2:
                stages = stages.OrderByDescending(x => x.Startday)
                                                               .ToList();
                break;
            case 3:
                stages = stages.OrderBy(x => x.Stagename)
                                                               .ToList();
                break;
        }

        //Реализация фильтрации
        switch (filtBox.SelectedIndex)
        {



        }

        foreach (Stage stage in stages)
        {
            STGclasses.Add(new STGclass
            {
                Id = stage.Idstage,
                Idok = $"Наименование: {stage.Idokp}",

                Numberstg = $"Наименование документа: {stage.Numberstage}",

                Stagenm = $"Наименование документа: {stage.Stagename}",

                Numberofproduct = $"Наименование документа: {stage.Numberofproducts}",

                Startdy = $"Наименование документа: {stage.Startday}",

                Enddy = $"Наименование документа: {stage.Endday}",

            });
        }

        //Вывод кол-ва данных
        listBox.Items = STGclasses.ToList();
        countBlock.Text = $"{stages.Count} из {DBClass.db.Stages.Count()}";

    }

    //private string GetColor(string status)
    //{
    //    switch (status)
    //    {
    //        case "Завершён":
    //            return "White";
    //        case "Текущий":
    //            return "Green";
    //        case "Запланированный":
    //            return "Grey";
    //        case "Отменнён":
    //            return "Red";
    //    }
    //}

    private string GetManufacturer(int productmanufacturer)
    {
        switch (productmanufacturer)
        {
            case 1:
                return "Производитель: М500";

            case 2:
                return "Производитель: Изостронг";

            case 3:
                return "Производитель: Knauf";

            case 4:
                return "Производитель: MixMaster";

            case 5:
                return "Производитель: ЛСР";

            case 6:
                return "Производитель: ВОЛМА";

            case 7:
                return "Производитель: Vinylon";

            case 8:
                return "Производитель: Павловский завод ";

            case 9:
                return "Производитель: Weber";

            case 10:
                return "Производитель: Hesler";

            case 11:
                return "Производитель: Armero";

            case 12:
                return "Производитель: Wenzo Roma";

            case 13:
                return "Производитель: KILIMGRIN";

            case 14:
                return "Производитель: Исток";

            case 15:
                return "Производитель: RUIZ";

            case 16:
                return "Производитель: Husqvarna";

            case 17:
                return "Производитель: Delta";
        }
        return "";
    }
}