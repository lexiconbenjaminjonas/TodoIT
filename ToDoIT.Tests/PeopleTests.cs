﻿using System;
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
            people.Clear();
            
            //Act
            int before = people.Size();
            people.CreatePerson("First", "Last");
            var after = people.Size();
            
            //Assert
            Assert.Equal(before + 1,after);
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
            // Assert.NotEqual(peoplesizeBeforeReset,p.Size());
            Assert.All(p.FindAll(),a=>Assert.Null(a));
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

            var foundPerson = people.FindById(-1);
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