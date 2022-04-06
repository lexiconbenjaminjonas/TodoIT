﻿using TodoIT.Data;
using TodoIT.Model;
using Xunit;

namespace ToDoITTEsts
{
    public class ToDoItemsTest
    {
        [Fact]
        public void SizeTest()
        {
            //Arrange.
            ToDoItems sut = new ToDoItems();
            //Act.
            int before = sut.Size();
            sut.CreateToDo("Test");
            var after = sut.Size();
            //Assert.
            Assert.Equal(before + 1, after);
        }

        [Fact]
        public void CreateToDoItemsTest()
        {
            //Arrange.
            ToDoItems sut = new ToDoItems();
            //Act.
            ToDo item = sut.CreateToDo("TestToDo");
            //Assert.
            Assert.NotNull(item);
            Assert.Equal("TestToDo", item.description);
        }

        [Fact]
        public void FindAllTest()
        {
            //Arrange.
            ToDoItems sut = new ToDoItems();
            sut.CreateToDo("Test1");
            //Act.
            ToDo[] test = sut.FindAll();
            //Assert.
            Assert.NotNull(test);
            Assert.NotEmpty(test);
        }

        [Fact]
        public void FindByIdTest()
        {
            //Arrange.
            ToDoItems sut = new ToDoItems();
            //Act.
            ToDo item = sut.CreateToDo("TestFindById");
            int itemId = item.todoID;
            ToDo itemReturned = sut.FindById(itemId);
            //Assert.
            Assert.Same(item, itemReturned);
        }

        [Fact]
        public void FindByIdInvalidTest()
        {
            //Arrange.
            ToDoItems sut = new ToDoItems();
            //Act.
            ToDo item = sut.CreateToDo("TestFindById");
            var itemReturned = sut.FindById(-1);
            //Assert.
            Assert.Null(itemReturned);
        }

        [Fact]
        public void ClearTest()
        {
            //Arrange.
            ToDoItems sut = new ToDoItems();
            //Act.
            ToDo item = sut.CreateToDo("TestFindById");
            sut.Clear();
            //Assert.
            Assert.All(sut.FindAll(), a => Assert.Null(a));
        }









    }
}