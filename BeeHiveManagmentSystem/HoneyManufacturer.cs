using System;
using System.Collections.Generic;
using System.Text;

namespace BeeHiveManagmentSystem
{
    class HoneyManufacturer:Bee
    {
        const float NECTAR_PROCESSED_PER_SHIFT = 33.15f;
        public override float CostPerShift { get { return 1.7f; } }
        public HoneyManufacturer() : base("Honey Manufacturer")
        {

        }

        protected override void DoJob()
        {
            HoneyWalt.ConvertNectorToHoney(NECTAR_PROCESSED_PER_SHIFT);
        }
    }
}
