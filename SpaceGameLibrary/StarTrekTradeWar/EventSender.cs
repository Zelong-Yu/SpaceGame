namespace StarTrekTradeWar
{
    internal class EventSender
    {
        private readonly MessageBroker broker;

        public EventSender(MessageBroker broker)
        {
            this.broker = broker;
        }

        public void TriggerEvent<T>(string eventName, T args)
        {
            broker.Notify(eventName, args);
        }
    }
}