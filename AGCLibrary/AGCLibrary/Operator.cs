using System;
using System.Collections.Generic;
using System.Text;

namespace AGCLibrary
{
    public class Operator
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string ID { get; protected set; }

        public Operator()
        {
            ID = FirstName + LastName;
        }
    }
}
