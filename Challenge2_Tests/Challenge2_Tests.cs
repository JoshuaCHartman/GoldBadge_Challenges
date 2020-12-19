using System;
using System.Collections.Generic;
using System.Linq;
using Challenge2_Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Type = Challenge2_Library.Type;

namespace Challenge2_Tests
{
    [TestClass]
    public class Challenge2_Tests
    {

        // TESTS : ADD, READ, DEQUEUE

        private Claim _claim;
        private Claim _claim1;
        private ClaimRepo _repo;
        Queue<Claim> _queuOfClaims;

        [TestInitialize]
        public void Arrange()
        {
            _claim = new Claim(1, Type.Car, "Test Description", 666, Convert.ToDateTime("2018, 04, 25"), Convert.ToDateTime("2018/ 04/ 27"), true);
            _claim1 = new Claim(2, Type.Theft, "Test Description1", 000, Convert.ToDateTime("2018, 04, 25"), Convert.ToDateTime("2018/ 04/ 27"), false);
            _repo = new ClaimRepo();
            
        }

        // ADD & READ
        [TestMethod]
        public void ReadQueueAndAddOneToQueue_ShouldEqualOne()
        {
            //Arrange
            //Test Initialize
            
            //Act 
            _queuOfClaims = _repo.ShowQueueofClaims(); //Read
            _repo.AddClaimToQueue(_claim); //Add
            int claimCount = _queuOfClaims.Count(); 

            //Assert
            Assert.AreEqual(1, claimCount);

            //PASS
        }

        // DEQUEU
        [TestMethod]
        public void Dequeu_ShouldBeNotEqual()
        {
            //Arrange
            //Test Initialize
            _queuOfClaims = _repo.ShowQueueofClaims();
            _repo.AddClaimToQueue(_claim);
            _repo.AddClaimToQueue(_claim1);

            //Act 
            int claimCount1 = _queuOfClaims.Count();

            _queuOfClaims.Dequeue();
            int claimCount2 = _queuOfClaims.Count();

            //Assert
            Assert.AreNotEqual(claimCount1, claimCount2);

            //PASSED
        }
    }
}
