using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wikipedia.Services.Models
{
    public class FloatNumberStatistic
    {
        public float MinimumNumber { get; set; }
        public float MaximumNumber { get; set; }
        public int Count { get; set; }
        public float Average { get; set; }
    }
}
