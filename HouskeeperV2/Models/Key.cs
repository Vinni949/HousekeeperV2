using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousekeeperV2.Models
{
    internal class Key
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Teacher? teacher { get; set; }
    }
}
