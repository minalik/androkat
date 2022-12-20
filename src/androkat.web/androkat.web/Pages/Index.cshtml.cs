using androkat.application.Interfaces;
using androkat.domain.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace androkat.web.Pages;

public class IndexModel : PageModel
{
    private readonly IMainPageService _mainPageService;

    public IndexModel(IMainPageService mainPageService)
    {
        _mainPageService = mainPageService;
    }

    public IEnumerable<ContentModel> ContentModels { get; set; }

    public void OnGet()
    {
        ContentModels = _mainPageService.GetHome();
    }
}