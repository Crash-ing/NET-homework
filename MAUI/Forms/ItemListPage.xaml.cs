namespace MAUI.Forms;
using Users;
using User;
using MAUI.Forms.AddItemsForms;

public partial class ItemListPage : ContentPage
{
    private DataStore dataStore;
    
    public ItemListPage()
	{
		InitializeComponent();
        dataStore = AppData.Instance;
        var itemsList = (dataStore.Tickets?.Cast<object>() ?? Enumerable.Empty<object>()).Concat(dataStore.Assignements?.Cast<object>() ?? Enumerable.Empty<object>()).ToList();
        // sakombinē visus sarakstus iekš viena ItemsSource
        cVList.ItemsSource = itemsList;
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
            if (b.BindingContext is Assignement)
            {
                var ass = (Assignement)b.BindingContext;
                var assPage = new AddAssignment(ass);
                await Navigation.PushAsync(assPage);
            }
        }
    }

    private async void DeleteClicked(object sender, EventArgs e)
    {
        var itemsList = (dataStore.Tickets?.Cast<object>() ?? Enumerable.Empty<object>()).Concat(dataStore.Assignements?.Cast<object>() ?? Enumerable.Empty<object>()).ToList();
        if (sender is Button)
        {
            Button btn = (Button)sender;
            if (btn.BindingContext is Ticket)
            {
                Ticket t = (Ticket)btn.BindingContext;
                bool answer = await DisplayAlert("Question?", "vai gribāt dzēst?" + t.ToString(), "yes", "no");
                if (answer)
                {
                    dataStore.Tickets.Remove(t);
                    cVList.ItemsSource = null;
                    cVList.ItemsSource = itemsList;
                }
                else
                {
                    return;
                }
            }
            else if (btn.BindingContext is Assignement)
            {
                Assignement a = (Assignement)btn.BindingContext;
                bool answer = await DisplayAlert("Question?", "vai gribāt dzēst?" + a.ToString(), "yes", "no");
                if (answer)
                {
                    dataStore.Assignements.Remove(a);
                    cVList.ItemsSource = null;
                    cVList.ItemsSource = itemsList;
                }
                else
                {
                    return;
                }
            }
        }
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        var itemsList = (dataStore.Tickets?.Cast<object>() ?? Enumerable.Empty<object>()).Concat(dataStore.Assignements?.Cast<object>() ?? Enumerable.Empty<object>()).ToList();
        cVList.ItemsSource = null;
        cVList.ItemsSource = itemsList;
    }
}