using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SoBrow
{
    public partial class SocialListItem : UserControl
    {
        public SocialListItem()
        {
            InitializeComponent();
        }

        public string Title {
            get {
                return lblTitle.Content.ToString();
            }
            set {
                lblTitle.Content = value;
            }
        }

        public string Description {
            get
            {
                return lblCaption.Content.ToString();
            }
            set
            {
                lblCaption.Content = value;
            }
        }
    }
}
