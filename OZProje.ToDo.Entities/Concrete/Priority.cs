using OZProje.ToDo.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.Entities.Concrete
{
    public class Priority : ITable
    {
        public int Id { get; set; }
        public string Definition { get; set; }

        public List<Task>Tasks { get; set; }
    }
}
