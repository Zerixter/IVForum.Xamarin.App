﻿using IVForum.App.Models;
using IVForum.App.ViewModels.Public.Forums;

using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IVForum.App.Views.Public.Forums
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TopForumsPage : ContentPage
	{
		public List<Forum> Forums { get; set; } = IVForum.App.Resources.Content.GetForums();
		public List<PublicForumViewModel> ForumModels { get; set; } = new List<PublicForumViewModel>();

		public TopForumsPage()
		{
			InitializeComponent();

			foreach (Forum f in Forums)
			{
				ForumModels.Add(new PublicForumViewModel(f));
			}

			ForumsListView.ItemsSource = ForumModels;
			ForumsListView.ItemTapped += ForumsListView_ItemTapped;
		}

		private async void ForumsListView_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			await Navigation.PushAsync(new ForumDetailTabbedPage((PublicForumViewModel) e.Item), true);
		}
	}
}