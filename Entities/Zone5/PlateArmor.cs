using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PlateArmor : IArmor
    {
        public PlateArmor()
        {
            name = "Plate armor";
            stat_type = "Health/Defense";
            stat_value = 5;
        }
    }
}
