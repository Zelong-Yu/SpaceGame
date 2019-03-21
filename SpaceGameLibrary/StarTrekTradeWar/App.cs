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

        //Create a message broker to responde to events
        //MessageBroker broker = new MessageBroker();
        //EventReceiver receiver;
        //EventSender sender;

        public App()
        {
            Initialize();

            //receiver = new EventReceiver(broker);
            //sender = new EventSender(broker);
            //receiver.SubscribeToEvent();
        }

        private void Initialize()
        {
            var TransAlum = new Item("Transparent aluminum", 100M, "Ultra-strong transparent metal essential to build a spaceship.");
            var Biogel = new Item("Bio-mimetic gel", 50M, "Volatile substance highly sought after for use in illegal activities, such as genetic experimentation and biological weapons development.");
            var silk = new Item("Tholian silk", 10M, "valuable fabric");
            //Initialize the game
            locations.Add(new Planet("Earth", "The birthplace of Homo sapiens. Once blue but " +
                "now pale yellow as a result of human stupidity.", 0, 0, new List<(Item, decimal)>() {
                    (silk, 0.5M),
                    (Biogel, 2M)}));
            locations.Add(new Planet("Proxima Centauri b", "The new home world of the human race ",
                4.22, 0, new List<(Item, decimal)>() {
                    ( TransAlum, 1M),
                    ( Biogel,1M)
                }));
            locations.Add(new Planet("GJ 273b", "One of the most Earth-like planets ever found.",
                11.61460079, 4.227368972, new List<(Item, decimal)>() {
                    ( silk, 2M),
                    ( TransAlum,0.5M)
                }));
            hero = new Player(locations[0]);
        }

        public void Run()
        {
            //Display entrance title
            Story.DisplayHeader();
            // TODO: Display story plot

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
                endCondition = HandleSelection(selected);

            } while (endCondition == EndCondition.NotEnd);

            return endCondition;
        }

        private void HUD()
        {
            Console.Clear();
            //Print current statistics
            UI.CenteredString($"Location: {hero.location.Name}   Age:" +
                $"{hero.Age:f2} yrs old  Money: {hero.Money} Space Dollor   Fuel: {hero.Fuel:f2} Unit of Dilithium\n");
            UI.CenteredString($"{hero.location.Description}");
        }

        private static void AddActionOptions(List<string> actions)
        {
            actions.Add("Travel to other planets");
            actions.Add("Check Planet Market/ Buy");
            actions.Add("Check inventory/ Sell");
            actions.Add("Refuel");
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
            //sender.TriggerEvent<Player>(actions[selected],hero); 

            return EndCondition.NotEnd;
        }

        private void RefuelMenu()
        {
            throw new NotImplementedException();
        }

        private void SellMenu()
        {
            throw new NotImplementedException();
        }

        private void BuyMenu()
        {
            throw new NotImplementedException();
            //IDictionary<Item, decimal> items = ((Planet)hero.location).ItemMarkUps;
            //Console.Clear();
            //PrintItems(items);
            //var itemIndex = Utility.PromptForInput("Which item would you like to buy: ", 1, items.Count);
            //if (!itemIndex.cancelled)
            //{
            //    hero.BuyItem(items[itemIndex.input - 1]);
            //}
        }

        //private void PrintItems(IDictionary<Item, decimal> items)
        //{
        //    for (int i = 0; i < items.Count; i++)
        //    {
        //        var item = items.;
        //        var cost = ((Planet)hero.location).CostOf(item);
        //        Console.WriteLine($"{i + 1}. {item.name} - {cost:f2} cr");
        //    }
        //}

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
        }

        private void SaveGame()
        {
            Utility.WriteToJsonFile<Player>(fileName, hero);
        }
    }
}