using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Zone4Enemy : LivingObject
    {
        //25% chance of getting a equipment
        //25% chance of getting a specific equipment 
        //20% chance of getting a defense potion
        public override void Attack(LivingObject enemy) { }

        public Zone4Enemy()
        {
            var rand = new Random();
            current_health_value = 12;
            max_health = 12;
            attack_value = 4;
            defense = rand.Next(1,2);
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
                    return new SteelSwordWeapon();
                }
                else if (equipment_drop_number == 2)
                {
                    return new ForgottenCharm();
                }
                else if (equipment_drop_number == 3)
                {
                    return new MercenaryArmor();
                }
                else if (equipment_drop_number == 4)
                {
                    return new ForgottenAxeWeapon();
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
            int equip_random_number = rand.Next(1, 6); //set this to a constant to make sure drops work
            if (equip_random_number == 1)
            {
                Console.WriteLine("A potion has dropped!");
                return new DefensePotion();
            }
            else
            {
                return null;
            }
        }
    }
}
