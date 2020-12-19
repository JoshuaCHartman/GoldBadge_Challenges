using System;
using Challenge3_Library;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge3_Tests
{
    [TestClass]
    public class Challenge3_Tests
    {
        //Tests Add, Read (from Repo)
        //Tests Check string if can convert to int, dictionary.ContainsKey, var object = dictionary[value], badgeToEdit.ListOfDoors.Contains(inputDoorNumber), list.clear


        private Badge _badge;
        private Badge _badge1;
        List<string> _list;
        private string _door1;
        private string _door2;
        private BadgeRepo _repo;
        Dictionary<int, Badge> _dictionary;

        [TestInitialize]
        public void Arrange()
        {
            _door1 = "100";
            _door2 = "200";
            _list = new List<string>();
            _list.Add(_door1);
            _list.Add(_door2);

            _badge = new Badge(1, _list);
            _badge1 = new Badge(2, _list);

            _repo = new BadgeRepo();


        }

        //Read and Add
        [TestMethod]
        public void ReadDictionaryAndAddOneToDictionary_ShouldEqualOne()
        {
            //Arrange
            //Test initialize

            //Act
            _dictionary = _repo.ShowAllBadges(); //Read
            _dictionary.Add(1, _badge); //Add
            int pairCount = _dictionary.Count();

            //Assert
            Assert.AreEqual(1, pairCount);

            //PASS

        }

        [TestMethod]
        public void CheckIfInputCanBeConvertedToInteger_ShouldBeEqual() // int.TryParse used to determine if userinput can be converted from string to int as part of exception testing
        {
            // int.TryParse used to determine if userinput can be converted from string to int as part of exception testing
            
            //Arrange
            string inputID;
            int num = -1;

            //Act
            inputID = "3";
            int.TryParse(inputID, out num);

            //Assert
            Assert.AreEqual(3, num);

            //PASS
        }

        [TestMethod]
        public void CheckIfDictionaryContainsKey_ShouldBeTrue()
        {
            //ContainsKey used to find pair by key

            //Arrange
            //Test initialize
            _dictionary = _repo.ShowAllBadges();
            _dictionary.Add(1, _badge);


            //Act
            bool hasKey = _dictionary.ContainsKey(1);
            bool doesNotHaveKey = _dictionary.ContainsKey(2);

            //Assert
            Assert.IsTrue(hasKey);
            Assert.IsFalse(doesNotHaveKey);

            //PASS

        }

        [TestMethod]
        public void CheckIfDictionaryReturnsObjectValue_ShouldBeTrue()
        {
            // dictionary.[key] used to return value, in UI is badge object to edit

            //Arrange
            //Test initialize
            _dictionary = _repo.ShowAllBadges();
            _dictionary.Add(1, _badge);

            //Act
            var value = _dictionary[1];

            //Assert
            Assert.AreEqual(_badge, value);

            //PASS
        }
        [TestMethod]
        public void CheckIfListReturnsStringValue_ShouldBeTrue()
        {
            // list.Contains(string) used in UI to find door containing string of door number

            //Arrange
            //Test initialize
            _dictionary = _repo.ShowAllBadges();
            _dictionary.Add(1, _badge);
            var value = _dictionary[1];

            //Act
            bool containsString = value.ListOfDoors.Contains("100");
            bool doesNotContainString = value.ListOfDoors.Contains("300");

            //Assert
            Assert.IsTrue(containsString);
            Assert.IsFalse(doesNotContainString);

            //PASS
        }
        [TestMethod]
        public void CheckIfListCleared_ShouldBeNotEqual()
        {
            // list.Clear used in UI to delete all doors from badge

            //Arrange
            //Test initialize
            _dictionary = _repo.ShowAllBadges();
            _dictionary.Add(1, _badge);
            var value = _dictionary[1];

            //Act
            var listCount = value.ListOfDoors.Count();
            value.ListOfDoors.Clear();
            var listClearedCount = value.ListOfDoors.Count();

            //Assert
            Assert.AreNotEqual(listCount, listClearedCount);

            //PASS
        }

    }
}
