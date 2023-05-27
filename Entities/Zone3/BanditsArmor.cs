using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class BanditsArmor : IArmor
    {
        public BanditsArmor()
        {
            name = "Bandit's armor";
            stat_type = "Health/Defense";
            stat_value = 3;
        }
    }
}
