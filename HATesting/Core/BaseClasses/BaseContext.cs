using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Core.TContexts
{
    public class BaseContext
    {
        protected IWebDriver driver;

        public BaseContext(IWebDriver driver) { this.driver = driver; }        

        /// <summary>
        /// looping in test context
        /// </summary>
        /// <typeparam name="P"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public P Each<P, T>(IEnumerable<T> items, Action<T> action, P obj) 
        {
            foreach (T item in items)
            {
                action(item);
            }

            return obj;
        }

        /// <summary>
        /// explicit waits
        /// </summary>
        /// <typeparam name="P"></typeparam>
        /// <param name="waitTime"></param>
        /// <returns></returns>
        public P Wait<P>(P obj, int waitTime = 3000) 
        {
            this.Wait(waitTime);
            return obj;
        }

        /// <summary>
        /// verifies expected result inside test context
        /// </summary>
        /// <typeparam name="P"></typeparam>
        /// <param name="action"></param>
        /// <returns></returns>
        public P Verify<P>(Action action, P obj)
        {
            action();
            return obj;
        }

        private void Wait(int milisecs)
        {
            Thread.Sleep(milisecs);
        }
    }
}
