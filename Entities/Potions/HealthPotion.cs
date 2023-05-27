using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class HealthPotion : IPotion
    {
        public HealthPotion()
        {
            name = "Health potion";
            stat_type = "Health";
            stat_value = 1;
        }
    }
}
