using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge1;
using Challenge1_Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge1

{
    [TestClass]
    public class Challenge1_Tests
    {

        private MenuItemRepo _repo;
        private MenuItem _menuItem;

        [TestInitialize]

        public void Arrange()
        {
            _repo = new MenuItemRepo();
            _menuItem = new MenuItem(1, "Test Meal", "Test meal description", null, 3.99);
            _repo.AddMenuItemToList(_menuItem);
            
        }

        //ADD
        [TestMethod]
        public void AddMenuItemToList_ShouldGetNotNull()
        {
            //Arrange
            MenuItemRepo menuItemRepo = new MenuItemRepo();
            MenuItem menuItem = new MenuItem();
            menuItem.MealNumber = 1;

            //Act
            menuItemRepo.AddMenuItemToList(menuItem);
            MenuItem menuItemCheck = menuItemRepo.GetMenuItemByMealNumber(1);
            
            //Assert
            Assert.IsNotNull(menuItemCheck);

            //PASS
        }
        //Read
        [TestMethod]
        public void GetListOfMealsAndCount_ShouldReturnEqualToOne()
        {
            //Arrange
            //Using test initialization
            List<MenuItem> listOfMeals = _repo.GetMenuItemList();

            //Act
            int count = listOfMeals.Count();

            //Assert
            Assert.AreEqual(1, count);

            //Pass

        }

        //Update
        [TestMethod]
        public void UpdateMeal_ShouldReturnTrue()
        {
            //Arrange
            //test initialize
            MenuItem newMenuItem = new MenuItem(1, "Update Test Meal", "Update Test meal description", null, 6.66);

            //Act
            bool updateMenuItem = _repo.UpdateMenuItem(_menuItem, newMenuItem);

            //Assert
            Assert.IsTrue(updateMenuItem);

            //Pass

        }

        [TestMethod]
        public void DeleteMeal_ShouldReturnTrue()
        {
            //Arrange
            //test initialize

            //Act
            bool deleteMenuItem = _repo.DeleteMenuItemByMealNumber(1);

            //Assert
            Assert.IsTrue(deleteMenuItem);

            //Pass


        }
    }
}
