using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class DataModel
    {
        public int Id { get; set; }
        public string IP { get; set; }
        public float CPU { get; set; }
        public float Memory { get; set; }
        public float Disk { get; set; }

    }
}
