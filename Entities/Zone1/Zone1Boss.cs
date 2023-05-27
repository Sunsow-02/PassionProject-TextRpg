using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Zone1Boss : IZoneBoss
    {
        public Zone1Boss()
        {
            name = "Knight of the Leaves";
            zone_name = "Ordinary Forest";
            current_health_value = 7;
            max_health = current_health_value;
            attack_value = 2;
            defense = 0;
            is_alive = true;
        }
    }
}
