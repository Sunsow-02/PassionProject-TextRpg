using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class LeatherArmor : IArmor
    {
        public LeatherArmor()
        {
            stat_type = "Health";
            name = "Leather armor";
            stat_value = 3;
        }
    }
}
