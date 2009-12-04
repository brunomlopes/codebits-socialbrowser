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
        public  Profile DataSource {
            get {
                return _DataSource;
            }
            set {
                _DataSource = value;

                LoadControlsFromDataSource();
            }
        }

        protected void LoadControlsFromDataSource() {

            lblName.Content = _DataSource.Name;
            lblBlog.Content = _DataSource.Blog;
            lblTwitter.Content = _DataSource.Twitter;

            lstSkill.Children.Clear();

            if (_DataSource.Skills != null) {

                foreach (Skill mySkill in _DataSource.Skills)
                {
                    Label mySkillLabel = new Label();
                    mySkillLabel.Content = mySkill.Name;

                    lstSkill.Children.Add(mySkillLabel);
                }
            }

            if (_DataSource.Project != null) {
                lblProjectTitle.Content = _DataSource.Project.ProjectName;
                lblProjectDescription.Content = _DataSource.Project.Description;
            }

            if (!string.IsNullOrEmpty(_DataSource.Twitter))
            {
                lblTwitter.Content = _DataSource.Twitter;


            }
            else {
                lblTwitter.Content = string.Empty;
            }
            
        }
    }
}
