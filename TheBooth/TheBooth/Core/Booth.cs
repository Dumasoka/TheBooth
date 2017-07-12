using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBooth.Core
{
    public class Booth
    {
        public Guid EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string Location { get; set; }
        public string DueDate { get; set; }
    }
}
