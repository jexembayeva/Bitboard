using System;

namespace BitboardBase
{
    public class QueenBeatsTask : BitboardTask
    {
        const ulong nA = 0xfefefefefefefefe;
        const ulong nH = 0x7f7f7f7f7f7f7f7f;
        const ulong firstFile = 0x101010101010101;
        const ulong firstRank = 0xff;
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

            M |= GenerateMaskForDirection(x, 7);
            M |= GenerateMaskForDirection(x, -7);
            M |= GenerateMaskForDirection(x, 9);
            M |= GenerateMaskForDirection(x, -9);

            M |= (firstFile << (x % 8));
            M |= (firstRank << ((x / 8) * 8));
            M &= ~((ulong)1 << x);

            return string.Format($"{PopCnt(M)}\r\n{M}");
        }     
    }
}
