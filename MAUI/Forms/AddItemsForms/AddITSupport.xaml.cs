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

    public AddITSupport(ITSupport its) : this()
    {
        _its = its;
        cboEmployee.SelectedItem = its.UserName;
        cboSpecialization.SelectedItem = its.Specialization;
        btnAddITSupport.Text = "Update IT Support";
    }

    private async void BtnAddITSupport_Clicked(object sender, EventArgs e)
    {
        var selectedEmployee = cboEmployee.SelectedItem as Employee;
        var selectedSpecialization = (SpecializationType)cboSpecialization.SelectedIndex;

        if (_its == null)
        {
            var newITSupport = new ITSupport
            {
                UserName = selectedEmployee,
                Specialization = selectedSpecialization
            };

            dataStore.ITSupports.Add(newITSupport);
            await DisplayAlert("Success", "IT Support added successfully.", "OK");
        }
        else
        {
            _its.UserName = selectedEmployee;
            _its.Specialization = selectedSpecialization;
            await DisplayAlert("Success", "IT Support updated successfully.", "OK");
        }
        await Navigation.PopAsync();
    }
}