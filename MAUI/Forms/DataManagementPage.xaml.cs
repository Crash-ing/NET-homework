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
        dm = new User.FigureXMLDataManager(path);   // Izveido IDataManager interfeisa objektu, izmantojot FigureXMLDataManager klasi

        // Ensure the XML manager uses the shared in-memory DataStore used by MAUI pages.
        // IDataManager does not expose Store, so cast to concrete type before assigning.
        if (dm is User.FigureXMLDataManager xmlDm)
        {
            xmlDm.Store = AppData.Instance;
        }
    }

    private void btnTestData_Clicked(object sender, EventArgs e)
    {
        dm.createTestData();        // Izsauc createTestData metodi, lai izveidotu testa datus
        lblData.Text = dm.Print();
    }

    private void btnReset_Clicked(object sender, EventArgs e)
    {
        dm.reset();     // Izsauc reset metodi, lai notīrītu datus
        lblData.Text = dm.Print();
    }

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        dm.Save(path);      // Izsauc Save metodi, lai saglabātu datus
    }

    private void btnLoad_Clicked(object sender, EventArgs e)
    {
        dm.Load(path);      // Pass path to Load method
        lblData.Text = dm.Print();
    }

    private void btnPrint_Clicked(object sender, EventArgs e)
    {
        lblData.Text = dm.Print();  // Izsauc Print metodi, lai parādītu datus
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        lblData.Text = dm.Print();  // Parāda datus, kad lapa tiek ielādēta
    }
}