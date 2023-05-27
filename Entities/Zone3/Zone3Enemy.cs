using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Zone3Enemy : LivingObject
    {
        //25% of dropping a equipment
        //25% of getting a specific equipment
        //33% chance of getting a Attack potion
        public override void Attack(LivingObject enemy) { }

        public Zone3Enemy()
        {
            var rand = new Random();
            current_health_value = 8;
            max_health = 8;
            attack_value = 3;
            defense = 1;
            is_alive = true;
        }

        public override IObject ItemDrop()
        {
            var rand = new Random();
            int equipment_drop_number = rand.Next(1, 5);
            int equip_random_number = rand.Next(1, 5);
            if (equip_random_number == 1)
            {
                Console.WriteLine("An Item has dropped!");
                if (equipment_drop_number == 1)
                {
                    return new BanditsArmor();
                }
                else if (equipment_drop_number == 2)
                {
                    return new BanditsCharm();
                }
                else if (equipment_drop_number == 3)
                {
                    return new CopperSwordWeapon();
                }
                else if (equipment_drop_number == 4)
                {
                    return new OddNecklace();
                }
                else
                {
                    return null;
                }
            }

            return null;
        }

        public override IObject PotionDrop()
        {
            var rand = new Random();
            int equip_random_number = rand.Next(1, 4); //set this to a constant to make sure drops work
            if (equip_random_number == 1)
            {
                Console.WriteLine("A potion has dropped!");
                return new AttackPotion();
            }
            else
            {
                return null;
            }
        }
    }
}
