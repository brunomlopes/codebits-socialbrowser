using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SoBrow.CodebitsService;

namespace SoBrow
{
    public partial class MainPage : UserControl
    {
        private CodebitsClient _client;

        public MainPage()
        {
            InitializeComponent();
            LoadProfile();
        }

        public void LoadProfile()
        {
            _client = new CodebitsClient();
            _client.GetUserProfileCompleted += client_GetUserProfileCompleted;
            _client.GetUserProfileAsync("brunomlopes", _client);
        }

        void client_GetUserProfileCompleted(object sender, CodebitsService.GetUserProfileCompletedEventArgs e)
        {
            var profileViewer = new ProfileViewer();
            profileViewer.DataSource = e.Result;
            LayoutRoot.Children.Add(profileViewer);
            (e.UserState as CodebitsClient).CloseAsync();
        }
    }
}
