using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace HelloMVC.Class
{
    public class Counter
    {
        //private
        //internal
        //protected
        //public  use PasscallCase
        private int count; //Field       
        /*
        private string _modelName; // private using CamelCasee  model-type-description=>kebub case        
        public string  Model  // public use PasscalCase
        {
            get
            {
                return _modelName;
            }
            set
            {
                _modelName = value;
            }
        }
        */
        public string Model { get; set; } // auto-implementd property
        //public string Model { get; private set; } // auto-implementd property
        //public string Model { get; set; } = "999"

        // constructor
        public Counter()
        {
            count = 0;
        }
        public void Click()
        {
            count++;
        }
        /*
        public void setCount(int value)
        {
            count=value;
        }
        public int getCount()
        {
            return count;
        }
        */
        // properties Syntantic sugar
        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
            }
        }
        protected int protected_getCount() // allow child class
        {
            return count;
        }
        internal int internal_getCount() // allow class in same project
        {
            return count;
        }
    }
    // using
    // var C1=new Counter();
    // C1.Click();
    // Console.WriterLine(C1.getCount()); // 3
}
