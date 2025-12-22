namespace MAUI.Forms.AddItemsForms;
using Users;
using User;

public partial class AddTicket : ContentPage
{
	private ObjectAddManager obj;
	private Ticket _tick = null;
	public AddTicket()
	{
		InitializeComponent();
		obj = AppData.Instance.oam;
		cboEmployee.ItemsSource = obj.uc.Employees.ToList();
		cboTicketStat.ItemsSource = Enum.GetValues(typeof(TicketStatus));

		cboEmployee.ItemDisplayBinding = new Binding("UserName");
    }

	public AddTicket(Ticket tick) : this()
	{
		_tick = tick;
		txtTitle.Text = _tick.Title;
		txtDescription.Text = tick.Description;
		sdrPriority.Value = tick.Priority;
		// txtID.Text = tick.TicketId.ToString();
        cboEmployee.SelectedItem = tick.CreatedBy;
		cboTicketStat.SelectedItem = tick.Status;
		boxResolved.IsChecked = tick.IsResolved;
		btnAddTicket.Text = "Update Ticket";
    }

    private async void BtnAddTicket_Clicked(object sender, EventArgs e)
    {
		var title = txtTitle.Text?.Trim() ?? string.Empty;
		var description = txtDescription.Text?.Trim() ?? string.Empty;
		var priority = (int)sdrPriority.Value;
		// var ticketId = _tick?.TicketId ?? 0;
		var selectedEmployee = cboEmployee.SelectedItem as Employee;
		var selectedStatus = (TicketStatus)cboTicketStat.SelectedItem;
		var isResolved = boxResolved.IsChecked;

        // Auto-assign TicketId on create; keep existing on update
        int ticketId = _tick == null
            ? (obj.uc.Tickets.Any() ? obj.uc.Tickets.Max(t => t.TicketId) + 1 : 1)
            : _tick.TicketId;

        if (_tick == null)
        {
            var newTicket = new Ticket
			{
				Title = title,
				Description = description,
				Priority = priority,
				TicketId = ticketId,
				CreatedBy = selectedEmployee,
				Status = selectedStatus,
				IsResolved = isResolved
			};
			obj.uc.Add(newTicket);
			await DisplayAlert("Success", "Ticket added successfully.", "OK");
        }
		else
		{
			_tick.Title = title;
			_tick.Description = description;
			_tick.Priority = priority;
			_tick.TicketId = ticketId;
			_tick.CreatedBy = selectedEmployee;
			_tick.Status = selectedStatus;
			_tick.IsResolved = isResolved;
			await DisplayAlert("Success", "Ticket updated successfully.", "OK");
        }
		obj.Save();
		await Navigation.PopAsync();
    }
}