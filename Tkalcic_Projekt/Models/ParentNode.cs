using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkalcic_Projekt.Models
{
    public class ParentNode
    {
        public string Name { get; set; }
        public Dictionary<string, double> WeightValues = new Dictionary<string, double>();
    }
}
