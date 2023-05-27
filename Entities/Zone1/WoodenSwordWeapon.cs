using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class WoodenSwordWeapon : IWeapon
    {
        public WoodenSwordWeapon()
        {
            name = "Wooden sword";
            stat_value = 2;
        }
    }
}
