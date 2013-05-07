using System;
using HazardReaderCore;
using HazardReaderCore.Business;

namespace AndroidServiceReader.Application
{
    public class HazardTypesAL
    {
        public static dynamic GetHazards(HazardType hazardType)
        {
            IHazardTypeReaderBL core = new HazardTypeReaderBL();
            dynamic hazard = null;
            try
            {
                switch (hazardType)
                {
                    case HazardType.Geo:
                        hazard = core.GetGeoHazard();
                        break;
                    case HazardType.Avalanche:
                        hazard = core.GetAvalancheHazard();
                        break;
                    case HazardType.IceLayer:
                        hazard = core.GetIceHazard();
                        break;
                    case HazardType.SnowSurface:
                        hazard = core.GetSnowHazard();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return hazard;
        }
    }
}