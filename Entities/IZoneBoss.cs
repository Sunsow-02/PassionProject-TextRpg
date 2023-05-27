using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    //Name: Interface zone boss
    //Implements a interface for Zone Bosses that zone specifc bosses will inherit from. Overrides/implements operations declared in LivingObject
    public class IZoneBoss : LivingObject
    {
        protected string name = " ";
        protected string zone_name = " ";
        public override void Attack(LivingObject enemy) { }
        
        public void DisplayBossStats()
        {
            Console.WriteLine("You are currently in {0} zone.",zone_name);
            Console.WriteLine("You are fighting the boss {0}. Stats shown below.",name);
            Console.WriteLine("Health: {0} Attack: {1} Defense: {2}",GetCurrentHealth(),GetAttackValue(),GetDefense());
        }
    }
}
