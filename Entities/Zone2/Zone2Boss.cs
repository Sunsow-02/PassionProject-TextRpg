using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Zone2Boss : IZoneBoss
    {
        public Zone2Boss()
        {
            name = "Grand Knight of Nature";
            zone_name = "High Forest";
            current_health_value = 15;
            max_health = current_health_value;
            attack_value = 3;
            defense = 1;
            is_alive = true;
        }
    }
}
