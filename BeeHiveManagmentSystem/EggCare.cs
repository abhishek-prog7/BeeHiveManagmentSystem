using System;
using System.Collections.Generic;
using System.Text;

namespace BeeHiveManagmentSystem
{
    class EggCare:Bee
    {
        const float CARE_PROGRESS_PER_SHIFT = 0.15f;
        public override float CostPerShift { get { return 1.35f; } }
        private Queen queen;
        public EggCare(Queen queen):base("Egg care")
        {
            this.queen = queen;
        }
        protected override void DoJob()
        {
            queen.careForEggs(CARE_PROGRESS_PER_SHIFT);
        }
    }
}
