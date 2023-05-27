using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UndeadNecklace : ITrinkets
    {
        public UndeadNecklace()
        {
            object_type = "Necklace";
            name = "Undead necklace";
            stat_type = "Health";
            stat_value = 15;
        }
    }
}
