using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    //Name: Living object
    //implements default implementation for functions that all Living objects in this scope of the program must posess
    public abstract class LivingObject
    {
        protected int current_health_value;
        protected int max_health;

        public int GetCurrentHealth() 
        {
            return current_health_value;
        }

        public void SetCurrentHealth(int input)
        {
            current_health_value = input;
        }

        public int GetMaxHealth()
        {
            return max_health;
        }

        public void SetMaxHealth(int input)
        {
            max_health = input;
        }

        protected int attack_value;

        public int GetAttackValue()
        {
            return attack_value;
        }

        public void SetAttack(int input)
        {
            attack_value = input;
        }

        protected int defense;
        public int GetDefense()
        {
            return defense;
        }

        public void SetDefense(int input)
        {
            defense = input;
        }


        public bool is_alive = false;

        public abstract void Attack(LivingObject enemy);

        public void DisplayStats()
        {
            Console.WriteLine("Stats Panel:");
            Console.WriteLine("Attack: {0}", GetAttackValue());
            Console.WriteLine("Current Health: {0} Max Health: {1} Defense: {2}", GetCurrentHealth(), GetMaxHealth(),GetDefense());
        }

        public virtual IObject ItemDrop() { return null; }

        public virtual IObject PotionDrop() { return null; }
    }
}
