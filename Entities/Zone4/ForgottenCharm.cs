using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ForgottenCharm : ITrinkets
    {
        public ForgottenCharm()
        {
            name = "A forgotten charm";
            object_type = "Charm";
            stat_type = "Attack/Health";
            stat_value = 4;
        }
    }
}
