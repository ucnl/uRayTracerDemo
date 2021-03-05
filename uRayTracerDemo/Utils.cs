using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uRayTracerDemo
{
    public static class Utils
    {
        public static double FitAxisStepByRange(double range)
        {
            double x = Math.Pow(10.0, Math.Floor(Math.Log10(range)));
            if (range / x >= 5)
                return x;
            else if (range / (x / 2.0) >= 5)
                return x / 2.0;
            else
                return x / 5.0;
        }      

        public static void Rise(this EventHandler handler, object sender, EventArgs e)
        {
            if (handler != null)
                handler(sender, e);
        }

        public static void Rise<TEventArgs>(this EventHandler<TEventArgs> handler,
            object sender, TEventArgs e) where TEventArgs : EventArgs
        {
            if (handler != null)
                handler(sender, e);
        }

        public static void BeginRise(this EventHandler handler, object sender, EventArgs e, AsyncCallback callback, object _object)
        {
            if (handler != null)
                handler.BeginInvoke(sender, e, callback, _object);
        }

        public static void BeginRise<TEventArgs>(this EventHandler<TEventArgs> handler,
            object sender, TEventArgs e, AsyncCallback callback, object _object)
        {
            if (handler != null)
                handler.BeginInvoke(sender, e, callback, _object);
        }


    }

}
