using Microsoft.VisualStudio.TestTools.UnitTesting;
using DenmarkRadio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenmarkRadio.Models.Tests
{
    [TestClass()]
    public class MusicTests
    {
        private Music music = new Music() { Artist = "Denmark", Duration = 120, PublicationYear = 2022, Title = "Zealand" };
        [TestMethod()]
        public void ToStringTest()
        {
            string expect = "Title Zealand, Artist Denmark, Duration 120, Publication Year 2022";
            string actual = music.ToString();

            Assert.AreEqual(expect, actual);
        }

        [TestMethod()]
        public void ValidateTitleTest()
        {
            music.ValidateTitle();

            Music nullMusic = new Music() { Artist = "Denmark", Duration = 120, PublicationYear = 2022 };
            Assert.ThrowsException<ArgumentNullException>(() => nullMusic.ValidateTitle());

            Music lengthMusic = new Music() { Artist = "Denmark", Duration = 120, PublicationYear = 2022, Title = "Z" };
            Assert.ThrowsException<ArgumentException>(() => lengthMusic.ValidateTitle());
        }

        [TestMethod()]
        public void ValidateArtistTest()
        {
            music.ValidateArtist();

            Music nullArtist = new Music() { Title = "Zealand", Duration = 120, PublicationYear = 2022 };
            Assert.ThrowsException<ArgumentNullException>(() => nullArtist.ValidateArtist());

            Music lengthArtist = new Music() { Title = "Zealand", Artist = "D", Duration = 120, PublicationYear = 2022 };
            Assert.ThrowsException<ArgumentException>(() => lengthArtist.ValidateArtist());

        }

        [TestMethod()]
        public void ValidateDurationTest()
        {
            music.ValidateDuration();

            Music negDuration = new Music() { Artist = "Denmark", Duration = -120, PublicationYear = 2022, Title = "Zealand" };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => negDuration.ValidateDuration());
        }

        [TestMethod()]
        public void ValidatePublicationYearTest()
        {
            music.ValidatePublicationYear();

            Music negPubYear = new Music() { Artist = "Denmark", Duration = 120, PublicationYear = -2022, Title = "Zealand" };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => negPubYear.ValidatePublicationYear());
        }
    }
}