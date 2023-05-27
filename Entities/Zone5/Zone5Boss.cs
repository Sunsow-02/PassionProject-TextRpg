using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Zone5Boss : IZoneBoss
    {
        public Zone5Boss()
        {
            name = "Undead city guard";
            zone_name = "Abandoned city";
            current_health_value = 30;
            max_health = current_health_value;
            attack_value = 7;
            defense = 3;
            is_alive = true;
        }
    }
}
