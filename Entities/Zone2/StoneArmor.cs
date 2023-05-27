using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class StoneArmor : IArmor
    {
        public StoneArmor()
        {
            stat_type = "Defense";
            name = "Stone armor";
            stat_value = 2;
        }
    }
}
