﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authors.GraphQLApi.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AuthorIdentifier { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
