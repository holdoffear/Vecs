using System;
using System.Threading;

namespace Vecs
{
    public static class IdGenerator
    {
        private static long PreviousTimeStamp = DateTime.UtcNow.Ticks;
        public static long Guid
        {
            get
            {
                long tempPreviousTimeStamp;
                long guid;
                do
                {
                    tempPreviousTimeStamp = PreviousTimeStamp;
                    long currentTimeStamp = DateTime.UtcNow.Ticks;
                    guid = Math.Max(currentTimeStamp, tempPreviousTimeStamp + 1);
                }
                while (Interlocked.CompareExchange(ref PreviousTimeStamp, guid, tempPreviousTimeStamp) != tempPreviousTimeStamp);

                return guid;
            }
        }
    }
}