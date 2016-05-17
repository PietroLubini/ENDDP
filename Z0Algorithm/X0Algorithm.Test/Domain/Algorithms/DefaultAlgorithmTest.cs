using Ninject;
using NUnit.Framework;
using X0Algorithm.Domain.Algorithms;
using X0Algorithm.Domain.Extensibility.Algorithms;
using X0Algorithm.Dto;

namespace X0Algorithm.Test.Domain.Algorithms
{
    [TestFixture]
    public class DefaultAlgorithmTest : TestBase
    {
        private const string ComponentName = "DefaultAlgorithm";
        private const string IsSomebodyWonMethodName = "Expected. ";

        [TestFixtureSetUp]
        public void Initialize()
        {
            MockKernel.Bind<IDefaultAlgorithm>().To<DefaultAlgorithm>();
        }

        [Category(ComponentName)]
        [TestCase(
            false,
            new[] { 0, 1, 0 },
            new[] { 1, 0, 1 },
            new[] { 1, 0, 1 },
            TestName = IsSomebodyWonMethodName + "3x3. Draw")]
        [TestCase(
            true,
            new[] { 0, 1, 0 },
            new[] { 0, 1, 1 },
            new[] { 0, 0, 1 },
            TestName = IsSomebodyWonMethodName + "3x3. Won. 1st column. 0")]
        [TestCase(
            true,
            new[] { 1, 0, 1 },
            new[] { 1, 0, 0 },
            new[] { 1, 1, 0 },
            TestName = IsSomebodyWonMethodName + "3x3. Won. 1st column. X")]
        [TestCase(
            true,
            new[] { 0, 1, 0 },
            new[] { 1, 1, 0 },
            new[] { 1, 0, 0 },
            TestName = IsSomebodyWonMethodName + "3x3. Won. Last column. 0")]
        [TestCase(
            true,
            new[] { 1, 0, 1 },
            new[] { 0, 0, 1 },
            new[] { 0, 1, 1 },
            TestName = IsSomebodyWonMethodName + "3x3. Won. Last column. X")]
        [TestCase(
            true,
            new[] { 0, 0, 0 },
            new[] { 1, 1, 0 },
            new[] { 1, 0, 1 },
            TestName = IsSomebodyWonMethodName + "3x3. Won. 1st row. 0")]
        [TestCase(
            true,
            new[] { 1, 1, 1 },
            new[] { 0, 0, 1 },
            new[] { 0, 1, 0 },
            TestName = IsSomebodyWonMethodName + "3x3. Won. 1st row. X")]
        [TestCase(
            true,
            new[] { 1, 0, 1 },
            new[] { 1, 1, 0 },
            new[] { 0, 0, 0 },
            TestName = IsSomebodyWonMethodName + "3x3. Won. Last row. 0")]
        [TestCase(
            true,
            new[] { 0, 1, 0 },
            new[] { 0, 0, 1 },
            new[] { 1, 1, 1 },
            TestName = IsSomebodyWonMethodName + "3x3. Won. Last row. X")]
        [TestCase(
            true,
            new[] { 0, 1, 1 },
            new[] { 0, 0, 1 },
            new[] { 1, 1, 0 },
            TestName = IsSomebodyWonMethodName + "3x3. Won. Left Diagonal. 0")]
        [TestCase(
            true,
            new[] { 1, 0, 0 },
            new[] { 1, 1, 0 },
            new[] { 0, 0, 1 },
            TestName = IsSomebodyWonMethodName + "3x3. Won. Left Diagonal. X")]
        [TestCase(
            true,
            new[] { 1, 0, 0 },
            new[] { 1, 0, 0 },
            new[] { 0, 1, 1 },
            TestName = IsSomebodyWonMethodName + "3x3. Won. Right Diagonal. 0")]
        [TestCase(
            true,
            new[] { 0, 1, 1 },
            new[] { 0, 1, 1 },
            new[] { 1, 0, 0 },
            TestName = IsSomebodyWonMethodName + "3x3. Won. Right Diagonal. X")]
        [TestCase(
            false,
            new[] { 0, 1, 0, 1 },
            new[] { 1, 0, 1, 0 },
            new[] { 0, 0, 1, 1 },
            new[] { 1, 1, 0, 0 },
            TestName = IsSomebodyWonMethodName + "4x4. Draw.")]
        [TestCase(
            true,
            new[] { 1, 0, 0, 0 },
            new[] { 0, 1, 0, 1 },
            new[] { 1, 1, 0, 0 },
            new[] { 0, 0, 0, 1 },
            TestName = IsSomebodyWonMethodName + "4x4. Won. Column. 0")]
        [TestCase(
            true,
            new[] { 0, 1, 1, 1 },
            new[] { 1, 0, 1, 0 },
            new[] { 0, 0, 1, 1 },
            new[] { 1, 1, 1, 0 },
            TestName = IsSomebodyWonMethodName + "4x4. Won. Column. X")]
        [TestCase(
            true,
            new[] { 0, 1, 0, 1 },
            new[] { 1, 0, 1, 0 },
            new[] { 0, 0, 0, 0 },
            new[] { 1, 1, 0, 0 },
            TestName = IsSomebodyWonMethodName + "4x4. Won. Row. 0")]
        [TestCase(
            true,
            new[] { 1, 0, 1, 0 },
            new[] { 0, 1, 0, 1 },
            new[] { 1, 1, 1, 1 },
            new[] { 0, 0, 1, 1 },
            TestName = IsSomebodyWonMethodName + "4x4. Won. Row. X")]
        [TestCase(
            true,
            new[] { 0, 1, 1, 1 },
            new[] { 0, 0, 1, 0 },
            new[] { 1, 1, 0, 1 },
            new[] { 1, 1, 0, 0 },
            TestName = IsSomebodyWonMethodName + "4x4. Won. Left Diagonal. 0")]
        [TestCase(
            true,
            new[] { 1, 0, 0, 0 },
            new[] { 1, 1, 0, 1 },
            new[] { 0, 0, 1, 0 },
            new[] { 0, 0, 1, 1 },
            TestName = IsSomebodyWonMethodName + "4x4. Won. Left Diagonal. X")]
        [TestCase(
            true,
            new[] { 1, 0, 0, 0 },
            new[] { 1, 0, 0, 1 },
            new[] { 0, 0, 1, 0 },
            new[] { 0, 1, 1, 0 },
            TestName = IsSomebodyWonMethodName + "4x4. Won. Right Diagonal. 0")]
        [TestCase(
            true,
            new[] { 0, 1, 1, 1 },
            new[] { 0, 1, 1, 0 },
            new[] { 1, 1, 0, 1 },
            new[] { 1, 0, 0, 1 },
            TestName = IsSomebodyWonMethodName + "4x4. Won. Right Diagonal. X")]
        public void IsSomebodyWonTest(bool expected, params object[] rows)
        {
            var table = new int?[rows.Length, rows.Length];
            for (var i = 0; i < rows.Length; i++)
            {
                var row = (int[])rows[i];
                for (var j = 0; j < row.Length; j++)
                {
                    table[i, j] = row[j];
                }
            }

            AlgorithmResult actual = MockKernel.Get<IDefaultAlgorithm>().IsSomebodyWon(table);
            Assert.AreEqual(expected, actual.Result);
        }
    }
}