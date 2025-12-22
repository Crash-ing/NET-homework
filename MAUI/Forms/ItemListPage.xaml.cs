namespace MAUI.Forms;
using Users;
using User;
using MAUI.Forms.AddItemsForms;
using System.Linq;

public class ItemGroup : List<object>
{
    public string Name { get; private set; }
    public ItemGroup(string name, IEnumerable<object> items) : base(items)
    {
        Name = name;
    }
}

public partial class ItemListPage : ContentPage
{
    private ObjectAddManager obj;
    private IRemove rf;

    public ItemListPage()
	{
		InitializeComponent();
        obj = AppData.Instance.oam;
        rf = obj;
        cVList.ItemsSource = GetGroupedItems();
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
            cVList.ItemsSource = GetGroupedItems();
        }
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        // Ensure you use the updated manager
        obj = AppData.Instance.oam;
        rf = obj;

        cVList.ItemsSource = null;
        cVList.ItemsSource = GetGroupedItems();
    }

    private List<ItemGroup> GetGroupedItems()
    {
        var allItems = obj.objList;

        return new List<ItemGroup>
        {
            new ItemGroup("Assignments", allItems.OfType<Assignement>()),
            new ItemGroup("Tickets", allItems.OfType<Ticket>()),
            new ItemGroup("IT Support", allItems.OfType<ITSupport>())
        };
    }

    private void ContentPage_NavigatedTo_1(object sender, NavigatedToEventArgs e)
    {

    }
}