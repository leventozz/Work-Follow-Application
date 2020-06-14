using OZProje.ToDo.Entities.Interfaces;
using System.Collections.Generic;

namespace OZProje.ToDo.Entities.Concrete
{
    public class User :ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public List<Work> Works { get; set; }
    }
}
