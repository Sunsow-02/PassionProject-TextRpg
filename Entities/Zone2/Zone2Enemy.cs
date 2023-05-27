using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Zone2Enemy : LivingObject
    {
        //33% of dropping a equipment
        //20% chance of getting specific equipment
        //33% of getting a Attack Potion
        public override void Attack(LivingObject enemy) { }

        public Zone2Enemy()
        {
            var rand = new Random();
            current_health_value = rand.Next(4, 5);
            max_health = rand.Next(5, 7);
            attack_value = 2;
            defense = rand.Next(0,1);
            is_alive = true;
        }

        public override IObject ItemDrop()
        {
            var rand = new Random();
            int equipment_drop_number = rand.Next(1,6); 
            int equip_random_number = rand.Next(1,4); 
            if (equip_random_number == 3)
            {
                Console.WriteLine("An Item has dropped!");
                if (equipment_drop_number == 1 || equipment_drop_number == 2)
                {
                    return new StoneSwordWeapon();
                }
                else if (equipment_drop_number == 3)
                {
                    return new WoodenArmor();
                }
                else if (equipment_drop_number == 4)
                {
                    return new StoneAxeWeapon();
                }
                else if (equipment_drop_number == 5)
                {
                    return new PebbleTrinket();
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
                return new AttackPotion();
            }
            else
            {
                return null;
            }
        }

    }
}
