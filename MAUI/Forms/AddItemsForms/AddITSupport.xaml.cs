namespace MAUI.Forms.AddItemsForms;
using System;
using System.Linq;
using Users;
using User;
using System.Threading.Tasks;

public partial class AddITSupport : ContentPage
{
	private ObjectAddManager obj;
	private ITSupport _its = null;
    public AddITSupport()
	{
		InitializeComponent();
		obj = AppData.Instance.oam;
        cboEmployee.ItemsSource = obj.uc.Employees.ToList();
        cboSpecialization.ItemsSource = Enum.GetValues(typeof(SpecializationType));

        cboEmployee.ItemDisplayBinding = new Binding("UserName");
    }

    public AddITSupport(ITSupport its) : this()
    {
        _its = its;
        cboEmployee.SelectedItem = its.EmployeeRef;
        cboSpecialization.SelectedItem = its.Specialization;
        btnAddITSupport.Text = "Update IT Support";
    }

    private async void BtnAddITSupport_Clicked(object sender, EventArgs e)
    {
        var selectedEmployee = cboEmployee.SelectedItem as Employee;
        var selectedSpecializationObj = cboSpecialization.SelectedItem;
        var selectedSpecialization = (SpecializationType)selectedSpecializationObj;

        if (_its == null)
        {
            var newITSupport = new ITSupport(selectedEmployee, selectedSpecialization);

            // Persist using the manager so EF tracks and saves changes
            obj.Add(newITSupport);
            obj.Save();

            await DisplayAlert("Success", "IT Support added successfully.", "OK");
        }
        else
        {
            _its.EmployeeRef = selectedEmployee;
            _its.UserName = selectedEmployee.UserName;
            _its.Email = selectedEmployee.Email;
            _its.UserID = selectedEmployee.UserID;
            _its.IsActive = selectedEmployee.IsActive;
            _its.Specialization = selectedSpecialization;
            await DisplayAlert("Success", "IT Support updated successfully.", "OK");
        }
        obj.Save();
        await Navigation.PopAsync();
    }

    public void AddNewITSupport(Employee employee, SpecializationType specialization)
    {
        var newITSupport = new ITSupport(employee, specialization);
        obj.Add(newITSupport);
        obj.Save();
    }
}