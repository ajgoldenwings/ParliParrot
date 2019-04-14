using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Organization
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Identifier { get; set; }

        //public int Settings_MaxSecondWaitTime { get; set; }
        //public int Settings_MaxDiscussionTime { get; set; }
        //public int Settings_LackOfDiscussionThresholdTime { get; set; }
    }
}
