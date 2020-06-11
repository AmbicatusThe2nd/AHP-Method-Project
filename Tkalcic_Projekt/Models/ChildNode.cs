using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkalcic_Projekt.Models
{
    public class ChildNode
    {
        public string Name { get; set; }
        public Dictionary<Alternative, double> UsefulValues = new Dictionary<Alternative, double>();
    }
}