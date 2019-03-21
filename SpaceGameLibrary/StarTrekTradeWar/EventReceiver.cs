using System;

namespace StarTrekTradeWar
{
    internal class EventReceiver
    {
        private MessageBroker broker;

        public EventReceiver(MessageBroker broker)
        {
            this.broker = broker;
        }
        public void SubscribeToEvent()
        {
            broker.Subscribe<string[]>("on-property-changed", this.HandleEvent);
            broker.Subscribe<Player>("Save game", this.SaveGame);
            broker.Subscribe<Player>("Load game", this.LoadGame);
        }

        private void LoadGame(Player player)
        {
            player = Utility.ReadFromJsonFile<Player>("hero1.json");
        }

        private void SaveGame(Player player)
        {
            Utility.WriteToJsonFile<Player>("hero1.json", player);
        }

        private void HandleEvent(string[] testStrings)
        {
            Console.WriteLine($"Received: {string.Join(",", testStrings)}");
        }

        //actions.Add("Travel to other planets");
        //    actions.Add("Buy resource");
        //    actions.Add("Sell resource");
        //    actions.Add("Save game");
        //    actions.Add("Load game");
    }
}