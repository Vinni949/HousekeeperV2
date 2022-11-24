using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousekeeperV2.Models
{
    internal class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Key>? key { get; set; }
    }
}
