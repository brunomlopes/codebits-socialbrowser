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

namespace DataEntities
{
    public class Skill
    {

        protected string _Name;
        public string Name { get { return _Name; } set { _Name = value; } }

        protected string _KeyWord;
        public string KeyWord { get { return _KeyWord; } set { _KeyWord = value; } }

    }
}
