using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class BanditsCharm : ITrinkets
    {
        public BanditsCharm()
        {
            name = "Bandit's charm";
            object_type = "Charm";
            stat_type = "Attack";
            stat_value = 3;
        }
    }
}
