using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Zone3Boss : IZoneBoss
    {
        public Zone3Boss()
        {
            name = "Bandit Leader";
            zone_name = "Dirt road out of forest";
            current_health_value = 18;
            max_health = current_health_value;
            attack_value = 4;
            defense = 1;
            is_alive = true;
        }
    }
}
