using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class WoodenArmor : IArmor
    {
        public WoodenArmor()
        {
            stat_type = "Health";
            name = "Wooden armor";
            stat_value = 5;
        }
    }
}
