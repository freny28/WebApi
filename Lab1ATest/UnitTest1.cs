using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab1A.Data;
using Lab1A.Models;

namespace Lab1ATest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestGetCollectionMethod()
        {
           DealershipMgr dealershipMgr = new DealershipMgr();

            var testDealerships = dealershipMgr.Get();
            int count = testDealerships.Count;
            Assert.AreEqual(4, count);

            Assert.AreEqual(1, testDealerships[0].ID);
            Assert.AreEqual("Arav", testDealerships[0].Name);

            Assert.AreEqual(2, testDealerships[1].ID);
            Assert.AreEqual("John", testDealerships[1].Name);

            Assert.AreEqual(3, testDealerships[2].ID);
            Assert.AreEqual("Alex", testDealerships[2].Name);

            Assert.AreEqual(4, testDealerships[3].ID);
            Assert.AreEqual("Jessica", testDealerships[3].Name);
        }
        [TestMethod]
        public void TestPostItemMethod()
        {
            DealershipMgr dealershipMgr = new DealershipMgr();

            Dealership dealership = new Dealership
            {
                ID = 5,
                Name = "Nelson",
                Email = "nelson5@gmail.com",
                PhoneNumber = "645-325-6778"
            };

            //dealershipMgr.Delete(dealership.ID);
            dealershipMgr.Post(dealership);

            var testDealership = dealershipMgr.Get(dealership.ID);
            Assert.AreEqual(dealership.ID, testDealership.ID);
            Assert.AreEqual(dealership.Name, testDealership.Name);
            Assert.AreEqual(dealership.Email, testDealership.Email);
            Assert.AreEqual(dealership.PhoneNumber, testDealership.PhoneNumber);

            dealershipMgr.Delete(dealership.ID);
        }
        [TestMethod]
        public void TestGetItemMethod()
        {
            DealershipMgr dealershipMgr = new DealershipMgr();

            var testDealerships = dealershipMgr.Get(2);

            Assert.AreEqual(2, testDealerships.ID);
            Assert.AreEqual("John", testDealerships.Name);
            Assert.AreEqual("john2@hotmail.com", testDealerships.Email);
            Assert.AreEqual("657-748-7788", testDealerships.PhoneNumber);
        }

        [TestMethod]
        public void TestGetItemFailMethod()
        {
            DealershipMgr dealershipMgr = new DealershipMgr();

            var testDealerships = dealershipMgr.Get(6);

            Assert.AreEqual(null, testDealerships);
        }

        [TestMethod]
        public void TestPostItemFailMethod()
        {
            DealershipMgr dealershipMgr = new DealershipMgr();
           
            Dealership dealership = new Dealership
            {
                ID = 3,
                Name = "Nelson",
                Email = "nelson5@gmail.com",
                PhoneNumber = "645-325-6778"
            };

            dealershipMgr.Post(dealership);

            var testDealership = dealershipMgr.Get(3);
           
            Assert.AreNotEqual("Nelson", testDealership.Name);

        }

    }
}
