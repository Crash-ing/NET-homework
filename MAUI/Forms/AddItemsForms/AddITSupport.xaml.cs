namespace MAUI.Forms.AddItemsForms;
using System;
using System.Linq;
using Users;
using User;
using System.Threading.Tasks;

public partial class AddITSupport : ContentPage
{
	private DataStore dataStore;
	private ITSupport _its = null;
    public AddITSupport()
	{
		InitializeComponent();
		dataStore = AppData.Instance;
        cboEmployee.ItemsSource = dataStore.Employees;
        cboSpecialization.ItemsSource = Enum.GetValues(typeof(SpecializationType));

        cboEmployee.ItemDisplayBinding = new Binding("UserName");
    }

    private async void BtnAddITSupport_Clicked(object sender, EventArgs e)
    {
        var selectedEmployee = cboEmployee.SelectedItem as Employee;
        var selectedSpecialization = (SpecializationType)cboSpecialization.SelectedItem;

        if (_its == null)
        {
            var newITSupport = new ITSupport(selectedEmployee, selectedSpecialization);
            dataStore.ITSupports.Add(newITSupport);
            await DisplayAlert("Success", "IT Support added successfully.", "OK");
        }
        await Navigation.PopAsync();
    }
}