using OZProje.ToDo.Entities.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OZProje.ToDo.Entities.Concrete
{
    public class Work :ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public bool IsComplete { get; set; }
    }
}
