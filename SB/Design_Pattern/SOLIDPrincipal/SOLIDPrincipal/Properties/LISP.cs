using System;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.InteropServices;

namespace SOLIDPrincipal.OCP
{
	public interface IMyDictonary<TKey, TValue> where TKey : IEquatable<TKey>
	{
		void Add(TKey key, TValue value);
		TValue Get(TKey key);
	}

    public class MyDictonary<TKey, TValue> : IMyDictonary<TKey, TValue>,IDisposable where TKey:IEquatable<TKey>
    {
        private Hashtable container;

        private object myObject = new object();

        public MyDictonary()
        {
            container = new Hashtable();

        }

        public void Add(TKey key, TValue value)
        {
            lock (myObject)
            {
                container.Add(key,value);

            }
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                Dispose();
            }
        }
        public void Dispose()
        {
            if (container!=null)
            {
                container.Clear();
                container = null;
            }
        }

        public TValue Get(TKey key)
        {
            foreach (var aKey in container.Keys)
            {
                try
                {
                    if (IsKeyAvailable(key))
                    {
                        return (TValue)container[aKey];
                    }
                }
                catch(KeyNotFoundException ex)
                {
                    throw ex;
                }
                
            }

            return default(TValue);

        }


        public void Update(TKey key, TValue value)
        {
            try
            {
                if (IsKeyAvailable(key))
                {
                    container[key] = value;
                }
            }
            catch (KeyNotFoundException ex)
            {
                throw ex;
            }
        }

        private bool IsKeyAvailable(TKey key)
        {
            bool isKeyAvaiable=false;
            foreach (var aKey in container.Keys)
            {
                if (aKey.Equals(key))
                {
                    isKeyAvaiable = true;
                    break;
                    
                }
                
            }
            return isKeyAvaiable;
        }

    }

}





