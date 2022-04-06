using TodoIT.Data;
using TodoIT.Model;
using Xunit;

namespace ToDoITTEsts
{
    public class TodoSequencerTest
    {
        [Fact]

        public void nextToDoIdTest()
        {
            //Arrange
            int sut_before = ToDoSequencer.ToDoId;

            //Act
            int sut_after = ToDoSequencer.nextToDoId();
            //Assert
            Assert.Equal(sut_before + 1, sut_after);
        }

        [Fact]

        public void resetTest()
        {
            //Arrange
            ToDoSequencer.nextToDoId();
            ToDoSequencer.nextToDoId();
            //Act
            ToDoSequencer.reset();
            //Assert
            Assert.Equal(0,ToDoSequencer.ToDoId);
        }
    }
}