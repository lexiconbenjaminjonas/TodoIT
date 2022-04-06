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
            int sut_before = PersonSequencer.PersonId;
            
            // act
            PersonSequencer.reset();
            
            // Evaluate
            
            Assert.NotEqual(sut_before, PersonSequencer.PersonId);
        }

        [Fact]
        public void nextPersonIdTest()
        {
            //set up
            int sut_before = PersonSequencer.PersonId;
            
            // act
            PersonSequencer.nextPersonId();
            
            // Evaluate
            
            Assert.NotEqual(sut_before, PersonSequencer.PersonId);

        }
    }
}