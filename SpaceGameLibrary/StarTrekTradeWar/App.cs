using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrekTradeWar
{
    public class App
    {
        List<ILocation> locations = new List<ILocation>();

        Player hero;

        string fileName = "hero.json";


        public App()
        {
            Initialize();

        }

        private void Initialize()
        {
            //Populate Game World
            PopulateWorld();
            //Initialize player
            hero = new Player(locations[0]);
        }

        private void PopulateWorld()
        {
            var TransAlum = new Item("Transparent aluminum", 100M, "Ultra-strong transparent metal essential to build a spaceship.");
            var Biogel = new Item("Bio-mimetic gel", 50M, "Volatile substance highly sought after for use in illegal activities, such as genetic experimentation and biological weapons development.");
            var silk = new Item("Tholian silk", 10M, "valuable fabric");
            var Redmatter = new Item("Red matter", 5000M, " red liquid material that is able to create a black hole when not properly contained");
            
            //Initialize the game
            locations.Add(new Planet("Earth", "The birthplace of Homo sapiens. Once blue but " +
                "now pale yellow as a result of human stupidity.", 0, 0, new List<(Item, decimal)>() {
                    (silk, 0.5M),
                    (Biogel, 2M)}));
            locations.Add(new Planet("Proxima Centauri b", "The first colony of the human race ",
                4.22, 0, new List<(Item, decimal)>() {
                    ( TransAlum, 1M),
                    ( Biogel,1M)
                }));
            locations.Add(new Planet("GJ 273b", "One of the most Earth-like planets ever found. Rich deposit of some special metal...",
                11.61460079, 4.227368972, new List<(Item, decimal)>() {
                    ( silk, 2M),
                    ( TransAlum,0.5M),
                    (Redmatter, 1.9M)
                }));
            locations.Add(new Planet("Kepler-186f", "Secret outpost at the edge of Federation. Locals want Bio-mimetic gel for some reason...",
                280.5, 485.6, new List<(Item, decimal)>() {
                    ( Biogel, 10M),
                    ( TransAlum,0.1M),
                }));
            locations.Add(new Planet("Kepler-442b", "The New Frontier. Gravity is weirdly strong in this small planet. What's THE MATTER?",
                913.0, 913.0, new List<(Item, decimal)>() {
                    (Redmatter, 0.1M)
                }));
        }

        public void Run()
        {
            //Display entrance title
            Story.DisplayHeader();
            // TODO: Display story plot
            Story.DisplayIntro();
            //Main Gameloop
            var endCondition = GameLoop();

            //Give closing message if game ends
            Story.ClosingMessage(endCondition);
        }

        private EndCondition GameLoop()
        {
            List<string> actions = new List<string>();
            AddActionOptions(actions);
            EndCondition endCondition = EndCondition.NotEnd;
            do
            {
                Console.Clear();
                HUD();
                //TODO: PrintActionsMenu
                int selected = UI.SelectionMenu(actions);

                endCondition = DecideGameEnd(HandleSelection(selected));
                
            } while (endCondition == EndCondition.NotEnd);

            return endCondition;
        }

        private EndCondition DecideGameEnd(EndCondition endCondition)
        {
            //Age Out Ending: user older than 70 years old
            EndCondition AgeCheck(EndCondition e) => hero.Age >= 70 ? EndCondition.AgeOut : e;
            //Broke Ending: user has no money left and no goods to sell
            EndCondition MoneyCheck(EndCondition e) => hero.Money < 0 && !hero.Inventory.Any() ? EndCondition.MoneyOut : e;
            //Fuel Out Ending: user has no fuel left
            EndCondition FuelCheck(EndCondition e) => hero.Fuel < 0 ? EndCondition.FuelOut : e;
            //Money Max end: user has earned more than $10000
            EndCondition MoneyMaxCheck(EndCondition e) => hero.Money >= 10000 ? EndCondition.MoneyMax : e;

            if (endCondition == EndCondition.NotEnd)
            {
                endCondition = AgeCheck(endCondition);
                endCondition = MoneyCheck(endCondition);
                endCondition = FuelCheck(endCondition);
                endCondition = MoneyMaxCheck(endCondition);
            }


            return endCondition;
        }

        //Top Display for information about player status and local info
        private void HUD()
        {
            Console.Clear();
            //Print current statistics
            UI.CenteredString($"Location: {hero.location.Name}   Age:" +
                $"{hero.Age:f2} yrs old  Money: {hero.Money:f2} Space Dollor   Fuel: {hero.Fuel:f2} Unit of Dilithium\n");
            UI.CenteredString($"{hero.location.Description}");
            UI.CenteredString($"===============================================================================================");
        }

        private static void AddActionOptions(List<string> actions)
        {
            actions.Add("Travel to Other Planets");
            actions.Add("Check Planet Market/Buy");
            actions.Add("Check inventory   /Sell");
            actions.Add("Refuel         ");
            actions.Add("Save game");
            actions.Add("Load game");
        }

        private EndCondition HandleSelection(int selected)
        {
            switch (selected)
            {
                case -1:
                    return EndCondition.UserEnd;
                case 0:
                    TravelMenu();
                    break;
                case 1:
                    BuyMenu();
                    break;
                case 2:
                    SellMenu();
                    break;
                case 3:
                    RefuelMenu();
                    break;
                case 4:
                    SaveGame();
                    break;
                case 5:
                    LoadGame();
                    break;
                default:
                    break;
            }

            return EndCondition.NotEnd;
        }

        private void RefuelMenu()
        {
            int selected;
            do
            {
                HUD();
                selected = UI.SelectionMenu(new List<string>() { "Fuel Up ($10 per Unit of Dilithium)", "Fuel $100 (10 Unit of Dilithium)" , "Abort" });
                switch (selected)
                {
                    case -1:
                        break;
                    case 0:
                        if (hero.Fuel < 100 && hero.Money > 10 * (decimal)(100 - hero.Fuel))
                        {
                            hero.Money -= 10 * (decimal)(100-hero.Fuel);

                            hero.Fuel = 100;

                            Utility.PromptForInput($"Fueled Up. Hit any key to continue.");
                        }
                        else if (hero.Fuel >=100)
                        {
                            Utility.PromptForInput($"You are already fueled up. Hit any key to continue.");
                            continue;
                        }
                        else
                        {
                            Utility.PromptForInput($"You don't have enough money. Sell some goods first.");
                            continue;
                        }
                        break;
                    case 1:
                        if (hero.Fuel < 100 && hero.Money >= 100)
                        {
                            hero.Money -= 100;

                            hero.Fuel += 10;

                            if (hero.Fuel > 100) hero.Fuel = 100;

                            Utility.PromptForInput($"Fueled 10 unit. Hit any key to continue.");
                        }
                        else if (hero.Fuel >= 100)
                        {
                            Utility.PromptForInput($"You are already fueled up. Hit any key to continue.");
                            continue;
                        }
                        else
                        {
                            Utility.PromptForInput($"You don't have enough money. Sell some goods first.");
                            continue;
                        }
                        break;
                    case 2:
                        selected = -1;
                        break;
                }
            } while (selected != -1);

        }

        private void SellMenu()
        {
            int selected;
            do
            {
                HUD();
                if (!hero.Inventory.Any())
                {
                    Utility.PromptForInput("Your Storage Deck is empty. Hit any key to continue.");
                    break;
                }
                selected = UI.SelectionMenu(GetPlayerItems(hero.Inventory));
                if (selected == -1) break;
                else
                {
                    hero.SellItem(hero.Inventory[selected]);
                    Utility.PromptForInput($"Item sold. Hit any key to continue.");
                    continue;
                }
            } while (selected != -1);
        }

        private void BuyMenu()
        {
            int selected;
            do
            {
                HUD();
                selected = UI.SelectionMenu(GetLocalItems(hero.location.ItemMarkUps));
                if (selected == -1) break;
                else if (hero.Money>  0) //hero.location.CostOf(hero.location.ItemMarkUps[selected].Item1))
                {
                    hero.BuyItem(hero.location.ItemMarkUps[selected].Item1);
                    Utility.PromptForInput($"Item bought. Hit any key to continue.");
                    continue;
                }
                else
                {
                    Utility.PromptForInput($"You don't have enough money. Sell some goods first.");
                    continue;
                }
            } while (selected !=-1);
        }

        private List<string> GetLocalItems(List<(Item, decimal)> itemswithmarkup)
        {
            List<string> localPriceList = new List<string>();
            for (int i = 0; i < itemswithmarkup.Count; i++)
            {
                var item = itemswithmarkup[i].Item1;
                var localprice = hero.location.CostOf(item);
                string discountInfo="";
                if (localprice > item.Price) discountInfo = "Price HIGHER than usual.";
                else if (localprice < item.Price) discountInfo = "Price LOWER than usual.";
                localPriceList.Add($"{item.Name} - {localprice:f2} Space Dollar    "+discountInfo);
            }
            return localPriceList;
        }

        private List<string> GetPlayerItems(List<Item> itemswithoutmarkup)
        {
            List<string> PlayerPriceList = new List<string>();
            for (int i = 0; i < itemswithoutmarkup.Count; i++)
            {
                var item = itemswithoutmarkup[i];
                var localprice = hero.location.CostOf(item);
                string discountInfo = "";
                if (localprice > item.Price) discountInfo = "Price HIGHER than usual.";
                else if (localprice < item.Price) discountInfo = "Price LOWER than usual.";
                PlayerPriceList.Add($"{item.Name} - {localprice:f2} Space Dollar    "+discountInfo);
            }
            return PlayerPriceList;
        }

        private void TravelMenu()
        {
            int selected;
            do
            {
                HUD();
                selected = UI.SelectionMenu(locations.ConvertAll(new Converter<ILocation, string>(x => $"Distance: {x.DistanceTo(hero.location):f2} l.y.   Planet Name: " + x.Name)));
                if (selected == -1) break;
                ILocation destination = locations[selected];
                if (destination.Name==hero.location.Name)
                {
                    Utility.PromptForInput($"You are already on {hero.location.Name}. Hit any key to continue.");
                    continue;
                }
                HUD();
                var nullableInput = Utility.PromptForInput("How fast in wrap " +
                            "factor would you like to go?", 0.0, 9.6);
                if (nullableInput != null)
                {
                    double warpSpeed = (double)nullableInput;
                    HUD();
                    hero.TravelEstimate(destination, warpSpeed, out double distance,
                                        out double speed, out double TimeNeed, out double FuelNeed);
                    selected = UI.SelectionMenu(new List<string>() { "Travel", "Abort" },
                        bottomprompt: $"Time Need: {TimeNeed:f5} years   Fuel Need: {FuelNeed:f2} Unit of Dilithium");
                    if (selected == 0)
                    {
                        hero.TravelTo(destination, warpSpeed);
                        break;
                    }
                    else break;
                }
            } while (selected != -1);
        }

        private void LoadGame()
        {
            hero = Utility.ReadFromJsonFile<Player>(fileName);
            //To properly load the game, make the player travel to same location saved
            ILocation loadLocation = locations.Find(x => x.Name == hero.location.Name);
            hero.TravelTo(loadLocation, 1.0);
        }

        private void SaveGame()
        {
            Utility.WriteToJsonFile<Player>(fileName, hero);
        }
    }
}