using System;

namespace BitboardBase
{
    public abstract class BitboardTask : ITask
    {
        public abstract string Run(string[] data);
        public int PopCnt(ulong bits)
        {
            int cnt = 0;
            while (bits > 0)
            {
                cnt++;
                bits &= bits - 1;
            }
            return cnt;
        }
        public ulong GenerateMaskForDirection(int x, int shift)
        {
            ulong M = 0;
            for (int i = DistanceToEdge(x, shift); i > 0; i--)
            {
                x += shift;
                M |= (ulong)1 << x;
            }

            return M;
        }
        public int DistanceToEdge(int x, int shift)
        {
            return shift switch
            {
                1 => 7 - x % 8,
               -1 => x % 8,
                8 => 7 - x / 8,
               -8 => x / 8,
                9 => Math.Min(7 - x % 8, 7 - x / 8),
               -7 => Math.Min(7 - x % 8, x / 8),
               -9 => Math.Min(x % 8, x / 8),
                7 => Math.Min(x % 8, 7 - x / 8),
                _ => -1,
            };
        }
    }
}
