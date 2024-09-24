using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyMusicians.Entities.Concrete
{
    public class Musician
    {
        public Musician(int id, string name, string profession, string trait)
        {
            Id = id;
            Name = name;
            Profession = profession;
            Trait = trait;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Profession { get; set; }
        public string Trait { get; set; }
    }
}
