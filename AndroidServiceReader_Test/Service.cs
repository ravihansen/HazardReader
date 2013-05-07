using System;
using System.Collections.Generic;
using HazardReaderCore.Business;
using HazardReaderCore.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AndroidServiceReader_Test
{
    [TestClass]
    public class ServiceTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            IReaderBL core = new ReaderBL();
            List<GeoHazard> geoHazards = new List<GeoHazard>();
            try
            {
                geoHazards = core.GetGeoHazard();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Assert.IsTrue(geoHazards.Count > 0);
        }
    }
}
