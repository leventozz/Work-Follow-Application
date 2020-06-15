
using OZProje.ToDo.Entities.Interfaces;

namespace OZProje.ToDo.Entities.Concrete
{
    public class Report : ITable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Task Task { get; set; }
        public int TaskId { get; set; }
    }
}
