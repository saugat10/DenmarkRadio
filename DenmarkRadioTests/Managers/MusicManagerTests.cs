using Microsoft.VisualStudio.TestTools.UnitTesting;
using DenmarkRadio.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DenmarkRadio.Models;

namespace DenmarkRadio.Managers.Tests
{
    [TestClass()]
    public class MusicManagerTests
    {
        private MusicManager manager = new MusicManager();
        [TestMethod()]
        public void GetAllTest()
        {
            List<Music> music = manager.GetAll();
            var result = 4;
            Assert.AreEqual(result, music.Count);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Music music = manager.GetById(1);
            var result = 1;
            Assert.AreEqual(result, music.Id);
        }

        [TestMethod()]
        public void AddTest()
        {
            Music music = new Music() { Artist="tester", Duration=1, PublicationYear=2000, Title="test"};
            var result = manager.Add(music);
            var expected = 5;
            Assert.AreEqual(expected, result.Id);
            manager.Delete(music.Id);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            manager.Delete(3);
            var result = manager.GetAll();
            var expected = 3;
            Assert.AreEqual(expected, result.Count);
            Music music = new Music() { Artist = "tester", Duration = 1, PublicationYear = 2000, Title = "test" };
            manager.Add(music);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Music music1 = new Music() { Artist = "tester", Duration = 1, PublicationYear = 2000, Title = "test" };
            Music music = manager.Update(1, music1);
            music.Artist = "tester";
            music.Duration = 1;
            music.PublicationYear = 2000;
            music.Title = "test";
            Assert.AreEqual(music.Artist, "tester");
            Assert.AreEqual(music.Duration, 1);
            Assert.AreEqual(music.PublicationYear, 2000);
            Assert.AreEqual(music.Title, "test");
        }
    }
}