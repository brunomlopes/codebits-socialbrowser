using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntities
{
    public class Project
    {
        public string ProjectName { get; set; }
        public string Description { get; set; }

        public Project(string projectName, string description)
        {
            ProjectName = projectName;
            Description = description;
        }
    }
}
