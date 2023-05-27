using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    //Name: Interface object
    //Declare a interface the implements default behavior for all objects/equipment. Allows client to treat all objects/equipment uniformly as they all inherit from this
    public class IObject
    {
        protected string name = " ";
        protected string object_type = " ";
        protected string stat_type = " ";
        protected int stat_value = 0;
        protected int enhance_count = 0;
        protected int enhance_stat_count = 0;

        public virtual int GetObjectStatValue() 
        { 
            return stat_value; 
        }

        public virtual string GetName()
        {
            return name;
        }

        public virtual string GetObjectType()
        {
            return object_type;
        }

        public virtual string GetStatType()
        {
            return stat_type;
        }

        public void Enhance()
        {
            stat_value++;
            enhance_count++;
            enhance_stat_count++;
        }

        public virtual void DisplayObjectStats()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Name : {0} Type: {1}",name,object_type);
            if (enhance_stat_count > 0)
            {
                Console.WriteLine("+{0}, giving {1} {2}", enhance_count, enhance_stat_count, stat_type);
            }
            Console.WriteLine("Total Stats given: {0} {1}",stat_value, stat_type);
            Console.WriteLine("Base stat: {0} {1}",stat_value - enhance_stat_count,stat_type);
            Console.WriteLine("--------------------------------");
        }
    }
}
