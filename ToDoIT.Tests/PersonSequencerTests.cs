using TodoIT.Data;
using Xunit;

namespace ToDoITTEsts
{
    public class PersonSequencerTests
    {
        [Fact]
        
        public void ResetTest()
        {
            //set up
            PersonSequencer.nextPersonId();
            int personId_Before = PersonSequencer.PersonId;
            
            // act
            PersonSequencer.reset();
            
            // Evaluate
            
            Assert.NotEqual(personId_Before, PersonSequencer.PersonId);
        }

        [Fact]
        public void nextPersonIdTest()
        {
            //set up
            int personId_Before = PersonSequencer.PersonId;
            
            // act
            PersonSequencer.nextPersonId();
            
            // Evaluate
            
            Assert.NotEqual(personId_Before, PersonSequencer.PersonId);

        }
    }
}