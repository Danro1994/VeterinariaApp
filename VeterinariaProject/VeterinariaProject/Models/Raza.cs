using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeterinariaProject.Models
{
    public class Raza
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Mascota> Mascotas { get; set; }
    }
}
