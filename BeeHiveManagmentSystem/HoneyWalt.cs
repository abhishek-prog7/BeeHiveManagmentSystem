using System;
using System.Collections.Generic;
using System.Text;

namespace BeeHiveManagmentSystem
{
    static class HoneyWalt
    {
        const float NECTAR_CONVERSION_RATIO = .19f;
        const float LOW_LEVEL_WARNING = 10f;
        private static float honey = 25f;
        private static float nector = 100f;

        public static string StatusReport { get
            {
                string status = $"{honey:0.0} units of honey\n" + $"{nector:0.0} units of nector";
                string warning = "";
                if (honey < LOW_LEVEL_WARNING)
                {
                   warning+= "LOW HONEY - ADD A HONEY MANUFACTURER";
                } else if( nector <LOW_LEVEL_WARNING)
                {
                    warning += "LOW NECTOR - ADD A NECTOR MANUFACTURER";
                }
                return status+warning; }
        }
        
        public static void CollectNector(float amount)
        {
            if (amount > 0f)
                nector += amount;
        }
        public static void ConvertNectorToHoney(float amount)
        {
            float nectorToConvert = amount;
            if (nectorToConvert > nector)
                nectorToConvert = nector;
            nector -= nectorToConvert;
            honey+=  nectorToConvert* NECTAR_CONVERSION_RATIO;
        }
        public static bool ConsumeHoney(float amount)
        {
            if(amount>=honey)
            {
                honey-= amount;
                return true;
            }
            return false;
          
            
        }
    }
}
