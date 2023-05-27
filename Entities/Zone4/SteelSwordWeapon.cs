using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SteelSwordWeapon : IWeapon
    {
        public SteelSwordWeapon()
        {
            name = "Steel sword";
            stat_value = 7;
        }
    }
}
