using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArrayTest
{
    [TestClass]
    public class JaggedArrayTest
    {
        // This test is meant to show the difference between jagged & multi-dimensional arrays
        // To see the time it takes to do operations, run the test in MSTest and double click on each test result.
        // Or, double click on "AllTest"

        public TestContext TestContext { get; set; }

        private const int Iterations = 2000;

        [TestMethod]
        public void AllJaggedArrayTests()
        {
            TryMultiDimensionalArraySpeed();
            TryJaggedArraySpeed();
        }

        [TestMethod]
        public void TryMultiDimensionalArraySpeed()
        {
            var sw = new System.Diagnostics.Stopwatch();

            int[,] multiDimArray;

            sw.Start();

            for (int iterations = 0; iterations < Iterations; iterations++)
                multiDimArray = new int[2, 3];

            TestContext.WriteLine("multi dim creation: " + sw.Elapsed);

            multiDimArray = new int[2, 3];

            TestContext.WriteLine("multidimarray rank:" + multiDimArray.Rank);

            sw.Restart();

            for (int iterations = 0; iterations < Iterations; iterations++)
                for (int i = 0; i < 2; i++)
                    for (int j = 0; j < 3; j++)
                    {
                        int tmp = multiDimArray[i, j];

                        multiDimArray[i, j] = i * j;
                    }

            TestContext.WriteLine("multi dim array access & replace time: " + sw.Elapsed);

            
        }

        [TestMethod]
        public void TryJaggedArraySpeed()
        {
            int[][] jaggedArray;

            var sw = new System.Diagnostics.Stopwatch();

            for (int iterations = 0; iterations < Iterations; iterations++)
            {
                jaggedArray = new int[2][];

                for (int i = 0; i < 2; i++)
                {
                    jaggedArray[i] = new int[3];
                }
            }

            TestContext.WriteLine("jagged creation: " + sw.Elapsed);

            jaggedArray = new int[2][];

            for (int i = 0; i < 2; i++)
            {
                jaggedArray[i] = new int[3];
            }

            TestContext.WriteLine("jaggedArray rank:" + jaggedArray.Rank);

            sw.Restart();

            for (int iterations = 0; iterations < Iterations; iterations++)
                for (int i = 0; i < 2; i++)
                    for (int j = 0; j < 2; j++)
                    {
                        int tmp = jaggedArray[i][j];

                        jaggedArray[i][j] = i * j;
                    }

            TestContext.WriteLine("jagged array access & replace time: " + sw.Elapsed);
        }
    }
}
