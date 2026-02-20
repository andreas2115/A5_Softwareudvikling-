using Library;
using NUnit.Framework;
using PersonNS;

namespace Tests;
    [TestFixture]
    public class Test {
        [SetUp]
        public void Init() {
            gen = new Generator();
        }

        private Generator gen;

        [Test]
        public void DummyTest() {
            Assert.AreEqual(1, 1);
        }
    }
