using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entities
{
    //Name: Player
    //Purpose: Encapsulate and implement all functions needed as a player 
    //Inherits from LivingObject and implements functions in the interface as needed
    public class Player : LivingObject
    {
        static Player _instance; //using singleton pattern to ensure that only 1 player exists at a time

        List<IObject> inventory = new List<IObject>(); //list of objects to serve as an inventory
        List<IObject> equipped_items = new List<IObject>(); //list of objects to serve as equipped items

        protected int level; //int representing character level
        protected int current_xp; //int representing the amount of xp the player currently has
        protected int xp_for_next_level; //int presenting the amount of xp needed for the next player level
        private Player() //private ctor in line with singleton pattern
        {
            //Console.WriteLine("Player c'tor");
            current_health_value = 10;
            max_health = 10;
            //base_attack = 1;
            attack_value = 1;
            defense = 0;
            is_alive = true;
            level = 0;
            current_xp = 0;
            xp_for_next_level = 3;
        }

        public void DispalyPlayerStats() //Display stats related to player (not including inv/equipped items)
        {
            Console.WriteLine("Level : {0}", level);
            _instance.DisplayStats(); 
            Console.WriteLine("Current XP: {0}. XP for next level: {1}",current_xp,xp_for_next_level);
        }

        public static Player GetPlayerInstance() //public get_instance in line with singleton pattern
        {
            if (_instance == null)
            {
                _instance = new Player();
            }

            return _instance;
        }

        //Name: Xp maintainer
        //Documents xp gained and increments level, resetting xp needed for next level back to zero, and incrementing xp needed for next level
        public void XP(int xp)
        {
            current_xp += xp;
            if (current_xp == xp_for_next_level)
            {
                level += 1;
                LevelUp();
                current_xp = 0;
                xp_for_next_level += 5;
            }
        }

        //Name: Level up stat portion
        //If player levels up, increase health stats/attack by 2 and tells the user current level
        private void LevelUp()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("You have leveled up to level {0}!",level);
            Console.WriteLine("Leveling up awards 2 to current/max health and attack");
            current_health_value += 2;
            max_health += 2;
            attack_value += 2;
        }

        //Name: Inventory
        //Goes through inventory list and displays info for every item in the inventory
        public void DisplayInventory()
        {
            Console.WriteLine("Inventory: ");
            foreach (IObject item in inventory)
            {
                Console.WriteLine("Name: {0}. Gives {2} {1}",item.GetName(),item.GetStatType(),item.GetObjectStatValue());
            }
        }

        //Name: Potion consumer
        //Main gives a potion of type IObject. Thus function calls AddStats for every potion in inventory, and deleted all potions of the type provided before returning
        public void ConsumePotion(IObject item)
        {
            IObject remove = null;
            foreach(IObject inv_item in inventory)
            {
                if (inv_item.GetObjectType() == "Potion" && item.GetName() == inv_item.GetName())
                {
                    remove = inv_item;
                    AddStats(inv_item);
                    Console.WriteLine("{0} has been consumed", inv_item.GetName());
                }
            }

            inventory.RemoveAll(isn => isn.GetName() == remove.GetName());
        }

        //Name: Object getter
        //Given a name provided by client, if possible find a inventory item of the same name and return it
        public IObject GetItem(string name)
        {
            bool found_equipment = false;
            foreach(IObject list_item in inventory)
            {
                if (name == list_item.GetName())
                {
                    found_equipment = true;
                    return list_item;
                }
            }

            if (found_equipment == false)
            {
                Console.WriteLine("Item not found");
                return null;
            }
            else
            {
                Console.WriteLine("Item not found");
                return null;
            }
        }

        //Name: Item enhancement
        //Given a item, find at least one of that name in inventory, and one equipped. consume all ones in inventory to improve one equipped
        public void EnhanceItem(IObject item)
        {
            IObject remove = null;
            foreach(IObject eq_item in equipped_items)
            {
                if (eq_item.GetName() == item.GetName())
                {
                    foreach(IObject inv_item in inventory)
                    {
                        //check to make sure 2 identical equipment exist in both equipped/inventory
                        if (inv_item.GetName() == item.GetName())
                        {
                            remove = inv_item;
                            Console.WriteLine("Enhancement will be performed!");
                            RemoveStats(item);
                            eq_item.Enhance();
                            AddStats(item);
                        }
                    }
                }
            }
            inventory.Remove(remove);
        }

        //Name: Equip a item
        //Given a item, find it in inventory and make sure a equipment of the same type doesn't exist. If does, ask if want to replace and display the 2
        //If not, just equip the new item
        public int EquipItem(IObject item)
        {
            string change = " ";
            bool equipment_conflict = false;
            foreach (IObject list_item in equipped_items)
            {
                if (item.GetObjectType() == list_item.GetObjectType())
                {
                    equipment_conflict = true;
                    Console.WriteLine("Warning! There are equipment limits!");
                    Console.WriteLine("Would you like to swap the current item? Current item showm below: ");
                    list_item.DisplayObjectStats();
                    Console.WriteLine("New item stats shown below:");
                    item.DisplayObjectStats();
                    Console.WriteLine("Type yes to replace, type no to keep the current item.");
                    change = Console.ReadLine();
                    if (change == "yes")
                    {
                        Console.WriteLine("New equipment is now equiped!");
                        equipped_items.Remove(list_item);
                        RemoveStats(list_item);
                        inventory.Add(list_item);
                        equipped_items.Add(item);
                        AddStats(item);
                        inventory.Remove(item);
                        return 0;
                    }
                    else
                    {
                        Console.WriteLine("Equipment will not be changed");
                        return 0;
                    }
                }
            }

            if (equipment_conflict == false)
            {
                Console.WriteLine("Equipping {0}",item.GetName());
                equipped_items.Add(item);
                inventory.Remove(item);
                AddStats(item);
                return 0;
            }
            else
            {
                return 0;
            }
        }

        //Name: Inventory deleter
        //Take the name of a item to be deleted and if found, will remove the item from the inventory
        public void DropItem()
        {
            string name = " ";
            Console.WriteLine("Type the name of the item you would like to drop: ");
            name = Console.ReadLine();
            IObject remove = GetItem(name);
            if (remove != null)
            {
                Console.WriteLine("{0} dropped!",remove.GetName());
                inventory.Remove(remove);
            }

        }

        //Name: Add stats to player
        //Given a item, determine what types of stats it gives, and add it to the player
        private void AddStats(IObject item)
        {
            if (item.GetStatType() == "Attack")
            {
                attack_value += item.GetObjectStatValue();
            }
            else if (item.GetStatType() == "Health")
            {
                current_health_value += item.GetObjectStatValue();
                max_health += item.GetObjectStatValue();
            }
            else if (item.GetStatType() == "Attack/Health")
            {
                attack_value += item.GetObjectStatValue();
                current_health_value += item.GetObjectStatValue();
                max_health += item.GetObjectStatValue();
            }
            else if (item.GetStatType() == "Defense")
            {
                defense += item.GetObjectStatValue();
            }
            else if (item.GetStatType() == "Health/Defense")
            {
                current_health_value += item.GetObjectStatValue();
                max_health += item.GetObjectStatValue();
                defense += item.GetObjectStatValue();
            }
        }

        //Name: Remove stats from player
        //Given a item, determine what types of stats it gives, and remove it from the player
        private void RemoveStats(IObject item)
        {
            if (item.GetStatType() == "Attack")
            {
                attack_value -= item.GetObjectStatValue();
            }
            else if (item.GetStatType() == "Health")
            {
                current_health_value -= item.GetObjectStatValue();
                max_health -= item.GetObjectStatValue();
            }
            else if (item.GetStatType() == "Attack/Health")
            {
                attack_value -= item.GetObjectStatValue();
                current_health_value -= item.GetObjectStatValue();
                max_health -= item.GetObjectStatValue();
            }
            else if (item.GetStatType() == "Defense")
            {
                defense -= item.GetObjectStatValue();
            }
            else if (item.GetStatType() == "Health/Defense")
            {
                current_health_value -= item.GetObjectStatValue();
                max_health -= item.GetObjectStatValue();
                defense -= item.GetObjectStatValue();
            }
        }

        //Name: Display equipped equipment
        //Calles displayobjectstats on every equipped item in equipped items list
        public void DisplayEquippedItems()
        {
            Console.WriteLine("Currently Equipped Items: ");
            foreach (IObject item in equipped_items)
            {
                item.DisplayObjectStats();
            }
        }

        //Name: Item get
        //Add item to inventory if not null
        public void AddItemToInventory(IObject item)
        {
            if (item != null)
            {
                inventory.Add(item);
            }
        }

        //Name: Attacker
        //Given a enemy of type LivingObject, attack each other until either enemy/player dies
        public override void Attack(LivingObject enemy)
        {
            Console.WriteLine("Attacking enemy!");
            while (is_alive == true && enemy.is_alive == true)
            {
                Console.WriteLine("You have done {0} damage to the enemy", (GetAttackValue() - enemy.GetDefense()));
                enemy.SetCurrentHealth(enemy.GetCurrentHealth() - (GetAttackValue() - enemy.GetDefense()));
                if (enemy.GetCurrentHealth() <= 0)
                {
                    enemy.is_alive = false;
                }
                Console.WriteLine("The enemy has {0} health remaining", enemy.GetCurrentHealth());

                Thread.Sleep(500);

                if (enemy.is_alive == true)
                {
                    Console.WriteLine("You have taken {0} damage from the enemy. ", (enemy.GetAttackValue() - GetDefense()));
                    SetCurrentHealth(GetCurrentHealth() - (enemy.GetAttackValue() - GetDefense()));
                    if (GetCurrentHealth() <= 0)
                    {
                        is_alive = false;
                    }
                    Console.WriteLine("You have {0} health remaining", GetCurrentHealth());
                }
            }

            if (is_alive == false)
            {
                Console.WriteLine("You have died!");
            }
            else
            {
                Console.WriteLine("The enemy has been killed. Your current health: {0}", GetCurrentHealth());
            }
        }
    }
}
