using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class OddNecklace : ITrinkets
    {
        public OddNecklace()
        {
            name = "Odd Necklace";
            object_type = "Necklace";
            stat_type = "Health";
            stat_value = 10;
        }
    }
}
