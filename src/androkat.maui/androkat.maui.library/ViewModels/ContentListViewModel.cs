﻿using androkat.maui.library.Abstraction;
using androkat.maui.library.Models;
using androkat.maui.library.Models.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmHelpers;

namespace androkat.maui.library.ViewModels;

[QueryProperty(nameof(Id), nameof(Id))]
public partial class ContentListViewModel : ViewModelBase
{
    private readonly IPageService _pageService;
    private readonly ISourceData _sourceData;

    public string Id { get; set; }

    [ObservableProperty]
    public string pageTitle;

    [ObservableProperty]
    ObservableRangeCollection<List<ContentItemViewModel>> contents;

    public ContentListViewModel(IPageService pageService, ISourceData sourceData)
    {
        _pageService = pageService;
        Contents = new ObservableRangeCollection<List<ContentItemViewModel>>();
        _sourceData = sourceData;
    }

    public async Task InitializeAsync()
    {
        //Delay on first load until window loads
        await Task.Delay(1000);
        await FetchAsync();
    }

    private async Task FetchAsync()
    {
        var contents = await _pageService.GetContentsAsync(Id);

        if (contents == null)
        {
            await Shell.Current.DisplayAlert("Hiba", "Nincs adat", "Bezárás");
            return;
        }

        var temp = ConvertToViewModels(contents);
        var s = new List<List<ContentItemViewModel>> { temp.ToList() };
        Contents.ReplaceRange(s);
    }

    private List<ContentItemViewModel> ConvertToViewModels(IEnumerable<ContentEntity> items)
    {
        var viewmodels = new List<ContentItemViewModel>();
        foreach (var item in items)
        {
            SourceData idezetSource = _sourceData.GetSourcesFromMemory(int.Parse(item.Tipus));
            var origImg = item.Image;
            item.Image = idezetSource.Img;
            var viewModel = new ContentItemViewModel(item, true)
            {
                datum = $"Dátum: {item.Datum.ToString("yyyy-MM-dd")}",
                detailscim = idezetSource.Title,
                contentImg = origImg,
                isFav = false,
                forras = $"Forrás: {idezetSource.Forrasszoveg}",
                type = ActivitiesHelper.GetActivitiesByValue(int.Parse(item.Tipus))
            };
            viewmodels.Add(viewModel);
        }

        return viewmodels;
    }

    [RelayCommand]
    public async Task Subscribe(ContentItemViewModel viewModel) => Task.Run(() => { });
}