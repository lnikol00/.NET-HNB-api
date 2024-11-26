using HnbREST.Models;
using Microsoft.Maui.Controls;

namespace HnbREST.Views;

public partial class TablePage : ContentPage
{
    public List<ViewResultModel> Results { get; set; }

    public TablePage(List<ViewResultModel> currencies)
    {
        InitializeComponent();
        Results = currencies;
        BindingContext = this;
    }

    private async Task FetchDataAsync()
    {
        try
        {
            await Task.Delay(1000);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during async fetch: {ex.Message}");
        }
    }

}