using System.Threading;

namespace TodoIT.Data
{
    public class PersonSequencer
    {
        private static int personId;
        public static int PersonId { get => personId; }


        public static int nextPersonId()
        {
            return ++personId;
        }

        public static void reset()
        {
            personId = 0;
        }
    }
}