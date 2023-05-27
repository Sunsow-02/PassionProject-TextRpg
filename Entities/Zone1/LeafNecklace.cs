using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class LeafNecklace : ITrinkets
    {
        public LeafNecklace()
        {
            object_type = "Necklace";
            stat_type = "Health";
            name = "Leaf necklace";
            stat_value = 4;
        }
    }
}
