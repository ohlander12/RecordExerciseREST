using Microsoft.VisualStudio.TestTools.UnitTesting;
using Record_Exercise_REST.Models;
using Record_Exercise_REST.Repositories;
using System.Collections.Generic;

namespace Record_Exercise_REST.Tests
{
    [TestClass()]
    public class RecordsRepositoryTests
    {
        private RecordsRepository _repository = null!;

        [TestInitialize]
        public void Setup()
        {
            _repository = new RecordsRepository();
        }

        [TestMethod()]
        public void GetAllTest()
        {
            var records = _repository.GetAll();
            Assert.IsNotNull(records);
            Assert.AreEqual(2, records.Count); // Assuming the initial records added in the constructor
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            var record = _repository.GetById(1);
            Assert.IsNotNull(record);
            Assert.AreEqual("Song 1", record.Title);
        }

        [TestMethod()]
        public void AddTest()
        {
            var newRecord = new MusicRecord { Title = "New Song", Artist = "New Artist", Duration = 300, PublicationYear = 2021 };
            var addedRecord = _repository.Add(newRecord);

            Assert.IsNotNull(addedRecord);
            Assert.AreEqual(3, addedRecord.Id); // Assuming the initial records added in the constructor
            Assert.AreEqual("New Song", addedRecord.Title);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            var updatedRecord = new MusicRecord { Title = "Updated Song", Artist = "Updated Artist", Duration = 250, PublicationYear = 2022 };
            var result = _repository.Update(1, updatedRecord);

            Assert.IsTrue(result);
            var record = _repository.GetById(1);
            Assert.AreEqual("Updated Song", record?.Title);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var result = _repository.Delete(1);

            Assert.IsTrue(result);
            var record = _repository.GetById(1);
            Assert.IsNull(record);
        }
    }
}
