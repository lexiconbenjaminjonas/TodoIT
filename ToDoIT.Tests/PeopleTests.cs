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
            People people = new People();
            
            //Act
            people.CreatePerson("First", "Last");
            var peopleSize = people.Size();
            
            //Assert
            Assert.Equal(1,peopleSize);
        }
        [Fact]
        public void CreatePersonTest()
        {

            People p = new People();
            string FirstName = "Reo";
            string LastName = "Emanuell";
            
            Person person = p.CreatePerson(FirstName,LastName);
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
            var peoplesizeBeforeReset = p.Size();
            
            //Act
            p.Clear();
            
            //Assert
            Assert.NotEqual(peoplesizeBeforeReset,p.Size());
        }
        [Fact]
        public void FindByIDTest()
        {
            People people = new People();
            people.CreatePerson("Person A","1");
            people.CreatePerson("Person B","2");

            var foundPerson = people.FindById(1);
            Assert.NotNull(foundPerson);
        }
        
        [Fact]
        public void FindByID_InvalidId_Test()
        {
            People people = new People();
            people.CreatePerson("Person A","1");
            people.CreatePerson("Person B","2");

            var foundPerson = people.FindById(2);
            Assert.Null(foundPerson);
        }

        [Fact]
        public void FindAllTest()
        {
            People people = new People();
            people.CreatePerson("Person A","1");
            people.CreatePerson("Person B","2");
            var AllPeople = people.FindAll();
            
            Assert.NotNull(AllPeople);
            Assert.NotEmpty(AllPeople);
        }
    }
}