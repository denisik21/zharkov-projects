using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace queue_management_core.Entities
{
    public class Client : IEntity
    {
        public Id Id { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public string PassportId { get; set; }
        public DateTime Birthday { get; set; }
        public string Snils { get; set; }
        public Gender Gender { get; set; }
        public bool InRoom { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }


    }
}
