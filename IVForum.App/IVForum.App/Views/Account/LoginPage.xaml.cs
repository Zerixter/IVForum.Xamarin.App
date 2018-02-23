﻿using IVForum.App.Services;
using IVForum.App.ViewModels;

using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IVForum.App.Views.Account
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		private LoginViewModel model;
		public LoginPage()
		{
			InitializeComponent();
			BindingContext = model = new LoginViewModel
			{
				Email = "Correu electrònic",
				Password = "Contrasenya"
			};
		}

		public LoginPage(SignUpViewModel viewModel)
		{
			InitializeComponent();
			BindingContext = model = new LoginViewModel
			{
				Email = viewModel.Email,
				Password = viewModel.Password
			};
		}

		async void Login(object sender, EventArgs e)
		{
			model = new LoginViewModel
			{
				Email = EntryEmail.Text,
				Password = EntryPassword.Text
			};

			bool result = await ApiService.Login(model);

			if (result)
			{
				Settings.Save("loggedin", true);
				Application.Current.MainPage = new Main.Main();
			}
		}
	}
}