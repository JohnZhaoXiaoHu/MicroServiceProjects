using System;

namespace DataModel
{
    public class User
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Sex { get; set; }

        public DateTime BirthDay { get; set; }

        public DateTime Timestamp { get; set; }
        
        public string Host { get; set; }
    }
}
