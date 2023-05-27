using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class StoneSwordWeapon : IWeapon
    {
        public StoneSwordWeapon()
        {
            name = "Stone sword";
            stat_value = 3;
        }
    }
}
