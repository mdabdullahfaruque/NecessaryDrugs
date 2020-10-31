using Autofac.Extras.Moq;
using Moq;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace NecessaryDrugs.Test
{
    [ExcludeFromCodeCoverage]
    public class CategoryServiceTests
    {
        private AutoMock _mock;
        
        [OneTimeSetUp]
        public void ClassSetup()
        {

        }

        [OneTimeTearDown]
        public void ClassCleanUp()
        {

        }

        [SetUp]
        public void TestSetup()
        {

        }

        [TearDown]
        public void TestCleanUp()
        {

        }

        [Test, Category("Unit Test")]
        public void AddANewCategory()
        {
            //Arrange

            //Act

            //Assert
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            Assert.Pass();
        }
    }
}