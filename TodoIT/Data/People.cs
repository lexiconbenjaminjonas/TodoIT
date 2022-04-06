using System;
using TodoIT.Model;

namespace TodoIT.Data
{
    public class People
    {
        private static Person[] _persons = new Person[0];

        public int Size()
        {
            return _persons.Length;
        }

        public Person[] FindAll()
        {
            return _persons;
        }

        public Person FindById(int personId)
        {
            foreach (var person in _persons)
            {
                if (person.PersonId == personId)
                {
                    return person;
                }
            }
            return null;
        }

        public Person CreatePerson(string firstName, string lastName)
        {
            Person p = new Person(PersonSequencer.nextPersonId(),firstName,lastName);
            Array.Resize(ref _persons,_persons.Length + 1);
            _persons[_persons.Length - 1] = p;
            return p;
        }
        
        public void Clear()
        {
            Array.Resize(ref _persons,0);
        }

        public void removePerson(Person personToRemove)
        {
            int ignore=Array.FindIndex(_persons,item => item==personToRemove);
            Person[] tempArray = new Person[_persons.Length - 1];
            Array.Copy(_persons, 0, tempArray, 0, ignore);
            Array.Copy(_persons, ignore + 1, tempArray, ignore, tempArray.Length - ignore);

            _persons = tempArray;
        }
    }
}