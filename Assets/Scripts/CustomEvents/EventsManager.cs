using System.Collections.Generic;
using Utils;

namespace UIEvents
{
    public class EventsManager : Singleton<EventsManager>
    {
        public class EventHandlerInfo
        {
            public IEventHandler Handler;
            public bool ShouldAutoUnsubscribe;
        }
        
        private Dictionary<string, List<EventHandlerInfo>> _handlersDictionary = new Dictionary<string, List<EventHandlerInfo>>();

        public void Subscribe(string key, IEventHandler eventHandler, bool shouldAutoUnsubscribe = false)
        {
            if (!_handlersDictionary.ContainsKey(key))
            {
                _handlersDictionary.Add(key, new List<EventHandlerInfo>());
            }
            
            _handlersDictionary[key].Add(new EventHandlerInfo
            {
                Handler = eventHandler,
                ShouldAutoUnsubscribe = shouldAutoUnsubscribe
            });
        }

        public void Unsubscribe(string key, IEventHandler eventHandler)
        {
            if (!_handlersDictionary.ContainsKey(key))
            {
                return;
            }
            
            List<EventHandlerInfo> handlers = _handlersDictionary[key];

            EventHandlerInfo targetEvent = handlers.Find(x => x.Handler == eventHandler);
            
            if (targetEvent != null)
            {
                handlers.Remove(targetEvent);
            }
        }

        public void Send(string key, params object[] pars)
        {
            if (!_handlersDictionary.ContainsKey(key))
            {
                return;
            }

            foreach (EventHandlerInfo eventHandler in _handlersDictionary[key])
            {
                eventHandler.Handler.OnEvent(key, pars);
            }

            for (int i = _handlersDictionary[key].Count - 1; i >= 0; i--)
            {
                if (_handlersDictionary[key][i].ShouldAutoUnsubscribe)
                {
                    Unsubscribe(key, _handlersDictionary[key][i].Handler);
                }
            }
        }
    }
}