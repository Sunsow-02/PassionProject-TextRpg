using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Zone5Enemy : LivingObject
    {
        //25% chance of dropping a equipment
        //33% chance of getting a specific equipment 
        //25% chance of getting defense potion

        public override void Attack(LivingObject enemy) { }

        public Zone5Enemy()
        {
            var rand = new Random();
            current_health_value = 16;
            max_health = 16;
            attack_value = 5;
            defense = 2;
            is_alive = true;
        }

        public override IObject ItemDrop()
        {
            var rand = new Random();
            int equipment_drop_number = rand.Next(1, 4);
            int equip_random_number = rand.Next(1, 5);
            if (equip_random_number == 1)
            {
                Console.WriteLine("An Item has dropped!");
                if (equipment_drop_number == 1)
                {
                    return new ForgottenAxeWeapon();
                }
                else if (equipment_drop_number == 2)
                {
                    return new PlateArmor();
                }
                else if (equipment_drop_number == 3)
                {
                    return new UndeadNecklace();
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
            int equip_random_number = rand.Next(1, 5); 
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
