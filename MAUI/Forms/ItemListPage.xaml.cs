namespace MAUI.Forms;
using Users;
using User;
using MAUI.Forms.AddItemsForms;

public partial class ItemListPage : ContentPage
{
    private ObjectAddManager obj;
    private IRemove rf;

    public ItemListPage()
	{
		InitializeComponent();
        obj = AppData.Instance.oam;
        rf = obj;
        cVList.ItemsSource = obj.objList;
	}
    
    private async void EditClicked(object sender, EventArgs e)
    {
        var b = sender as Button;
        if (b != null)
        {
            if (b.BindingContext is Ticket)
            {
                var ticket = (Ticket)b.BindingContext;
                var tickPage = new AddTicket(ticket);
                await Navigation.PushAsync(tickPage);
            }
            else if (b.BindingContext is Assignement)
            {
                var ass = (Assignement)b.BindingContext;
                var assPage = new AddAssignment(ass);
                await Navigation.PushAsync(assPage);
            }
            else if (b.BindingContext is ITSupport)
            {
                var its = (ITSupport)b.BindingContext;
                var itsPage = new AddITSupport(its);
                await Navigation.PushAsync(itsPage);
            }
        }
    }

    private async void DeleteClicked(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.BindingContext is object item)
        {
            bool answer = await DisplayAlert("Question?", "vai gribāt dzēst? " + item.ToString(), "yes", "no");
            if (!answer) return;

            rf.Remove(item);
            cVList.ItemsSource = null;
            cVList.ItemsSource = obj.objList;
        }
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        // Ensure you use the updated manager
        obj = AppData.Instance.oam;
        rf = obj;

        cVList.ItemsSource = null;
        cVList.ItemsSource = obj.objList;
    }
}