//Creator: Vincent Siu
//Time spent: 51 hours 20 minutes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

//Name: Main
//Purpose: Perform main functions of the game at a central point, calling external functions/methods as needed
//Creates objects Player , has helper functions to generate enemies/bosses, and to display all commands as needed
namespace MainExe
{
    class Program
    {
        private static void HelpCommands()
        {
            Console.WriteLine("Available Commands: ");
            Console.WriteLine("f - fight a random enemy in the current zone");
            Console.WriteLine("s - display your player stats");
            Console.WriteLine("h - heals the player to max health");
            Console.WriteLine("i - displays the player's inventory");
            Console.WriteLine("equipped - shows the items that the player has actively equipped");
            Console.WriteLine("equip - equip an item from your inventory");
            Console.WriteLine("d - drop 1 or all items of a certain name from your inventory");
            Console.WriteLine("enhance - consume all identical items from your inventory to enhance the equipped item");
            Console.WriteLine("c - consume potions to gain stats!");
            Console.WriteLine("a - allows you to view the stats of the boss and challenge it");
        }

        private static LivingObject GenerateEnemy(int zone_number)
        {
            if (zone_number == 1)
            {
                return new Zone1Enemy();
            }
            else if (zone_number == 2)
            {
                return new Zone2Enemy();
            }
            else if (zone_number == 3)
            {
                return new Zone3Enemy();
            }
            else if (zone_number == 4)
            {
                return new Zone4Enemy();
            }
            else if (zone_number == 5)
            {
                return new Zone5Enemy();
            }
            else
            {
                Console.WriteLine("Not supposed to happen");
                return new Zone1Enemy();
            }
        }

        private static IZoneBoss GenerateBoss(int zone_number)
        {
            if (zone_number == 1)
            {
                return new Zone1Boss();
            }
            else if (zone_number == 2)
            {
                return new Zone2Boss();
            }
            else if (zone_number == 3)
            {
                return new Zone3Boss();
            }
            else if (zone_number == 4)
            {
                return new Zone4Boss();
            }
            else if (zone_number == 5)
            {
                return new Zone5Boss();
            }
            else
            {
                //Console.WriteLine("Not supposed to happen");
                return new Zone1Boss();
            }
        }

        static void Main(string[] args)
        {
            bool done = false;
            int zone_number = 1;
            string command = " ";
            Console.WriteLine("Welcome to my game!");
            Console.WriteLine("This is a text rpg, where you interact with the game through commands");

            Player p = Player.GetPlayerInstance();
            Console.WriteLine("Now, you can interact with the game with commands! They are shown below, and can be pulled up again through the command help!");
            HelpCommands();

            while (p.is_alive == true && done == false)
            {
                command = Console.ReadLine();
                IZoneBoss boss = null;

                if (command == "f")
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    LivingObject e = GenerateEnemy(zone_number);
                    p.Attack(e);
                    p.XP(zone_number);
                    p.AddItemToInventory(e.ItemDrop());
                    p.AddItemToInventory(e.PotionDrop());
                }
                else if (command == "help")
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    HelpCommands();
                }
                else if (command == "s")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    p.DispalyPlayerStats();
                }
                else if (command == "h")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You have been healed to max health!");
                    p.SetCurrentHealth(p.GetMaxHealth());
                }
                else if (command == "i")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    p.DisplayInventory();
                }
                else if (command == "equipped")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    p.DisplayEquippedItems();
                }
                else if (command == "d")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    p.DropItem();
                }
                else if (command == "enhance")
                {
                    string eq_name;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Type the name of the equipment that you want enhanced. It must be currently be equipped!: ");
                    eq_name = Console.ReadLine();
                    IObject selected_item = p.GetItem(eq_name);
                    if (selected_item != null)
                    {
                        if (selected_item.GetObjectType() != "Potion")
                        {
                            p.EnhanceItem(selected_item);
                        }
                        else
                        {
                            Console.WriteLine("You cannot enhance a potion. Consume it.");
                        }
                    }
                }
                else if (command == "equip")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    string eq_name = " ";
                    Console.WriteLine("Type the name of the equipment that you want equipped: ");
                    eq_name = Console.ReadLine();
                    IObject selected_item = p.GetItem(eq_name);
                    if (selected_item != null)
                    {
                        if (selected_item.GetObjectType() != "Potion")
                        {
                            p.EquipItem(selected_item);
                        }
                        else
                        {
                            Console.WriteLine("You cannot equip a potion. Consume it.");
                        }
                    }
                }
                else if (command == "c")
                {
                    string name = " ";
                    Console.WriteLine("Type the name of the potion you want to consume: ");
                    name = Console.ReadLine();
                    IObject selected_item = p.GetItem(name);
                    if (selected_item != null)
                    {
                        p.ConsumePotion(selected_item);
                    }
                }
                else if (command == "a")
                {
                    string choice;
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (boss == null)
                    {
                        boss = GenerateBoss(zone_number);
                    }
                    boss.DisplayBossStats();
                    Console.WriteLine("Would you like the challenge the boss?");
                    choice = Console.ReadLine();
                    if (choice == "yes")
                    {
                        Console.WriteLine("Challenging the boss!");
                        p.Attack(boss);
                        Console.WriteLine("The boss of zone {0} has been slain!", zone_number);
                        if (zone_number < 5)
                        {
                            zone_number++;
                            Console.WriteLine("Advancing to zone #{0}!", zone_number);
                            boss = GenerateBoss(zone_number);
                        }
                        else
                        {
                            done = true;
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid command entered.");
                }
                Console.ForegroundColor = ConsoleColor.White;
            }

            if (p.is_alive == false)
            {
                Console.WriteLine("You have died!");
                Console.WriteLine("Re-run the program to try again!");
            }
            else if(done == true)
            {
                Console.WriteLine("Congrats for beating the game!");
            }
            else
            {
                Console.WriteLine("Not supposed to happen");
            }
        }
    }
}
