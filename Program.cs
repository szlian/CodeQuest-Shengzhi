using System;
using System.Linq.Expressions;
using System.Text;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        // Constants for game
        const string Chap3Coin = "🪙";
        const string Chap3Wrong = " ❌";

        // Menu constants
        const string MenuTitle = "===== MAIN MENU - CODEQUEST =====";
        const string MenuOption1 = "1. Train your wizard";
        const string MenuOption2 = "2. Increase lvl";
        const string MenuOption3 = "3. Loot the mine";
        const string MenuOption4 = "4. Show inventory";
        const string MenuOption5 = "5. Buy items";
        const string MenuOption6 = "6. Show attacks";
        const string MenuOption7 = "7. Decodes scroll";
        const string MenuOptionExit = "0. Exit game";
        const string MenuPrompt = "Choose an option (1-7) - (0) to exit: ";
        const string MageNamePrompt = "Tell me your name";

        // Mage rank messages
        const string RaodenElElanriMsg = "Repeteixes a 2a convocatòria";
        const string Rank1 = "Raoden el Elantrí";
        const string ZynElBuguejatMsg = "Encara confons la vareta amb una cullera";
        const string Rank2 = "Zyn el Buguejat";
        const string ArkaNullpointerMsg = "Ets un Invocador de Brises Màgiques";
        const string Rank3 = "Arka NULL Pointer";
        const string ElarionDeLesBrasesMsg = "Uau! Pots invocar dracs sense cremar el laboratori!";
        const string Rank4 = "Elarion de les Brases";
        const string ITBWizardElGrisMsg = "Has assolit el rang de Mestre dels Arcans!";
        const string Rank5 = "ITBWizard el dorado";

        // Game messages
        const string WelcomeMsg = "Welcome ";
        const string StartTrainingMsg = "Let's start your training!";
        const string DayExpMsg = "Day ";
        const string YouGetExpMsg = " You get ";
        const string ExpMsg = " exp";
        const string PressEnterTrainingMsg = "Press enter to continue training, day ";
        const string YourCurrentExpMsg = " Your current exp is ";
        const string YouGotRankMsg = "You got rank ";
        const string TotalExpMsg = "You got ";
        const string ExpKnownAsMsg = " exp you will be known by the name of ";
        const string OptionChosenMsg = "Option chosen";
        const string PressEnterContinueMsg = "Press enter to continue";
        const string LevelUpMsg = "Level up";
        const string AlreadyMaxLevelMsg = "You are already max lvl";
        const string AppearedMonsterMsg = "A monster has appeared: ";
        const string HasHpMsg = " has ";
        const string HpMsg = " hp";
        const string PressEnterDiceMsg = "Press enter to throw dice and inflict damage";
        const string YouRolledMsg = "You rolled the number ";
        const string YouInflictMsg = "You inflict ";
        const string DamageMsg = " damage";
        const string MonsterHasMsg = "The ";
        const string PressEnterKeepThrowingMsg = "Press enter to keep throwing ";
        const string NoHealthLeftMsg = " has no health left, you have defeated it";
        const string YouAreLevelMsg = "You are level ";
        const string OptionChosenPressEnterMsg = "Option has been chosen, press enter to continue";
        const string InsertCoordsMsg = "Insert coords";
        const string InsertYCoordMsg = "Insert Y coord";
        const string InsertXCoordMsg = " Insert X coord";
        const string ChooseAnotherSpotMsg = "Choose another spot, this one has already been chosen ";
        const string FoundCoinMsg = "You found a coin";
        const string PointsEarnedMsg = " + ";
        const string EnterContinueMsg = " Enter to continue";
        const string NothingHereMsg = "There's nothing here";
        const string AttemptsLeftMsg = "You have ";
        const string AttemptsLeftAndMsg = " attempts left and you have ";
        const string PointsMsg = " points";
        const string OutOfRangeMsg = "Out of range";
        const string InvalidFormatMsg = "Invalid format";
        const string OpenInventoryMsg = "open inventory";
        const string InventoryEmptyMsg = "Your inventory is currently empty";
        const string InventoryItemsMsg = "In your inventory you have ";
        const string ObjectsMsg = " objects";
        const string PressEnterReturnMsg = "Press enter to return";
        const string CurrentlyHaveBitsMsg = "Currently you have ";
        const string BitsWannaBuyMsg = " bits, wanna buy something?";
        const string BuyItemsNumberMsg = "buy items pressing their corresponding number or press 0 to exit";
        const string InvalidInputMsg = "Invalid input.";
        const string PurchaseCancelledMsg = "Purchase cancelled.";
        const string InvalidOptionMsg = "Invalid option";
        const string YouBoughtMsg = "You bought ";
        const string NowYouHaveMsg = "Now you have ";
        const string BitsLeftMsg = " bits left";
        const string NotEnoughBitsMsg = "You don't have enough bits, currently you have ";
        const string AttacksAvailableMsg = "=== Attacks available at your current level ===";
        const string YourCurrentLevelMsg = "Your current level is: ";
        const string LevelAttacksMsg = "Level attacks:";
        const string DecodeScrollMsg = "Decode ancient Scroll";

        // Attacks arrays
        string[] attacksLvl1 = { "Magic Spark 💫" };
        string[] attacksLvl2 = { "Fireball 🔥", "Ice Ray 🥏", "Arcane Shield ⚕️" };
        string[] attacksLvl3 = { "Meteor ☄️", "Pure Energy Explosion 💥", "Minor Charm 🎭", "Air Strike 🍃" };
        string[] attacksLvl4 = { "Wave of Light ⚜️", "Storm of Wings 🐦" };
        string[] attacksLvl5 = { "Cataclysm 🌋", "Portal of Chaos 🌀", "Arcane Blood Pact 🩸", "Elemental Storm ⛈️" };

        // Enemies
        string[] Enemies = {
            "Wandering Skeleton ",
            "Forest Goblin ",
            "Green Slime ",
            "Ember Wolf ",
            "Giant Spider ",
            "Iron Golem ",
            "Lost Necromancer ",
            "Ancient Dragon "
        };

        int[] hp = { 3, 5, 10, 11, 18, 15, 20, 50 };

        // Inventory
        string[] inventory = new string[0];
        int Bits = 0;

        // Dice ASCII art
        // Dice ASCII art según el estilo del PDF
        const string Dice1 = @"
 /    /| 
 /---/ | 
 |    | | 
 |  o  | / 
 |    |/ 
'---'";

        const string Dice2 = @"
 /    /| 
 /---/ | 
 | o  | | 
 |    | / 
 | o  |/ 
'---'";

        const string Dice3 = @"
 /    /| 
 /---/ | 
 | o  | | 
 |  o | / 
 |   o|/ 
'---'";

        const string Dice4 = @"
 /    /| 
 /---/ | 
 | o o| | 
 |    | / 
 | o o|/ 
'---'";

        const string Dice5 = @"
 /    /| 
 /---/ | 
 | o o| | 
 |  o | / 
 | o o|/ 
'---'";

        const string Dice6 = @"
 /    /| 
 /---/ | 
 | o o| | 
 | o o| / 
 | o o|/ 
'---'";

        // Game variables
        int lvl = 1;
        int option = -1;
        string name = "nothing";
        Random random = new Random();
        int day = 1;
        int totalexp = 0;
        int x = 0;
        int y = 0;
        int tries = 0;
        string Title = "xd";

        while (option != 0)
        {
            Console.WriteLine(MenuTitle);
            Console.WriteLine(MenuOption1);
            Console.WriteLine(MenuOption2);
            Console.WriteLine(MenuOption3);
            Console.WriteLine(MenuOption4);
            Console.WriteLine(MenuOption5);
            Console.WriteLine(MenuOption6);
            Console.WriteLine(MenuOption7);
            Console.WriteLine(MenuOptionExit);
            Console.WriteLine(MenuPrompt);

            option = Convert.ToInt32(Console.ReadLine());

            if (option == 0)
            {
                Console.WriteLine("Leaving...");
                break;
            }

            switch (option)
            {
                case 1:
                    if (name == "nothing")
                    {
                        Console.WriteLine(MageNamePrompt);

                        name = Console.ReadLine();
                        //mayusculas
                        name = char.ToUpper(name[0]) + name.Substring(1).ToLower();
                        Console.WriteLine(WelcomeMsg + name);
                    }

                    Console.WriteLine(StartTrainingMsg);
                    day = 1;

                    while (day <= 5)
                    {
                        int exp = random.Next(0, 25);
                        Console.WriteLine(DayExpMsg + day + YouGetExpMsg + exp + ExpMsg);
                        day++;
                        totalexp = totalexp + exp;
                        Console.WriteLine(PressEnterTrainingMsg + (day - 1) + YourCurrentExpMsg + totalexp);
                        Console.ReadLine();
                    }

                    if (totalexp < 20)
                    {
                        Console.WriteLine(YouGotRankMsg + Rank1);
                        Console.WriteLine(RaodenElElanriMsg);
                        Title = Rank1;
                    }
                    else if (totalexp >= 20 && totalexp < 30)
                    {
                        Console.WriteLine(YouGotRankMsg + Rank2);
                        Console.WriteLine(ZynElBuguejatMsg);
                        Title = Rank2;
                    }
                    else if (totalexp >= 30 && totalexp < 35)
                    {
                        Console.WriteLine(YouGotRankMsg + Rank3);
                        Console.WriteLine(ArkaNullpointerMsg);
                        Title = Rank3;
                    }
                    else if (totalexp >= 35 && totalexp < 40)
                    {
                        Console.WriteLine(YouGotRankMsg + Rank4);
                        Console.WriteLine(ElarionDeLesBrasesMsg);
                        Title = Rank4;
                    }
                    else if (totalexp >= 40)
                    {
                        Console.WriteLine(YouGotRankMsg + Rank5);
                        Console.WriteLine(ITBWizardElGrisMsg);
                        Title = Rank5;
                    }

                    Console.WriteLine(TotalExpMsg + totalexp + ExpKnownAsMsg + name + " " + Title);
                    Console.ReadLine();
                    break;

                case 2:
                    Console.WriteLine(OptionChosenMsg + " 2");
                    Console.WriteLine(LevelUpMsg + ", " + PressEnterContinueMsg.ToLower());
                    Console.ReadLine();

                    if (lvl == 5)
                    {
                        Console.WriteLine(AlreadyMaxLevelMsg);
                        Console.ReadLine();
                        break;
                    }

                    int enemyIndex = random.Next(1, Enemies.Length);
                    string enemyName = Enemies[enemyIndex];
                    int enemyHealth = hp[enemyIndex];

                    Console.WriteLine(AppearedMonsterMsg + enemyName + HasHpMsg + enemyHealth + HpMsg);
                    Console.WriteLine(PressEnterDiceMsg);
                    Console.ReadLine();

                    while (enemyHealth > 0)
                    {
                        int dice = random.Next(1, 7);
                        enemyHealth = enemyHealth - dice;

                        Console.WriteLine(YouRolledMsg + dice);
                        Console.WriteLine(YouInflictMsg + dice + DamageMsg);

                        if (dice == 1) Console.WriteLine(Dice1);
                        else if (dice == 2) Console.WriteLine(Dice2);
                        else if (dice == 3) Console.WriteLine(Dice3);
                        else if (dice == 4) Console.WriteLine(Dice4);
                        else if (dice == 5) Console.WriteLine(Dice5);
                        else if (dice == 6) Console.WriteLine(Dice6);

                        Console.WriteLine(MonsterHasMsg + enemyName + HasHpMsg + enemyHealth + HpMsg);
                        Console.WriteLine(PressEnterKeepThrowingMsg);
                        Console.ReadLine();

                        if (enemyHealth <= 0)
                        {
                            Console.WriteLine(enemyName + NoHealthLeftMsg);
                            lvl = lvl + 1;
                            Console.WriteLine(YouAreLevelMsg + lvl);
                        }
                    }
                    break;

                case 3:
                    Console.WriteLine(OptionChosenPressEnterMsg);
                    Console.ReadLine();

                    string[,] PublicMine = new string[5, 5];
                    bool[,] HiddenMine = new bool[5, 5];

                    while (tries < 5)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int u = 0; u < 5; u++)
                            {
                                PublicMine[i, u] = " - ";
                            }
                        }

                        int coins = random.Next(5, 11);
                        for (int coin = 0; coin < coins; coin++)
                        {
                            int coordXCoin = random.Next(0, 5);
                            int coordYCoin = random.Next(0, 5);
                            HiddenMine[coordXCoin, coordYCoin] = true;
                        }

                        for (int i = 0; i < 5; i++)
                        {
                            Console.WriteLine("   0  1  2  3  4");
                            for (int z = 0; z < PublicMine.GetLength(0); z++)
                            {
                                Console.Write(z + " ");
                                for (int m = 0; m < PublicMine.GetLength(1); m++)
                                {
                                    Console.Write(PublicMine[z, m]);
                                }
                                Console.WriteLine("");
                            }

                            Console.WriteLine(InsertCoordsMsg);
                            try
                            {
                                Console.WriteLine(InsertYCoordMsg);
                                y = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine(InsertXCoordMsg);
                                x = Convert.ToInt32(Console.ReadLine());

                                if (y <= 4 && y >= 0 && x <= 4 && x >= 0)
                                {
                                    if (PublicMine[y, x] == Chap3Coin)
                                    {
                                        PublicMine[y, x] = Chap3Wrong;
                                        Console.WriteLine(ChooseAnotherSpotMsg + Chap3Wrong);
                                    }
                                    else
                                    {
                                        if (HiddenMine[y, x])
                                        {
                                            PublicMine[y, x] = Chap3Coin;
                                            Console.WriteLine(FoundCoinMsg);
                                            int points = random.Next(5, 50);
                                            Bits = Bits + points;
                                            Console.WriteLine(PointsEarnedMsg + points + EnterContinueMsg);
                                            Console.ReadLine();
                                        }
                                        else
                                        {
                                            PublicMine[y, x] = Chap3Wrong;
                                            Console.WriteLine(NothingHereMsg);
                                        }
                                    }
                                    tries++;
                                    Console.WriteLine(AttemptsLeftMsg + (5 - tries) + AttemptsLeftAndMsg + Bits + PointsMsg);
                                }
                                else
                                {
                                    Console.WriteLine(OutOfRangeMsg);
                                    tries++;
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine(InvalidFormatMsg);
                            }
                        }
                    }
                    break;

                case 4:
                    Console.WriteLine("You choose option 4, " + OpenInventoryMsg + ", " + PressEnterContinueMsg.ToLower());
                    Console.WriteLine();

                    if (inventory.Length == 0)
                    {
                        Console.WriteLine(InventoryEmptyMsg);
                    }
                    else
                    {
                        Console.WriteLine(InventoryItemsMsg + inventory.Length + ObjectsMsg);
                    }

                    Console.WriteLine(PressEnterReturnMsg);
                    Console.ReadLine();
                    break;

                case 5:
                    Console.WriteLine("You choose option 5, " + PressEnterContinueMsg.ToLower());
                    Console.ReadLine();

                    Console.WriteLine(CurrentlyHaveBitsMsg + Bits + BitsWannaBuyMsg);

                    string[] shop = {
                        "Iron Dagger 🗡️",
                        "Healing Potion ⚗️",
                        "Ancient Key 🗝️",
                        "Crossbow 🏹",
                        "Metal Shield 🛡️"
                    };

                    int[] prices = { 30, 10, 50, 40, 20 };

                    for (int i = 0; i < shop.Length; i++)
                    {
                        Console.WriteLine((i + 1) + " " + shop[i] + " " + prices[i] + " bits");
                    }

                    Console.WriteLine(BuyItemsNumberMsg);

                    int choice = -1;
                    try
                    {
                        choice = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine(InvalidInputMsg);
                        break;
                    }

                    if (choice == 0)
                    {
                        Console.WriteLine(PurchaseCancelledMsg);
                        break;
                    }

                    if (choice < 1 || choice > 5)
                    {
                        Console.WriteLine(InvalidOptionMsg);
                        break;
                    }

                    int index = choice - 1;

                    if (Bits >= prices[index])
                    {
                        Bits = Bits - prices[index];
                        string[] inventoryAdd = new string[inventory.Length + 1];

                        for (int i = 0; i < inventory.Length; i++)
                        {
                            inventoryAdd[i] = inventory[i];
                        }

                        inventoryAdd[inventoryAdd.Length - 1] = shop[index];
                        inventory = inventoryAdd;

                        Console.WriteLine(YouBoughtMsg + shop[index]);
                        Console.WriteLine(NowYouHaveMsg + Bits + BitsLeftMsg);
                    }
                    else
                    {
                        Console.WriteLine(NotEnoughBitsMsg + Bits + BitsLeftMsg);
                    }

                    Console.WriteLine(PressEnterReturnMsg + ".");
                    Console.ReadLine();
                    break;

                case 6:
                    Console.WriteLine("You choose option 6, " + PressEnterContinueMsg.ToLower());
                    Console.ReadLine();

                    Console.WriteLine(AttacksAvailableMsg);
                    Console.WriteLine(YourCurrentLevelMsg + lvl);
                    Console.WriteLine();

                    if (lvl >= 1)
                    {
                        Console.WriteLine("1 " + LevelAttacksMsg.ToLower());
                        for (int i = 0; i < attacksLvl1.Length; i++)
                        {
                            Console.WriteLine("• " + attacksLvl1[i]);
                        }
                        Console.WriteLine();
                    }

                    if (lvl >= 2)
                    {
                        Console.WriteLine("2 " + LevelAttacksMsg.ToLower());
                        for (int i = 0; i < attacksLvl2.Length; i++)
                        {
                            Console.WriteLine("• " + attacksLvl2[i]);
                        }
                        Console.WriteLine();
                    }

                    if (lvl >= 3)
                    {
                        Console.WriteLine("3 " + LevelAttacksMsg.ToLower());
                        for (int i = 0; i < attacksLvl3.Length; i++)
                        {
                            Console.WriteLine("• " + attacksLvl3[i]);
                        }
                        Console.WriteLine();
                    }

                    if (lvl >= 4)
                    {
                        Console.WriteLine("4 " + LevelAttacksMsg.ToLower());
                        for (int i = 0; i < attacksLvl4.Length; i++)
                        {
                            Console.WriteLine("• " + attacksLvl4[i]);
                        }
                        Console.WriteLine();
                    }

                    if (lvl >= 5)
                    {
                        Console.WriteLine("5 " + LevelAttacksMsg.ToLower());
                        for (int i = 0; i < attacksLvl5.Length; i++)
                        {
                            Console.WriteLine("• " + attacksLvl5[i]);
                        }
                        Console.WriteLine();
                    }

                    Console.WriteLine(PressEnterReturnMsg + ".");
                    Console.ReadLine();
                    break;

                case 7:
                    Console.WriteLine("You choose option 7 - " + DecodeScrollMsg);
                    Console.WriteLine(PressEnterContinueMsg);
                    Console.ReadLine();
                    break;
            }
        }
    }
}
