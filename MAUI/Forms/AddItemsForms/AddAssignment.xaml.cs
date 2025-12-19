namespace MAUI.Forms.AddItemsForms;

using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using Users;
using User;

public static class AppData		// klase datu glabāšanai starp lapām
{
	public static DataStore Instance { get; set; } = new DataStore();
}

public partial class AddAssignment : ContentPage
{
	private DataStore dataStore;

	private Assignement _ag = null; // ja ir null, tad jauns ieraksts, ja nav - labojam esošo

    public AddAssignment()
	{
		InitializeComponent();

		dataStore = AppData.Instance;	// datu glabātājs

        cboITSupport.ItemsSource = dataStore.ITSupports;    // izvēlas pickeru datu avotus
        cboTicket.ItemsSource = dataStore.Tickets;

        cboTicket.ItemDisplayBinding = new Binding("Title");		// pickerī parāda tikai Title, nevis visu info
		cboITSupport.ItemDisplayBinding = new Binding("UserName");	// parāda tikai vārdu
    }
	
	public AddAssignment(Assignement ag) : this()   // izsauc noklusēto konstruktora versiju pirms izpildes
    {
		_ag = ag;

		if (ag == null) // ja nav padots ieraksts, tad iziet
            return;

        // aizpilda laukus ar esošā ieraksta datiem
        cboITSupport.SelectedItem = ag.Support;
		cboTicket.SelectedItem = ag.Ticket;
		txtComment.Text = ag.Comment ?? string.Empty;
		btnAdd.Text = "Update Assignment";
	}

	private async void BtnAddAssignment_Clicked(object sender, EventArgs e)
	{
        // paņem izvēlētos objektus no pickeriem
        var selectedSupport = cboITSupport.SelectedItem as ITSupport;
		var selectedTicket = cboTicket.SelectedItem as Ticket;
		var comment = txtComment.Text?.Trim() ?? string.Empty;

		if (_ag == null)    // jauns ieraksts
        {
			var newAssignment = new Assignement
			{
				AssignedAt = DateTime.Now,
				Support = selectedSupport,
				Ticket = selectedTicket,
				Comment = comment
			};

			dataStore.Assignements.Add(newAssignment);  // pievieno sarakstam
            await DisplayAlert("Success", "Assignment added.", "OK");
		}
        else    // labo esošo ierakstu
        {
			_ag.AssignedAt = DateTime.Now;
			_ag.Support = selectedSupport;
			_ag.Ticket = selectedTicket;
			_ag.Comment = comment;

			await DisplayAlert("Success", "Assignment updated.", "OK");
		}
		await Navigation.PopAsync();
	}
}