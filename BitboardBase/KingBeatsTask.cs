using System;

namespace BitboardBase
{
    public class KingBeatsTask : BitboardTask
    {
        const ulong nA = 0xfefefefefefefefe;
        const ulong nH = 0x7f7f7f7f7f7f7f7f;
        public override string Run(string[] data)
        {
            int x = Convert.ToInt32(data[0]);

            ulong K = 1UL << x;
            ulong Ka = nA & K;
            ulong Kh = nH & K;
            ulong M = ~K & (
                (Ka << 7) | (K << 8) | (Kh << 9) |
                (Ka >> 1) | (Kh << 1) |
                (Ka >> 9) | (K >> 8) | (Kh >> 7));

            return string.Format($"{PopCnt(M)}\r\n{M}");
        }
    }
}
