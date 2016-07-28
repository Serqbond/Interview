using System;
using System.Collections.Generic;
using System.Threading;

namespace Core.TContexts
{
    public class BaseContext
    {
        /// <summary>
        /// method to do anything inside test code
        /// </summary>
        /// <typeparam name="P"></typeparam>
        /// <param name="action"></param>
        /// <returns></returns>
        public P DoAction<P>(Action action) where P : new()
        {
            action();
            return Instance<P>();
        }

        /// <summary>
        /// returns test context instance
        /// </summary>
        /// <typeparam name="P"></typeparam>
        /// <returns></returns>
        public static P Instance<P>() where P : new()
        {
            return new P();
        }

        /// <summary>
        /// looping in test context
        /// </summary>
        /// <typeparam name="P"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public P Each<P, T>(IEnumerable<T> items, Action<T> action) where P : new()
        {
            foreach (T item in items)
            {
                action(item);
            }

            return Instance<P>();
        }        

        /// <summary>
        /// explicit waits
        /// </summary>
        /// <typeparam name="P"></typeparam>
        /// <param name="waitTime"></param>
        /// <returns></returns>
        public P Wait<P>(int waitTime = 3000) where P : new()
        {
            this.Wait(waitTime);
            return Instance<P>();
        }

        /// <summary>
        /// verifies expected result inside test context
        /// </summary>
        /// <typeparam name="P"></typeparam>
        /// <param name="action"></param>
        /// <returns></returns>
        public P Verify<P>(Action action) where P : new()
        {
            action();
            return Instance<P>();
        }
        
        private void Wait(int milisecs)
        {
            Thread.Sleep(milisecs);
        }        
    }
}
