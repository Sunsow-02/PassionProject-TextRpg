using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MercenaryArmor : IArmor
    {
        public MercenaryArmor()
        {
            name = "Mercenary armor";
            stat_type = "Defense";
            stat_value = 4;
        }
    }
}
