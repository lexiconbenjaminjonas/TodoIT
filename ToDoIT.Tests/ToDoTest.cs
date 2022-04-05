using System;
using Xunit;
using TodoIT.Model;

namespace ToDoITTEsts
{
    

    public class ToDoTest
    {
        [Fact]
        public void ConstructorTest()
        {

            //Arrange.
            ToDo sut = new ToDo(1, "Test");
            //Act.

            //Assert.
            Assert.Equal(1, sut.todoID);
            Assert.Equal("Test", sut.description);
        }

    }
}
