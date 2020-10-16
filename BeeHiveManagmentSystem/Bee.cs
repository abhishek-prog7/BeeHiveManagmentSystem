using System;
using System.Collections.Generic;
using System.Text;

namespace BeeHiveManagmentSystem
{
    abstract class Bee
    {
        public string Job { get; private set; }
        public abstract float CostPerShift { get; }
        public Bee(string bee)
        {
            Job = bee;
        }
        public void WorkTheNextShift ()
        {
            if(HoneyWalt.ConsumeHoney(CostPerShift))
            {
                DoJob();
            }
        }
        protected abstract void DoJob();
    }
}
