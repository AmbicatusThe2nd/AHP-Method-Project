using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Tkalcic_Projekt.Models;

namespace Tkalcic_Projekt.Data
{
    public static class Datacontext
    {
        public static BindingList<Alternative> Alternitives = new BindingList<Alternative>();
        public static List<System.Windows.Forms.TreeNodeCollection> TreeNodes = new List<System.Windows.Forms.TreeNodeCollection>();
        public static List<ParentNode> parents = new List<ParentNode>();
        public static List<ChildNode> children = new List<ChildNode>();
        public static Dictionary<ParentNode, int> Depths = new Dictionary<ParentNode, int>();
        
        /*
        static Datacontext()
        {
            Alternitives.Add(new Alternative
            {
                Name = "Les paul"
            });

            Alternitives.Add(new Alternative
            {
                Name = "Startocaster"
            });

            Alternitives.Add(new Alternative
            {
                Name = "Telecaster"
            });
        }
        */
    }
}
