using System.Windows.Controls;
using SoBrow.CodebitsService;

namespace SoBrow
{
    public partial class ProfileViewer : UserControl
    {
        public ProfileViewer()
        {
            InitializeComponent();
        }

        protected ProfileView _DataSource;
        public ProfileView DataSource
        {
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

                foreach (string mySkill in _DataSource.Skills)
                {
                    Label mySkillLabel = new Label();
                    mySkillLabel.Content = mySkill;

                    lstSkill.Children.Add(mySkillLabel);
                }
            }

            lblProjectTitle.Content = _DataSource.ProjectName ?? "";
            lblProjectDescription.Content = _DataSource.ProjectDescription ?? "";

            lblTwitter.Content = _DataSource.Twitter ?? "";
        }
    }
}
