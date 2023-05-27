using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class IArmor : IObject
    {
        //Name: Interface object
        //Defines type of object for all Armor children (armor) 
        protected IArmor()
        {
            object_type = "Armor";
        }
    }
}
