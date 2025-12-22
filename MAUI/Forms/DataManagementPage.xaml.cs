namespace MAUI.Forms;
using User;
using MAUI.Forms.AddItemsForms; // make AppData visible

public partial class DataManagementPage : ContentPage
{
    private IDataManager dm;
    private readonly string path = @"..\..\data.txt"; // Move path to a field

    public DataManagementPage()
	{
		InitializeComponent();
        dm = AppData.Instance; // Inicilizē datu pārvaldnieku no AppData
    }

    private void btnTestData_Clicked(object sender, EventArgs e)
    {
        dm.createTestData();        // Izsauc createTestData metodi, lai izveidotu testa datus
        lblData.Text = dm.Print();
    }

    private void btnReset_Clicked(object sender, EventArgs e)
    {
        // Commented out the reset functionality per request:
        dm.reset();


        // Clear only the screen:
        lblData.Text = string.Empty;
    }

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        // Save to DB (path is unused in DBDataManager, but we pass null to respect signature)
        dm.Save(null);
    }

    private void btnLoad_Clicked(object sender, EventArgs e)
    {
        // Load saved data from DB
        dm.Load(null);

        // Show loaded data
        lblData.Text = dm.Print();
    }

    private void btnPrint_Clicked(object sender, EventArgs e)
    {
        lblData.Text = dm.Print();  // Izsauc Print metodi, lai parādītu datus
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        // Show current data when page loads/navigates to
        lblData.Text = dm.Print();
    }

    // If you have any other wired load handler, keep it consistent:
    private async void OnLoadClicked(object sender, EventArgs e)
    {
        dm.Load(null);
        lblData.Text = dm.Print();
        // MessagingCenter.Send(this, "DataReloaded"); // if you use it elsewhere
    }
}