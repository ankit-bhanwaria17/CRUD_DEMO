namespace xUnitTesting
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            MyMath mm = new MyMath();
            int actual = mm.Add(5, 10);
            int expected = 15;
            Assert.Equal(expected, actual);
        }
    }
}