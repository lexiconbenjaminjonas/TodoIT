using TodoIT.Data;
using TodoIT.Model;
using Xunit;

namespace ToDoITTEsts
{

    public class PeopleTests
    {
        
        [Fact]
        public void SizeTest()
        {
            //Set up
            People sut = new People();
            sut.Clear();
            
            //Act
            int before = sut.Size();
            sut.CreatePerson("First", "Last");
            var after = sut.Size();
            
            //Assert
            Assert.Equal(before + 1,after);
        }
        
        [Fact]
        public void CreatePersonTest()
        {

            People sut = new People();
            string FirstName = "Reo";
            string LastName = "Emanuell";
            
            Person person = sut.CreatePerson(FirstName,LastName);
            Assert.NotNull(person);
            Assert.Equal(FirstName,person.FirstName);
            Assert.Equal(LastName,person.LastName);
        }

        [Fact]
        public void ClearTest()
        {
            //Set Up
            People p = new People();
            p.CreatePerson("Steve", "Jobs");
            p.CreatePerson("Steve", "Jobs");
            p.CreatePerson("Steve", "Jobs");
            
            //Act
            p.Clear();
            
            //Assert
            Assert.All(p.FindAll(),a=>Assert.Null(a));
        }

        [Fact]
        public void FindByIDTest()
        {
            // Arrange
            
            People people = new People();
            people.Clear();
            PersonSequencer.reset();
            
            // Act
            
            people.CreatePerson("Person A","1");
            Person target = people.CreatePerson("Person B","2");
            var foundPerson = people.FindById(1);
            
            // Assert
            
            Assert.Equal(target,foundPerson);
        }
        
        [Fact]
        public void FindByID_InvalidId_Test()
        {
            People sut = new People();
            sut.CreatePerson("Person A","1");
            sut.CreatePerson("Person B","2");

            var foundPerson = sut.FindById(-1);
            Assert.Null(foundPerson);
        }

        [Fact]
        public void FindAllTest()
        {
            People sut = new People();
            sut.CreatePerson("Person A","1");
            sut.CreatePerson("Person B","2");
            var AllPeople = sut.FindAll();
            
            Assert.NotNull(AllPeople);
            Assert.NotEmpty(AllPeople);
        }
    }
}