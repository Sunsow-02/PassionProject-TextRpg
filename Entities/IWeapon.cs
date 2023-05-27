using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    //Name: Interface weapon
    //Instatiates a interface for all weapons and sets attributes common to all weapons (give attack stat/is a weapon)
    public class IWeapon : IObject
    {
        protected IWeapon()
        {
            object_type = "Weapon";
            stat_type = "Attack";
        }
    }
}
