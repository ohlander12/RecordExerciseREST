using Microsoft.VisualStudio.TestTools.UnitTesting;
using Record_Exercise_REST.Models;

namespace Record_Exercise_REST.Tests
{
    [TestClass()]
    public class MusicRecordTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            var record = new MusicRecord
            {
                Id = 1,
                Title = "Test Song",
                Artist = "Test Artist",
                Duration = 180,
                PublicationYear = 2020
            };

            var result = record.ToString();
            var expected = "Id: 1, Title: Test Song, Artist: Test Artist, Duration: 180, PublicationYear: 2020";

            Assert.AreEqual(expected, result);
        }
    }
}
