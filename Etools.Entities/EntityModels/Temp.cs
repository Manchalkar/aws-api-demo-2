using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etools.Entities.EntityModels
{
    public class Temp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CourtTypeId { get; set; }
        public int? FederalCourtId { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string CourtOfAppealsCircuit { get; set; }
        public string Citation { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? LastUpdated { get; set; }
        public bool IsActive { get; set; }
        public bool IsVisible { get; set; }
    }
}
