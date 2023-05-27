using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Zone4Boss : IZoneBoss
    {
        public Zone4Boss()
        {
            name = "Veteran Mercenary";
            zone_name = "Road to the city";
            current_health_value = 22;
            max_health = current_health_value;
            attack_value = 5;
            defense = 2;
            is_alive = true;
        }
    }
}
