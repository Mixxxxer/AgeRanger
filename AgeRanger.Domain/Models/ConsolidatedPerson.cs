﻿namespace AgeRanger.Domain.Models
{
    public class ConsolidatedPerson
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set;  }

        public string AgeRangeDescription { get; set; }
    }
}
