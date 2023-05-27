using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class CopperSwordWeapon : IWeapon
    {
        public CopperSwordWeapon()
        {
            name = "Copper sword";
            stat_value = 5;
        }
    }
}
