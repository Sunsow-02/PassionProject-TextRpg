using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RockNecklace : ITrinkets
    {
        public RockNecklace()
        {
            object_type = "Necklace";
            stat_type = "Defense";
            name = "Rock necklace";
            stat_value = 1;
        }

    }
}
