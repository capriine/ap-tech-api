using NUnit.Framework;
using System.Collections.Generic;

namespace primenumberapi_tests
{

    public class PrimeNumberTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGet_InvalidMaxValueMinus5()
        {
            primenumberapi.Controllers.PrimeNumber primeNumberController = new primenumberapi.Controllers.PrimeNumber();
            primenumberapi.Objects.PrimeNumberResponse primeNumberResponse = primeNumberController.Get(-5, 1, 100);
            Assert.IsFalse(primeNumberResponse.IsSuccess);
        }

        [Test]
        public void TestGet_InvalidMaxValueZero()
        {
            primenumberapi.Controllers.PrimeNumber primeNumberController = new primenumberapi.Controllers.PrimeNumber();
            primenumberapi.Objects.PrimeNumberResponse primeNumberResponse = primeNumberController.Get(0, 1, 100);
            Assert.IsFalse(primeNumberResponse.IsSuccess);
        }

        [Test]
        public void TestGet_InvalidMaxValueOne()
        {
            primenumberapi.Controllers.PrimeNumber primeNumberController = new primenumberapi.Controllers.PrimeNumber();
            primenumberapi.Objects.PrimeNumberResponse primeNumberResponse = primeNumberController.Get(1, 1, 100);
            Assert.IsFalse(primeNumberResponse.IsSuccess);
        }

        [Test]
        public void TestGet_ValidMaxValueThree()
        {
            primenumberapi.Controllers.PrimeNumber primeNumberController = new primenumberapi.Controllers.PrimeNumber();
            primenumberapi.Objects.PrimeNumberResponse primeNumberResponse = primeNumberController.Get(3, 1, 100);
            Assert.IsTrue(primeNumberResponse.IsSuccess);
        }

        [Test]
        public void TestGet_ValidMaxValue100()
        {
            primenumberapi.Controllers.PrimeNumber primeNumberController = new primenumberapi.Controllers.PrimeNumber();
            primenumberapi.Objects.PrimeNumberResponse primeNumberResponse = primeNumberController.Get(100, 1, 100);
            Assert.IsTrue(primeNumberResponse.IsSuccess);
        }

        [Test]
        public void TestGet_ValuesInBrief_Input5()
        {
            primenumberapi.Controllers.PrimeNumber primeNumberController = new primenumberapi.Controllers.PrimeNumber();
            primenumberapi.Objects.PrimeNumberResponse primeNumberResponse = primeNumberController.Get(5, 1, 100);

            // We need it to be True
            Assert.IsTrue(primeNumberResponse.IsSuccess);

            // Does it match the set in the brief?
            List<int> controlData = new List<int>() { 2, 3, 5 };
            Assert.AreEqual(primeNumberResponse.Numbers, controlData);

        }

        [Test]
        public void TestGet_ValuesInBrief_Input50()
        {
            primenumberapi.Controllers.PrimeNumber primeNumberController = new primenumberapi.Controllers.PrimeNumber();
            primenumberapi.Objects.PrimeNumberResponse primeNumberResponse = primeNumberController.Get(50, 1, 100);

            // We need it to be True
            Assert.IsTrue(primeNumberResponse.IsSuccess);

            // Does it match the set in the brief?
            List<int> controlData = new List<int>() { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47 };
            Assert.AreEqual(primeNumberResponse.Numbers, controlData);

        }

        public void TestGet_ValuesInBrief_Input53()
        {
            // 53 is a prime number too, so need to check that the results include the value if it is a prime number.

            primenumberapi.Controllers.PrimeNumber primeNumberController = new primenumberapi.Controllers.PrimeNumber();
            primenumberapi.Objects.PrimeNumberResponse primeNumberResponse = primeNumberController.Get(50, 1, 100);

            // We need it to be True
            Assert.IsTrue(primeNumberResponse.IsSuccess);

            // Does it match the set in the brief?
            List<int> controlData = new List<int>() { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47 };
            Assert.AreEqual(primeNumberResponse.Numbers, controlData);

        }


        [Test]
        public void TestGetPaging_ValuesInBrief_Input50Page1Size5()
        {
            primenumberapi.Controllers.PrimeNumber primeNumberController = new primenumberapi.Controllers.PrimeNumber();
            primenumberapi.Objects.PrimeNumberResponse primeNumberResponse = primeNumberController.Get(50, 1, 5);

            // We need it to be True
            Assert.IsTrue(primeNumberResponse.IsSuccess);

            // Should return 5 items (of 15 total)

            // Does it match the set in the brief?
            List<int> controlData = new List<int>() { 2, 3, 5, 7, 11 };
            Assert.AreEqual(primeNumberResponse.Numbers, controlData);
        }

        [Test]
        public void TestGetPaging_ValuesInBrief_Input50Page2Size5()
        {
            primenumberapi.Controllers.PrimeNumber primeNumberController = new primenumberapi.Controllers.PrimeNumber();
            primenumberapi.Objects.PrimeNumberResponse primeNumberResponse = primeNumberController.Get(50, 2, 5);

            // We need it to be True
            Assert.IsTrue(primeNumberResponse.IsSuccess);

            // Should return 5 items (of 15 total)

            // Does it match the set in the brief?
            List<int> controlData = new List<int>() { 13, 17, 19, 23, 29 };
            Assert.AreEqual(primeNumberResponse.Numbers, controlData);
        }

        [Test]
        public void TestGetPaging_ValuesInBrief_Input50Page3Size5()
        {
            primenumberapi.Controllers.PrimeNumber primeNumberController = new primenumberapi.Controllers.PrimeNumber();
            primenumberapi.Objects.PrimeNumberResponse primeNumberResponse = primeNumberController.Get(50, 3, 5);

            // We need it to be True
            Assert.IsTrue(primeNumberResponse.IsSuccess);

            // Should return 5 items (of 15 total)

            // Does it match the set in the brief?
            List<int> controlData = new List<int>() { 31, 37, 41, 43, 47 };
            Assert.AreEqual(primeNumberResponse.Numbers, controlData);
        }



        [Test]
        public void TestGetPaging_ValuesInBrief_Input50Page1Size6()
        {
            primenumberapi.Controllers.PrimeNumber primeNumberController = new primenumberapi.Controllers.PrimeNumber();
            primenumberapi.Objects.PrimeNumberResponse primeNumberResponse = primeNumberController.Get(50, 1, 6);

            // We need it to be True
            Assert.IsTrue(primeNumberResponse.IsSuccess);

            // Should return 5 items (of 15 total)

            // Does it match the set in the brief?
            List<int> controlData = new List<int>() { 2, 3, 5, 7, 11, 13 };
            Assert.AreEqual(primeNumberResponse.Numbers, controlData);
        }

        [Test]
        public void TestGetPaging_ValuesInBrief_Input50Page2Size6()
        {
            primenumberapi.Controllers.PrimeNumber primeNumberController = new primenumberapi.Controllers.PrimeNumber();
            primenumberapi.Objects.PrimeNumberResponse primeNumberResponse = primeNumberController.Get(50, 2, 6);

            // We need it to be True
            Assert.IsTrue(primeNumberResponse.IsSuccess);

            // Should return 5 items (of 15 total)

            // Does it match the set in the brief?
            List<int> controlData = new List<int>() { 17, 19, 23, 29, 31, 37 };
            Assert.AreEqual(primeNumberResponse.Numbers, controlData);
        }

        [Test]
        public void TestGetPaging_ValuesInBrief_Input50Page3Size6()
        {
            // This test will give a page that is not complete, it shoudln't error, and should return 3 items
            primenumberapi.Controllers.PrimeNumber primeNumberController = new primenumberapi.Controllers.PrimeNumber();
            primenumberapi.Objects.PrimeNumberResponse primeNumberResponse = primeNumberController.Get(50, 3, 6);

            // We need it to be True
            Assert.IsTrue(primeNumberResponse.IsSuccess);

            // Should return 5 items (of 15 total)

            // Does it match the set in the brief?
            List<int> controlData = new List<int>() { 41, 43, 47 };
            Assert.AreEqual(primeNumberResponse.Numbers, controlData);
        }

    }

}