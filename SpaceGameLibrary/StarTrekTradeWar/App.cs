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

        //Create a message broker to responde to events
        //MessageBroker broker = new MessageBroker();
        //EventReceiver receiver;
        //EventSender sender;

        public App()
        {
            //Initialize the game
            locations.Add(new Planet("Earth", "A pale blue dot, even at your close" +
                "distance. The birthplace of mankind.", 0, 0));
            locations.Add(new Planet("Proxima Centauri b", "The new home world of the human race ",
                0, 4.22));
            hero = new Player(locations[1]);

            //receiver = new EventReceiver(broker);
            //sender = new EventSender(broker);
            //receiver.SubscribeToEvent();
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
                //TODO: Print current statistics
                UI.CenteredString($"Location: {hero.location.Name}   Age:" +
                    $"{hero.Age}  Money: {hero.Money}  Fuel: {hero.Fuel}\n");
                //TODO: PrintActionsMenu
                int selected = UI.SelectionMenu(actions);
                endCondition = HandleSelection(selected,actions);

            } while (endCondition == EndCondition.NotEnd);

            return endCondition;
        }

        private static void AddActionOptions(List<string> actions)
        {
            actions.Add("Travel to other planets");
            actions.Add("Buy resource");
            actions.Add("Sell resource");
            actions.Add("Save game");
            actions.Add("Load game");
        }

        private EndCondition HandleSelection(int selected, List<string> actions)
        {
            switch (selected)
            {
                case -1:
                    return EndCondition.UserEnd;
                default:
                    break;
            }
            //sender.TriggerEvent<Player>(actions[selected],hero); 

            return EndCondition.NotEnd;
        }
    }
}