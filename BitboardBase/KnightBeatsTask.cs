using System;

namespace BitboardBase
{
    public class KnightBeatsTask : BitboardTask
    {
        const ulong nA = 0xFeFeFeFeFeFeFeFe;
        const ulong nAB = 0xFcFcFcFcFcFcFcFc;
        const ulong nH = 0x7f7f7f7f7f7f7f7f;
        const ulong nGH = 0x3f3f3f3f3f3f3f3f;
        public override string Run(string[] data)
        {
            int x = Convert.ToInt32(data[0]);

            ulong knightBits = 1UL << x;

            ulong M = nGH & (knightBits << 6 | knightBits >> 10)
             | nH & (knightBits << 15 | knightBits >> 17)
             | nA & (knightBits << 17 | knightBits >> 15)
             | nAB & (knightBits << 10 | knightBits >> 6);

            return string.Format($"{PopCnt(M)}\r\n{M}");
        }
    }
}
