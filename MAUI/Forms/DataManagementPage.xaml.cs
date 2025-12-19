namespace MAUI.Forms;
using User;

public partial class DataManagementPage : ContentPage
{
    private IDataManager dm;
    public DataManagementPage()
	{
		InitializeComponent();
        string path = @"..\..\data.txt";
        dm = new User.FigureXMLDataManager(path);   // Izveido IDataManager interfeisa objektu, izmantojot FigureXMLDataManager klasi
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
        dm.Save();      // Izsauc Save metodi, lai saglabātu datus
    }

    private void btnLoad_Clicked(object sender, EventArgs e)
    {
        dm.Load();      // Izsauc Load metodi, lai ielādētu datus
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