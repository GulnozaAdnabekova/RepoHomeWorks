using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.DataAccess.Entities
{
    public class Car
    {
        public long CarId { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public float SpeedCar { get; set; }
        public string MadeOfDate { get; set; }
        public long Price { get; set; }
        public string Description { get; set; }

        public long PersonId { get; set; }
        public Person Person { get; set; }
    }
}
