using HnbREST.Services.HnbService;
using HnbREST.Services.RestService;

namespace HnbREST.Views;

public partial class InputPage : ContentPage
{
    IHnbService _hnbService;
    public InputPage(IHnbService hnbService)
    {
        InitializeComponent();
        _hnbService = hnbService;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ErrorLabel.IsVisible = false;
        LoadingLabel.IsVisible = false;
        DateFrom.SelectedDate = null;
        DateTo.SelectedDate = null;
    }

    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        DateTime? dateFrom = DateFrom?.SelectedDate;
        DateTime? dateTo = DateTo?.SelectedDate;

        if (dateFrom.HasValue && dateTo.HasValue)
        {
            if (dateFrom.Value < dateTo.Value)
            {
                LoadingLabel.IsVisible = true;
                LoadingLabel.Text = "Loading...";
                ErrorLabel.IsVisible = false;

                var currencies = await _hnbService.GetTasksAsync((DateTime)dateFrom, (DateTime)dateTo);

                if (currencies.Count > 0)
                {
                    await Navigation.PushAsync(new TablePage(currencies));
                }
                else
                {
                    LoadingLabel.IsVisible = false;
                    ErrorLabel.IsVisible = true;
                    ErrorLabel.Text = "No data!";
                }
            }
            else
            {
                ErrorLabel.IsVisible = true;
                ErrorLabel.Text = "FROM date must be lower than TO date.";
            }
        }
        else
        {
            ErrorLabel.IsVisible = true;
            ErrorLabel.Text = "Please select both dates.";
        }
    }

}