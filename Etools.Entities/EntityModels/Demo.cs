using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etools.Entities.EntityModels
{
    public class Demo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastUpdated { get; set; }
        public int UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
