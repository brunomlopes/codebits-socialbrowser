using System.Collections.Generic;

namespace DataEntities
{
    public class Profile
    {
        protected int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        protected string _Name;
        public string Name { get { return _Name; } set { _Name = value; } }

        protected string _PhotoUrl;
        public string PhotoUrl { get { return _PhotoUrl; } set { _PhotoUrl = value; } }

        protected string _Blog;
        public string Blog { get { return _Blog; } set { _Blog = value; } }

        protected string _Twitter;
        public string Twitter { get { return _Twitter; } set { _Twitter = value; } }

        protected IEnumerable<Skill> _Skills;
        public IEnumerable<Skill> Skills
        {
            get {
                if (_Skills == null) {
                    _Skills = new List<Skill>();
                }

                return _Skills;
            }
            set {
                _Skills = value;
            }
        
        }

        protected IEnumerable<Profile> _Friends;

        public IEnumerable<Profile> Friends
        {
            get
            {
                if (_Friends == null)
                {
                    _Friends = new List<Profile>();
                }

                return _Friends;
            }
            set
            {
                _Friends = value;
            }

        }

        private Project _Project;
        public Project Project
        {
            get {
                return _Project;
            }
            set {
                _Project = value;
            }
        }
    }
}
