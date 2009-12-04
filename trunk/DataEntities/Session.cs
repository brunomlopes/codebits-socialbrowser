using System.Collections.Generic;

namespace DataEntities
{
    public class Session
    {
        protected int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        protected string _Title;
        public string Title { get { return _Title; } set { _Title = value; } }

        protected string _Abstract;
        public string Abstract { get { return _Abstract; } set { _Abstract = value; } }

        protected string _Language;
        public string Language { get { return _Language; } set { _Language = value; } }

        protected List<Profile> _Speakers;
        public List<Profile> Speakers { get { return _Speakers; } set { _Speakers = value; } }

        protected Stage _Where;
        public Stage Where { get { return _Where; } set { _Where = value; } }

        protected string _When;
        public string When { get { return _When; } set { _When = value; } }

        protected List<Profile> _Attendees;
        public List<Profile> Attendees { get { return _Attendees; } set { _Attendees = value; } }

    }


}
