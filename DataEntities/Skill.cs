namespace DataEntities
{
    public class Skill
    {

        protected string _Name;
        public string Name { get { return _Name; } set { _Name = value; } }

        public Skill(string name)
        {
            Name = name;
        }
    }
}
