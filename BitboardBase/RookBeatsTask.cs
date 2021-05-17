using System;

namespace BitboardBase
{
    public class RookBeatsTask : BitboardTask
    {
        const ulong nA = 0x101010101010101;
        const ulong firstRank = 0xff;
        public override string Run(string[] data)
        {
            int x = Convert.ToInt32(data[0]);

            ulong M = 0;
            M |= (nA << (x % 8));
            M |= (firstRank << ((x / 8) * 8));
            M &= ~((ulong)1 << x);

            return string.Format($"{PopCnt(M)}\r\n{M}");
        }
    }
}
