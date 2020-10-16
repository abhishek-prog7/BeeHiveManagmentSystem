using System;
using System.Collections.Generic;
using System.Text;

namespace BeeHiveManagmentSystem
{
    class Queen : Bee
    {
        public const float EGGS_PER_SHIFT = 0.45f;
        private Bee[] workers = new Bee[0];
        private float eggs = 0;
        private float UnassignedWorkers = 3;
        public const float HONEY_PER_UNASSIGNED_WORKER = 0.5f;

        public string StatusReport { get; private set; }
        public override float CostPerShift { get { return 2.15f; } }
        public Queen() : base("Queen")
        {
            AssignBee("Egg Care");
            AssignBee("Honey Manufacturer");
            AssignBee("Nector Collector");
        }

        private void AddWorker(Bee worker)
        {
            if (UnassignedWorkers >= 1)
            {
                UnassignedWorkers--;
                Array.Resize(ref workers, workers.Length + 1);
                workers[workers.Length - 1] = worker;
            }
        }
        private void UpdateStatusReport()
        {
            StatusReport = $"Vault report: {HoneyWalt.StatusReport}\n" +
                $"\nEgg Count: {eggs:0.0}\n Unassigned Workers: {UnassignedWorkers:0.0}\n" +
                $"{WorkerStatus("Nector Collector")}\n{ WorkerStatus("Honey Manufacturer")}" +
                $"\n{WorkerStatus("Egg Care")}\n Total Workers: {workers.Length}";

        }
        private string WorkerStatus(string Job)
        {
            int count = 0;
            foreach (Bee worker in workers)
            {
                if (worker.Job == Job)
                    count++;
            }
            string s = "s";
            if (count == 1) s = "";
            return $"{count} {Job} bee{s}";


        }
        public void AssignBee(string Job)
        {
            switch (Job)
            {
                case "Egg Care":
                    AddWorker(new EggCare(this));
                    break;
                case "Honey Manufacturer":
                    AddWorker(new HoneyManufacturer());
                    break;
                case "Nector Collector":
                    AddWorker(new NectorCollector());
                    break;
            }
            UpdateStatusReport();
        }
        protected override void DoJob()
        {
            eggs += EGGS_PER_SHIFT;
            foreach (Bee worker in workers)
            {
                worker.WorkTheNextShift();
            }
            HoneyWalt.ConsumeHoney(HONEY_PER_UNASSIGNED_WORKER * workers.Length);
            UpdateStatusReport();
        }
        public void careForEggs(float eggsToConvert)
        {
            if (eggs >= eggsToConvert)
            {
                eggs -= eggsToConvert;
                UnassignedWorkers += eggsToConvert;
            }
        }

    }
}
