using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ORM_00.Classes;
using ORM_00.Database;
using System.Collections.Generic;
using System;
using System.Linq;
using System.IO;

namespace ORM_00;

public partial class Documenst : Window
{
    public Documenst()
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
        AddDocuments addEditWindow = new AddDocuments();
        await addEditWindow.ShowDialog(this);
        loadDatas();
    }

    private void HisButt_Click(object? sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
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
        DBClass.db.Okps.Remove(DBClass.db.Okps
                                                    .Find(Rem));
        DBClass.db.SaveChanges();
        loadDatas();
    }

    private void BackButt_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        this.Close();
    }

    private async void DownButt_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var documentss = (Dockclass)(sender as Button).Tag;
        OpenFolderDialog openFolderDialog = new OpenFolderDialog();
        var path = await openFolderDialog.ShowAsync(this);
        File.WriteAllBytes(path +"\\" + documentss.Regulatorygosts + documentss.Formatdocument, documentss.Documentss);
    }

    public void loadDatas()
    {
        //Лист с таблицей продукции
        List<Documentsduringstage> docks = new List<Documentsduringstage>();
        //Заполенение листа
        docks = DBClass.db.Documentsduringstages.ToList();
        List<Dockclass> dockclasses = new List<Dockclass>();
        int count;

        //Реализация поиска
        string search = searchBox.Text ?? "";
        if (!string.IsNullOrEmpty(search))
        {
            docks = docks.Where(x => x.Regulatorygost.Trim()
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
                docks = docks.ToList();
                break;

            case 1:
                docks = docks.OrderByDescending(x => x.Iddocument)
                                                                         .ToList();
                break;
            case 2:
                docks = docks.OrderBy(x => x.Iddocument)
                                                               .ToList();
                break;
        }

        //Реализация фильтрации
        switch (filtBox.SelectedIndex)
        {



        }

        foreach (Documentsduringstage dock in docks)
        {
            dockclasses.Add(new Dockclass
            {

                Iddocuments = dock.Iddocument,
                Idstages = dock.Idstage,
                Regulatorygosts = dock.Regulatorygost,
                Documentss = dock.Documents,
                Formatdocument = dock.Formatdocument,
            });
        }

        //Вывод кол-ва данных
        listBox.Items = dockclasses.ToList();
        countBlock.Text = $"{docks.Count} из {DBClass.db.Documentsduringstages.Count()}";

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

