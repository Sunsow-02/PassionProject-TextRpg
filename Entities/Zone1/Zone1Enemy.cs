using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Zone1Enemy : LivingObject
    {
        //50% chance of dropping a equipment
        //20% chance of getting a specific equipment
        //33% chance of getting a health potion
        public override void Attack(LivingObject enemy) { }

        public Zone1Enemy()
        {
            var rand = new Random();
            current_health_value = rand.Next(3, 4);
            max_health = rand.Next(3, 4);
            attack_value = rand.Next(1,2);
            defense = 0;
            is_alive = true;
        }

        public override IObject ItemDrop()
        {
            var rand = new Random();
            int equipment_drop_number = rand.Next(1,6);
            int equip_random_number = rand.Next(1,3);
            if (equip_random_number == 2)
            {
                //equipment_drop_number = 4;
                Console.WriteLine("An Item has dropped!");
                if (equipment_drop_number == 1 || equipment_drop_number == 2)
                {
                    return new WoodenSwordWeapon();
                }
                else if (equipment_drop_number == 3)
                {
                    return new LeatherArmor();
                }
                else if (equipment_drop_number == 4)
                {
                    return new RockNecklace();
                }
                else if (equipment_drop_number == 5)
                {
                    return new LeafNecklace();
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public override IObject PotionDrop()
        {
            var rand = new Random();
            int equip_random_number = rand.Next(1, 4);
            if (equip_random_number == 1)
            {
                Console.WriteLine("A potion has dropped!");
                return new HealthPotion();
            }
            else
            {
                return null;
            }
        }

    }
}
