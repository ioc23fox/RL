using RL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RL_UnitTest
{
    
    
    /// <summary>
    ///This is a test class for RLTest and is intended
    ///to contain       all RLTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RLTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        public static string[,] testData = new string[,]
            {
                {"10.12.5.2", "15.10.3", "15.12.11.5.3.2"},
                {"3.2.5.10.11", "3.15.9.2", "15.11.10.9.5.4.3"}
            };

        /// <summary>
        ///A test for op_Addition
        ///</summary>
        [TestMethod()]
        public void op_AdditionTest()
        {
            for (int i = 0; i < testData.Length; i++)
            {
                RL.RL a = new RL.RL(testData[i, 0]);
                RL.RL b = new RL.RL(testData[i, 1]);
                RL.RL expected = new RL.RL(testData[i, 2]);
                RL.RL actual;
                actual = (a + b);
                Assert.AreEqual(expected.StringValue, actual.StringValue);
            }
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
