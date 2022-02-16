using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWeb.Models
{
    public class Specialist
    {
        public int ID { get; set; }
        public string SpecialistNume { get; set; }
        public ICollection<Programare> Programari { get; set; }
    }
}
