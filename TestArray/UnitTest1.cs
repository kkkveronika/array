namespace TestArray
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void max_lenght()
        {
            List<double> numb1= new List<double>() { 1, 2, 3, 4, 5, 0, -1, 10, 20, 30 };
            List<int> result1= new List<int>() { 5, 1, 4, 7 };

            List<double> numb2 = new List<double>() { -1, 10, 20, 30 };
            List<int> result2 = new List<int>() { 4, 1 };

            List<double> numb3 = new List<double>() { 1, 2, 3, 4, 5, 0, -1, 10, 20, 30, 1, 2};
            List<int> result3 = new List<int>() { 5, 1, 4, 7 };

            List<double> numb4 = new List<double>() { 1, 2, 3, 4, 0, -1, 10, 20, 30 };
            List<int> result4 = new List<int>() { 4, 1, 4, 6 };

            List<double> numb5 = new List<double>() { 9, 5, 2, 1, -6 };
            List<int> result5 = new List<int>() { };
            List<int> actual = new List<int>();

            actual = array.Find_max(numb1);
            CollectionAssert.AreEqual(result1, actual);

            actual = array.Find_max(numb2);
            CollectionAssert.AreEqual(result2, actual);

            actual = array.Find_max(numb3);
            CollectionAssert.AreEqual(result3, actual);

            actual = array.Find_max(numb4);
            CollectionAssert.AreEqual(result4, actual);

            actual = array.Find_max(numb5);
            CollectionAssert.AreEqual(result5, actual);
        }
    }
}