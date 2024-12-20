﻿using androkat.maui.library.ViewModels;

namespace androkat.hu.Pages;

public partial class KeresztutPage : ContentPage
{
    private KeresztutViewModel ViewModel => (BindingContext as KeresztutViewModel)!;

    public KeresztutPage(KeresztutViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await ViewModel.InitializeAsync();
    }
}