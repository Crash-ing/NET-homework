namespace MAUI.Forms;

public partial class AddItemsPage : ContentPage
{
	public AddItemsPage()
	{
		InitializeComponent();
	}

    private async void AddITSupportClicked(object sender, EventArgs e)
    {
        var its = new AddItemsForms.AddITSupport();
        await Navigation.PushAsync(its);
    }

    private async void AddTicketClicked(object sender, EventArgs e)
    {
        var tc = new AddItemsForms.AddTicket();
        await Navigation.PushAsync(tc);
    }

    private async void AddAssignmentClicked(object sender, EventArgs e)
    {
        var asg = new AddItemsForms.AddAssignment();
        await Navigation.PushAsync(asg);
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {

    }
}