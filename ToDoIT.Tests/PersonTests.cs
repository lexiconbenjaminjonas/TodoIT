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
            Person p = new Person(0,firstName, lastName);
            
            Assert.Equal(firstName, p.FirstName);
            Assert.Equal(lastName, p.LastName);
            Assert.Equal(0,p.PersonId);
        }
        
        [Fact]
        public void Constructor_EmptyArguments()
        {
            string firstName = "";
            string lastName = "";
            Person p = new Person(0,firstName, lastName);
            
            Assert.Equal("Steve", p.FirstName);
            Assert.Equal("Jobs", p.LastName);
            Assert.Equal(0,p.PersonId);
        }
    }
}