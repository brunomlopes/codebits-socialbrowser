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
        private double currentPosition;

        public MainPage()
        {
            InitializeComponent();
            LoadProfile();
            currentPosition = 0;
        }

        public void LoadProfile()
        {
            var _client = new CodebitsClient();
            _client.GetUserProfileCompleted += client_GetUserProfileCompleted;
            _client.GetUserProfileAsync("brunomlopes", _client);
        }

        void client_GetUserProfileCompleted(object sender, CodebitsService.GetUserProfileCompletedEventArgs e)
        {
            var profileViewer = new ProfileViewer();
            profileViewer.DataSource = e.Result;
            LayoutProfile(profileViewer);
            currentPosition += profileViewer.Height;

            var codebitsClient = (e.UserState as CodebitsClient);
            codebitsClient.CloseCompleted += (sndr, e1) =>
                                                 {
                                                     var client = new CodebitsClient();
                                                     client.GetUsersProfileCompleted +=
                                                         client_GetUserProfileFriendsCompleted;
                                                     client.GetUsersProfileAsync(e.Result.FriendUids, client);
                                                 };
            codebitsClient.CloseAsync();
        }

        private void client_GetUserProfileFriendsCompleted(object sender, GetUsersProfileCompletedEventArgs e)
        {
            var i = 0.0;
            var panel = new StackPanel()
                            {
                                FlowDirection = FlowDirection.LeftToRight,
                                Orientation = Orientation.Horizontal
                            };
            var viewers = e.Result.Select(profileView => new ProfileViewer() {DataSource = profileView});
            foreach (var profileView in viewers)
            {
                panel.Children.Add(profileView);
            }
            LayoutProfile(panel, currentPosition, 300, 0.5);
            (e.UserState as CodebitsClient).CloseAsync();
        }

        private void LayoutProfile(UIElement profileViewer, double x = 0, double y = 0, double scale = 1)
        {
            var transforms = new TransformGroup();
            transforms.Children.Add(new ScaleTransform() { ScaleX = scale, ScaleY = scale });
            transforms.Children.Add(new TranslateTransform(){X = x, Y = y});
            profileViewer.RenderTransform = transforms;
            LayoutRoot.Children.Add(profileViewer);
        }
    }
}
