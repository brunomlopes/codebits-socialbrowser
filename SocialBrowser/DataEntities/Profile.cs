using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
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

        protected List<Skill> _Skills;
        public List<Skill> Skills {
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

        protected List<Profile> _Friends;
        public List<Profile> Friends
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
    }

    
}
