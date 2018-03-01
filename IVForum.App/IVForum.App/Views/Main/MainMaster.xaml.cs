﻿using IVForum.App.Services;
using IVForum.App.ViewModels;
using IVForum.App.Views.Config;
using IVForum.App.Views.Info;
using IVForum.App.Views.Personal;
using IVForum.App.Views.Public.Forums;
using IVForum.App.Views.Public.Projects;

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IVForum.App.Views.Main
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMaster : ContentPage
    {
        public ListView ListView;
		public string Username;
		public string Email;
		public string Avatar;

        public MainMaster()
        {
            InitializeComponent();

            BindingContext = new MainMasterViewModel();
            ListView = MenuItemsListView;
        }

		public void Logout(object sender, EventArgs e)
		{
			Settings.Remove("loggedin");
			Settings.Remove("token");
			Application.Current.MainPage = new StartupTabbedPage();
		}

		class MainMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainMenuItem> MenuItems { get; set; }
            public MainMasterUserViewModel User { get; set; }

            public MainMasterViewModel()
            {
                MenuItems = new ObservableCollection<MainMenuItem>(new[]
                {
                    new MainMenuItem { Id = 0, Title = "Perfil", TargetType = typeof(MyProfilePage), Icon = "profile.png" },
					new MainMenuItem { Id = 1, Title = "Fòrums", TargetType = typeof(MyForumsTabbedPage), Icon = "personal_forums.png" },
					new MainMenuItem { Id = 2, Title = "Projectes", TargetType = typeof(MyProjectsTabbedPage), Icon = "personal_projects.png" },
                    new MainMenuItem { Id = 3, Title = "Fòrums públics", TargetType = typeof(PublicForumsTabbedPage), Icon = "public_forums.png" },
                    new MainMenuItem { Id = 4, Title = "Projectes públics", TargetType = typeof(PublicProjectsTabbedPage), Icon = "public_projects.png" },
					new MainMenuItem { Id = 5, Title = "Sobre nosaltres", TargetType = typeof(About), Icon = "about.png" },
					new MainMenuItem { Id = 6, Title = "Configuració", TargetType = typeof(SettingsPage), Icon = "settings.png" },
                });

				User = new MainMasterUserViewModel(IVForum.App.Resources.Content.Cristian);
            }

			#region INotifyPropertyChanged Implementation
			public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}