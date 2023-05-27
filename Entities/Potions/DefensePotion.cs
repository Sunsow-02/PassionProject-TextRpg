using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DefensePotion : IPotion
    {
        public DefensePotion()
        {
            name = "Defense potion";
            stat_type = "Defense";
            stat_value = 1;
        }
    }
}
