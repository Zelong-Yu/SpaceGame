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
        public App()
        {
            //Initialize the game
            locations.Add(new Planet("Earth", "A pale blue dot, even at your close" +
                "distance. The birthplace of mankind.", 0, 0));
            locations.Add(new Planet("Proxima Centauri b", "The new home world of the human race ",
                0, 4.22));
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
            actions.Add("Travel to other planets");
            actions.Add("Buy resource");
            actions.Add("Sell resource");
            actions.Add("Save game");
            actions.Add("Load game");
            EndCondition endCondition = EndCondition.NotEnd;
            do
            {
                Console.Clear();
                //TODO: Print current statistics
                UI.CenteredString($"Location: {hero.location.Name}   Age:" +
                    $"{hero.Age}  Money: {hero.Money}  Fuel: {hero.Fuel}\n");
                //TODO: PrintActionsMenu
                int selected = UI.SelectionMenu(actions);
                if (selected == -1) endCondition = EndCondition.UserEnd;

            } while (endCondition == EndCondition.NotEnd);

            return endCondition;
        }
    }
}