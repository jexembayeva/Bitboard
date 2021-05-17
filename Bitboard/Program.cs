using BitboardBase;
using System;

namespace BitboardTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"D:\algorithms\0.BITS\";

            Console.WriteLine("-------------------KingBeats------------------------");
            ITask kingBeatsTask = new KingBeatsTask();

            Tester kingBeatsTester = new Tester(kingBeatsTask, path + @"1.Bitboard - Король\");
            kingBeatsTester.RunTests();

            Console.WriteLine("-------------------KnightBeats------------------------");
            ITask knightBeatsTask = new KnightBeatsTask();

            Tester knightBeatsTester = new Tester(knightBeatsTask, path + @"2.Bitboard - Конь\");
            knightBeatsTester.RunTests();

            Console.WriteLine("-------------------RookBeats------------------------");
            ITask rookBeatsTask = new RookBeatsTask();

            Tester rookBeatsTester = new Tester(rookBeatsTask, path + @"3.Bitboard - Ладья\");
            rookBeatsTester.RunTests();

            Console.WriteLine("-------------------BishopBeats------------------------");
            ITask bishopBeatsTask = new BishopBeatsTask();

            Tester bishopBeatsTester = new Tester(bishopBeatsTask, path + @"4.Bitboard - Слон\");
            bishopBeatsTester.RunTests();

            Console.WriteLine("-------------------QueenBeats------------------------");
            ITask queenBeatsTask = new QueenBeatsTask();

            Tester queenBeatsTester = new Tester(queenBeatsTask, path + @"5.Bitboard - Ферзь\");
            queenBeatsTester.RunTests();

            Console.ReadKey();
        }
    }
}
