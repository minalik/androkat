﻿using androkat.hu.Models;
using androkat.hu.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace androkat.hu.ViewModels;

public partial class ContentViewModel : ObservableObject
{
    public ContentDto ContentDto { get; set; }

    public string contentImg { get; set; }

    public bool isFav { get; set; }

    public Activities type { get; set; }

    public string detailscim { get; set; }

    public string datum { get; set; }

    public string forras { get; set; }

    public ContentViewModel(ContentDto contentDto)
    {
        ContentDto = contentDto;
    }

    [RelayCommand]
    Task NavigateToDetail() => Shell.Current.GoToAsync($"{nameof(ShowDetailPage)}?Id={ContentDto.Nid}");
}