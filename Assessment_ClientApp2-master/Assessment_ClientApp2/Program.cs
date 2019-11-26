using System;
using System.Collections.Generic;
using System.IO;

namespace Assessment_ClientApp2
{

    // **************************************************
    //
    // Assessment: Client App 2.0
    // Author: Cole Crain
    // Date Started:11/25/2019
    // Date Last Update:11/30/2019
    // Level (Novice, Apprentice, or Master): 
    //
    // **************************************************    

    class Program
    {
        /// <summary>
        /// Main method - app starts here
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // initialize monster list from method
            List<Monster> monsters = InitializeMonsterList();

            // read monsters from data file
            //List<Monster> monsters = ReadFromDataFile();

            // application flow
            DisplayWelcomeScreen();
            DisplayMenuScreen(monsters);
            DisplayClosingScreen();
        }

        #region UTILITY METHODS

        /// <summary>
        /// initialize a list of monsters
        /// </summary>
        /// <returns>list of monsters</returns>
        static List<Monster> InitializeMonsterList()
        {

            // create a list of monsters
            // note: list and object initializers used

            List<Monster> monsters = new List<Monster>()
            {

                new Monster()
                {
                    Name = "Sid",
                    Age = 145,
                    Attitude = Monster.EmotionalState.happy,
                    Tribe = Monster.TribeName.tabo,
                    Active = false
                },

                new Monster()
                {
                    Name = "Lucy",
                    Age = 125,
                    Attitude = Monster.EmotionalState.bored,
                    Tribe = Monster.TribeName.caltar,
                    Active = true
                },

                new Monster()
                {
                    Name = "Bill",
                    Age = 934,
                    Attitude = Monster.EmotionalState.sad,
                    Tribe = Monster.TribeName.silva,
                    Active = true
                },

                //--Todo add two new monsters        
                //--Done Below
                 new Monster()
                 {
                     Name = "Cal",
                     Age = 100,
                     Attitude = Monster.EmotionalState.angry,
                     Tribe = Monster.TribeName.dewa,
                     Active = false
                                      },

                  new Monster()
                 {
                     Name = "Fred",
                     Age = 150,
                     Attitude = Monster.EmotionalState.happy,
                     Tribe = Monster.TribeName.capar,
                     Active = true
                 }
            };
            return monsters;
        }

        #endregion

        #region SCREEN DISPLAY METHODS

        /// <summary>
        /// SCREEN: display and process menu options
        /// </summary>
        /// <param name="monsters">list of monsters</param>
        static void DisplayMenuScreen(List<Monster> monsters)
        {
            bool quitApplication = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Main Menu");

                // get user menu choice
                Console.WriteLine("\ta) List All Monsters");
                Console.WriteLine("\tb) View Monster Detail");
                Console.WriteLine("\tc) Add Monster");
                Console.WriteLine("\td) Delete Monster");
                Console.WriteLine("\te) Update Monster");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                // process user menu choice
                switch (menuChoice)
                {
                    case "a":
                        DisplayAllMonsters(monsters);
                        break;

                    case "b":
                        DisplayViewMonsterDetail(monsters);
                        break;

                    case "c":
                        DisplayAddMonster(monsters);
                        break;

                    case "d":
                        DisplayDeleteMonster(monsters);
                        break;

                    case "e":
                        DisplayUpdateMonster(monsters);
                        break;

                    case "q":
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine("******************************************");
                        Console.WriteLine("Please enter a letter for the menu choice.");
                        Console.WriteLine("******************************************");
                        DisplayContinuePrompt();
                        break;
                }
            } while (!quitApplication);
        }

        /// <summary>
        /// SCREEN: list all monsters
        /// </summary>
        /// <param name="monsters">list of monsters</param>
        static void DisplayAllMonsters(List<Monster> monsters)
        {
            DisplayScreenHeader("All Monsters");

            Console.WriteLine("\t***************************");
            foreach (Monster monster in monsters)
            {
                MonsterInfo(monster);
                Console.WriteLine();
                Console.WriteLine("\t***************************");
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// SCREEN: monster detail
        /// </summary>
        /// <param name="monsters">list of monsters</param>
        static void DisplayViewMonsterDetail(List<Monster> monsters)
        {
            DisplayScreenHeader("Monster Detail");

            // display all monster names           
            Console.WriteLine("\tMonster Names");
            Console.WriteLine("\t-------------");
            foreach (Monster monster in monsters)
            {
                Console.WriteLine("\t" + monster.Name);
            }

            // get user monster choice
            Console.WriteLine();
            Console.Write("\tEnter name:");
            string monsterName = Console.ReadLine();

            // get monster object            
            Monster selectedMonster = null;
            foreach (Monster monster in monsters)
            {
                if (monster.Name == monsterName)
                {
                    selectedMonster = monster;
                    break;
                }
            }

            // display monster detail
            do
            {
                Console.WriteLine();
                Console.WriteLine("\t*********************");
                MonsterInfo(selectedMonster);
                Console.WriteLine("\t*********************");

                DisplayContinuePrompt();

            } while (false);

        }

        /// <summary>
        /// SCREEN: add a monster
        /// </summary>
        /// <param name="monsters">list of monsters</param>
        static void DisplayAddMonster(List<Monster> monsters)
        {
            //--TODO  Validate Test
            //--
            do
            {
                Monster newMonster = new Monster();

                DisplayScreenHeader("Add Monster");

                // add monster object property values
                Console.WriteLine("");
                Console.Write("\tEnter Name Here: ");
                newMonster.Name = Console.ReadLine();

                Console.Write("\t Enter Age Here: ");
                int.TryParse(Console.ReadLine(), out int age);
                newMonster.Age = age;

                Console.Write("\tEnter Attitude Here: ");
                Enum.TryParse(Console.ReadLine(), out Monster.EmotionalState attitude);
                newMonster.Attitude = attitude;

                Console.Write("\tEnter Tribe Here: ");
                Enum.TryParse(Console.ReadLine(), out Monster.TribeName tribe);
                newMonster.Tribe = tribe;

                Console.Write("\tActive Either[true or false]: ");
                bool.TryParse(Console.ReadLine(), out bool active);
                newMonster.Active = active;

                // echo new monster properties           
                Console.WriteLine();
                Console.WriteLine("\tNew Monster's Properties");
                Console.WriteLine("\t-------------");
                MonsterInfo(newMonster);
                Console.WriteLine();
                Console.WriteLine("\t-------------");

                DisplayContinuePrompt();

                monsters.Add(newMonster);

            } while (true);

        }

        /// <summary>
        /// SCREEN: delete monster
        /// </summary>
        /// <param name="monsters">list of monsters</param>
        static void DisplayDeleteMonster(List<Monster> monsters)
        {
            DisplayScreenHeader("Delete Monster");

            //
            // display all monster names
            //
            Console.WriteLine("\tMonster Names");
            Console.WriteLine("\t-------------");
            foreach (Monster monster in monsters)
            {
                Console.WriteLine("\t" + monster.Name);
            }

            //
            // get user monster choice
            //
            Console.WriteLine();
            Console.Write("\tEnter name:");
            string monsterName = Console.ReadLine();

            //
            // get monster object
            //
            Monster selectedMonster = null;
            foreach (Monster monster in monsters)
            {
                if (monster.Name == monsterName)
                {
                    selectedMonster = monster;
                    break;
                }
            }

            // delete monster          
            if (selectedMonster != null)
            {
                monsters.Remove(selectedMonster);
                Console.WriteLine();
                Console.WriteLine($"\t{selectedMonster.Name} deleted");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"\t{monsterName} not found");
            }
            DisplayContinuePrompt();
        }

        /// <summary>
        /// SCREEN: update monster
        /// </summary>
        /// <param name="monsters">list of monsters</param>
        /// 
        static void DisplayUpdateMonster(List<Monster> monsters)
        {
            //--TODO  Validate Test
            //--
            bool validResponse = false;
            Monster selectedMonster = null;

            do
            {
                DisplayScreenHeader("Update Monster");

                //
                // display all monster names
                //
                Console.WriteLine("\tMonster Names");
                Console.WriteLine("\t-------------");
                foreach (Monster monster in monsters)
                {
                    Console.WriteLine("\t" + monster.Name);
                }

                // get user monster choice
                Console.WriteLine();
                Console.Write("\tEnter name:");
                string monsterName = Console.ReadLine();

                // get monster object                
                foreach (Monster monster in monsters)
                {
                    if (monster.Name == monsterName)
                    {
                        selectedMonster = monster;
                        validResponse = true;
                        break;
                    }
                }

                // feedback for wrong name choice                
                if (!validResponse)
                {
                    Console.WriteLine("\tPlease select a correct name.");
                    DisplayContinuePrompt();
                }

                // update monster                
            } while (!validResponse);

            // update monster properties         
            string userResponse;
            Console.WriteLine();
            Console.WriteLine("\tReady to update. Press the Enter to keep the current info.");
            Console.WriteLine();

            Console.Write($"\tCurrent Name: {selectedMonster.Name} New Name: ");
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                selectedMonster.Name = userResponse;
            }

            Console.Write($"\tCurrent Age: {selectedMonster.Age} New Age: ");
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                int.TryParse(userResponse, out int age);
                selectedMonster.Age = age;
            }

            Console.Write($"\tCurrent Attitude: {selectedMonster.Attitude} New Attitude: ");
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                Enum.TryParse(userResponse, out Monster.EmotionalState attitude);
                selectedMonster.Attitude = attitude;
            }
            //--todo add Tribe and Active
            //-- Done
            Console.Write($"\tCurrent Tribe: {selectedMonster.Tribe} New Tribe: ");
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                Enum.TryParse(userResponse, out Monster.TribeName tribe);
                selectedMonster.Tribe = tribe;
            }

            Console.Write($"\tCurrent Active: {selectedMonster.Active} New Active: ");
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                bool.TryParse(userResponse, out bool active);
                selectedMonster.Active = active;
            }

            // echo updated monster properties
            Console.WriteLine();
            Console.WriteLine("\tNew Monster's Properties");
            Console.WriteLine("\t-------------");
            MonsterInfo(selectedMonster);
            Console.WriteLine();
            Console.WriteLine("\t-------------");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// SCREEN: write list of monsters to data file
        /// </summary>
        /// <param name="monsters">list of monsters</param>
        static void DisplayWriteToDataFile(List<Monster> monsters)
        {
            DisplayScreenHeader("Write to Data File");

            // prompt the user to continue
            Console.WriteLine("\tThe application is ready to write to the data file.");
            Console.Write("\tEnter 'y' to continue or 'n' to cancel.");
            if (Console.ReadLine().ToLower() == "y")
            {
                DisplayContinuePrompt();
                WriteToDataFile(monsters);

                // process I/O exceptions               
                Console.WriteLine();
                Console.WriteLine("\tList written to data the file.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("\tList not written to the data file.");
            }

            DisplayContinuePrompt();
        }

        #endregion

        #region FILE I/O METHODS

        /// <summary>
        /// write monster list to data file
        /// </summary>
        /// <param name="monsters">list of monsters</param>
        static void WriteToDataFile(List<Monster> monsters)
        {
            string[] monstersString = new string[monsters.Count];

            // create array of monster strings           
            for (int index = 0; index < monsters.Count; index++)
            {
                string monsterString =
                    monsters[index].Name + "," +
                    monsters[index].Age + "," +
                    monsters[index].Attitude + "," +
                    monsters[index].Tribe + "," +
                    monsters[index].Active;

                monstersString[index] = monsterString;
            }
            File.WriteAllLines("Data\\Data.txt", monstersString);
        }

        /// <summary>
        /// read monsters from data file and return a list of monsters
        /// </summary>
        /// <returns>list of monsters</returns>        
        static List<Monster> ReadFromDataFile()
        {
            List<Monster> monsters = new List<Monster>();

            //
            // read all lines in the file
            //
            string[] monstersString = File.ReadAllLines("Data\\Data.txt");

            //
            // create monster objects and add to the list
            //
            foreach (string monsterString in monstersString)
            {
                // get individual properties           
                string[] monsterProperties = monsterString.Split(',');

                // create monster               
                Monster newMonster = new Monster();

                // update monster property values               
                newMonster.Name = monsterProperties[0];

                int.TryParse(monsterProperties[1], out int age);
                newMonster.Age = age;

                Enum.TryParse(monsterProperties[2], out Monster.EmotionalState attitude);
                newMonster.Attitude = attitude;

                Enum.TryParse(monsterProperties[3], out Monster.TribeName tribe);
                newMonster.Tribe = tribe;

                bool.TryParse(monsterProperties[4], out bool active);
                newMonster.Active = active;

                // add new monster to list                
                monsters.Add(newMonster);
            }
            return monsters;
        }

        #endregion

        #region CONSOLE HELPER METHODS

        //--TODO update for new Properties(Monsters Added)
        //--Done

        /// <summary>
        /// display all monster properties
        /// </summary>
        /// <param name="monster">monster object</param>
        static void MonsterInfo(Monster monster)
        {
            if (true)
            {

            }
            Console.WriteLine($"\tName: {monster.Name}");
            Console.WriteLine($"\tAge: {monster.Age}");
            Console.WriteLine($"\tAttitude: {monster.Attitude}");
            Console.WriteLine("\t" + monster.Greeting());
            Console.WriteLine($"\tTribe: {monster.Tribe}");
            Console.WriteLine("\t" + monster.MyTribe());
            Console.WriteLine($"\tActice: {monster.Active}");
        }

        /// <summary>
        /// display welcome screen
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThe Monster Tracker");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display closing screen
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using the Monster Tracker!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.CursorVisible = false;
            Console.WriteLine();
            Console.Write("\tPress any key to continue.");
            Console.ReadKey();
            Console.CursorVisible = true;
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
    }
}
