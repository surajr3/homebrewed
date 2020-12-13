using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBrewed.Models
{
    public class Beer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Beer(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
