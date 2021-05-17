using System;

namespace BitboardBase
{
    public class BishopBeatsTask : BitboardTask
    {
        public override string Run(string[] data)
        {
            int x = Convert.ToInt32(data[0]);

            ulong M = 0;
            M |= GenerateMaskForDirection(x, 7);
            M |= GenerateMaskForDirection(x, -7);
            M |= GenerateMaskForDirection(x, 9);
            M |= GenerateMaskForDirection(x, -9);

            return string.Format($"{PopCnt(M)}\r\n{M}");
        }
    }
}
