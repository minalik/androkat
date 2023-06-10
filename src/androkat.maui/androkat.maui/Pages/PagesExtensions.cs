﻿namespace androkat.hu.Pages;

public static class PagesExtensions
{
    public static MauiAppBuilder ConfigurePages(this MauiAppBuilder builder)
    {
        // pages
        builder.Services.AddSingleton<ContentListPage>();
        builder.Services.AddSingleton<ImaListPage>();
        builder.Services.AddSingleton<FavoriteListPage>();
        builder.Services.AddSingleton<WebPage>();
        builder.Services.AddSingleton<ContactPage>();
        builder.Services.AddSingleton<SettingsPage>();

        // pages that are navigated to
        builder.Services.AddTransient<ShowDetailPage>();

        return builder;
    }
}
