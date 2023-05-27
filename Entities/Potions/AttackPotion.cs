using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AttackPotion : IPotion
    {
        public AttackPotion()
        {
            name = "Attack potion";
            stat_type = "Attack";
            stat_value = 1;
        }
    }
}
