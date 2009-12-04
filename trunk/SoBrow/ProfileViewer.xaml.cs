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
using DataEntities;

namespace SoBrow
{
    public partial class ProfileViewer : UserControl
    {
        public ProfileViewer()
        {
            InitializeComponent();
        }

        protected Profile _DataSource;
        public Profile DataSource {
            get {
                return _DataSource;
            }
            set {
                _DataSource = value;

                LoadControlsFromDataSource();
            }
        }

        protected void LoadControlsFromDataSource { 
        

        }
    }
}
