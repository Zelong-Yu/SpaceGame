using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrekTradeWar
{
    public class MessageBroker
    {
        private IDictionary<string, Dictionary<Guid, Delegate>> registrations = new Dictionary<string, Dictionary<Guid, Delegate>>();
        public Guid Subscribe<T>(string eventName, Action<T> callback)
        {
            var id = Guid.NewGuid();
            if (registrations.ContainsKey(eventName))
            {
                registrations[eventName][id] = callback;
            }
            else
            {
                registrations.Add(eventName, new Dictionary<Guid, Delegate> { { id, callback } });
            }
            return id;
        }

        public void Unsubscribe(string eventName, Guid id)
        {
            registrations[eventName].Remove(id);
        }

        public void Unsubscribe(Guid id)
        {
            foreach (var eventName in registrations.Keys)
            {
                Unsubscribe(eventName, id);
            }
        }

        public void Notify<T>(string eventName, T args)
        {
            foreach (var set in registrations[eventName])
            {
                set.Value.DynamicInvoke(args);
            }
        }
    }
}
