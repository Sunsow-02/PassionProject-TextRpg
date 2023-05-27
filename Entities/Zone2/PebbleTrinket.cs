using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PebbleTrinket : ITrinkets
    {
        public PebbleTrinket()
        {
            object_type = "Trinket";
            stat_type = "Attack/Health";
            name = "Pebble trinket";
            stat_value = 2;
        }
    }
}
