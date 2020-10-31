using Autofac.Extras.Moq;
using Moq;
using NecessaryDrugs.Core.Entities;
using NecessaryDrugs.Core.Repositories;
using NecessaryDrugs.Core.Services;
using NecessaryDrugs.Core.UnitOfWorks;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace NecessaryDrugs.Core.Test.Services
{
    [ExcludeFromCodeCoverage]
    class CategoryServiceTests
    {
        private AutoMock _mock;
        private Mock<IMedicineStoreUnitOfWork> _medicineStoreUnitOfWorkMock;
        private Mock<ICategoryRepository> _categoryRepositoryMock;
        private ICategoryService _categoryServiceMock;

        [OneTimeSetUp]
        public void ClassSetup()
        {
            _mock = AutoMock.GetLoose();
        }

        [OneTimeTearDown]
        public void ClassCleanup()
        {
            _mock.Dispose();
        }

        [SetUp]
        public void TestSetup()
        {
            _medicineStoreUnitOfWorkMock = _mock.Mock<IMedicineStoreUnitOfWork>();
            _categoryRepositoryMock = _mock.Mock<ICategoryRepository>();
            _categoryServiceMock = _mock.Create<CategoryService>();
        }

        [TearDown]
        public void TestCleanup()
        {
            _medicineStoreUnitOfWorkMock.Reset();
            _categoryRepositoryMock.Reset();
        }

        [Test, Category("Unit Test")]
        [TestCase(null)]
        public void AddANewCategory_CategoryIsNull_ThrowException(Category category)
        {
            //Arrange

            //Act & Assert
            Should.Throw<InvalidOperationException>(() =>
            _categoryServiceMock.AddANewCategory(category)
            );
        }
    }
}
