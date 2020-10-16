using System;
using System.Collections.Generic;
using System.Text;

namespace BeeHiveManagmentSystem
{
    class NectorCollector:Bee
    {
        public const float NECTAR_COLLECTED_PER_SHIFT = 33.25f;
        public override float CostPerShift { get { return 1.95f; } }
        public NectorCollector() : base("Nector Collector")
        {

        }
           
        protected override void DoJob()
        {
            HoneyWalt.CollectNector(NECTAR_COLLECTED_PER_SHIFT);
        }
    }
}
