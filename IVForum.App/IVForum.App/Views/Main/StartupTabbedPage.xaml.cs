﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IVForum.App.Views.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartupTabbedPage : TabbedPage
    {
        public StartupTabbedPage ()
        {
            InitializeComponent();
        }
    }
}