using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DataProtectionApp.Models;
using DataProtectionApp.Services;
using DataProtectionApp.Contacts;

namespace DataProtectionApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IDataProtectionService _dataProtectionService;

    public HomeController(ILogger<HomeController> logger, IDataProtectionService dataProtectionService)
    {
        _logger = logger;
        _dataProtectionService = dataProtectionService;
    }

    public IActionResult Index()
    {
        string sensitiveData = "MySecretPassword";

        // Protect the data
        string protectedData = _dataProtectionService.Protect(sensitiveData);

        // Unprotect the data
        string unprotectedData = _dataProtectionService.Unprotect(protectedData);

        // Example output
        ViewBag.Protected = protectedData;
        ViewBag.Unprotected = unprotectedData;

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
