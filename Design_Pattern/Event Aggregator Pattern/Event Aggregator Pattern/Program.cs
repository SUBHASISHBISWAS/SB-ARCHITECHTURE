using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Aggregator_Pattern
{

    public interface IEventAggregator
    {
        void Publish<TEvent>(TEvent eventToPublish);
        void Suscribe(Object suscriber);
    }

    public interface ISuscriber<T>
    {
        void  OnEvent(T e);
    }
    class SimpleEventAggregator:IEventAggregator
    {
        //Hold refernce list of Suscriber of each type of Message
        private readonly Dictionary<Type, List<WeakReference>> _eventSuscribersList = new Dictionary<Type, List<WeakReference>>();
        private readonly object _lock = new object();
        public void Publish<TEvent>(TEvent eventToPublish)
        {
            throw new NotImplementedException();
        }

        public void Suscribe(object suscriber)
        {

            lock (_lock)
            {
                var suscribersTypes = suscriber.GetType().GetInterfaces().
                Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ISuscriber<>));

                var weakReference = new WeakReference(suscriber);

                foreach (var suscriberType in suscribersTypes)
                {

                    var suscribers = GetSuscribers(suscriberType);
                    suscribers.Add(weakReference);

                }
            }
            
        }

        private List<WeakReference> GetSuscribers(Type suscriberType)
        {
            List<WeakReference> suscribers;
            lock (_lock)
            {
                var found = _eventSuscribersList.TryGetValue(suscriberType, out suscribers);
                if (!found)
                {
                    suscribers = new List<WeakReference>();
                    _eventSuscribersList.Add(suscriberType, suscribers);
                }
            }
            return suscribers;
        }
    }
}
