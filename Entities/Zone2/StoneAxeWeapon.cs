using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class StoneAxeWeapon : IWeapon
    {
        public StoneAxeWeapon()
        {
            name = "Stone axe";
            stat_value = 4;
        }
    }
}
