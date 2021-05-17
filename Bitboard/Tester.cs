using BitboardBase;
using System;
using System.Diagnostics;
using System.IO;

namespace BitboardTest
{
    public class Tester
    {
        private ITask _task;
        private string _path;

        public Tester(ITask task, string path)
        {
            _task = task;
            _path = path;
        }

        public void RunTests()
        {
            int nr = 0;
            while (true)
            {
                string inFile = $"{_path}\\test.{nr}.in";
                string outFile = $"{_path}\\test.{nr}.out";

                if (!File.Exists(inFile) || !File.Exists(outFile))
                {
                    break;
                }

                var sw = new Stopwatch();
                sw.Start();
                bool result = RunTest(inFile, outFile);
                sw.Stop();

                Console.WriteLine($"Test #{nr} - " + result + " " + sw.ElapsedMilliseconds + "ms");
                nr++;
            }
        }

        private bool RunTest(string inFile, string outFile)
        {
            try
            {
                string[] data = File.ReadAllLines(inFile);
                string expect = File.ReadAllText(outFile).Trim();
                string actual = _task.Run(data);

                return actual == expect;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}