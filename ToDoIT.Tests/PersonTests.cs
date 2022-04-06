using System;
using TodoIT.Model;
using Xunit;

namespace ToDoITTEsts
{
    public class PersonTest
    {

        [Fact]
        public void Constructor_PropperArguments()
        {
            string firstName = "Jonas";
            string lastName = "Swansson";
            Person sut = new Person(0,firstName, lastName);
            
            Assert.Equal(firstName, sut.FirstName);
            Assert.Equal(lastName, sut.LastName);
            Assert.Equal(0,sut.PersonId);
        }
        
        [Fact]
        public void Constructor_EmptyArguments()
        {
            string firstName = "";
            string lastName = "";
            Person sut = new Person(0,firstName, lastName);
            
            Assert.Equal("Steve", sut.FirstName);
            Assert.Equal("Jobs", sut.LastName);
            Assert.Equal(0,sut.PersonId);
        }
    }
}