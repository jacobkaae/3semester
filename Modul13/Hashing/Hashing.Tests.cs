using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hashing.Tests
{
    [TestClass]
    public class Hashing_Tests
    {
        [TestMethod]
        public void TestAddChaining() {
            HashSetChaining names = new HashSetChaining(13);
            names.Add("Harry");
            names.Add("Sue");
            names.Add("Nina");
            names.Add("Susannah");
            names.Add("Larry");
            names.Add("Eve");
            names.Add("Sarah");
            names.Add("Adam");
            names.Add("Tony");
            names.Add("Katherine");
            names.Add("Juliet");
            names.Add("Romeo");
            Assert.AreEqual(12, names.Size());
        }
        
        [TestMethod]
        public void TestRemoveChaining() {
            HashSetChaining names = new HashSetChaining(13);
            names.Add("Harry");
            names.Add("Sue");
            names.Add("Nina");
            names.Add("Susannah");
            names.Add("Larry");
            names.Remove("Larry");
            names.Remove("Nina");
            Assert.AreEqual(3, names.Size());
        }
        
        [TestMethod]
        public void TestContainsChaining() {
            HashSetChaining names = new HashSetChaining(4);
            names.Add("Harry");
            names.Add("Sue");
            names.Add("Nina");
            names.Add("Susannah");
            names.Add("Larry");
            names.Add("Eve");
            names.Add("Sarah");
            names.Add("Adam");
            names.Add("Tony");
            names.Add("Katherine");
            names.Add("Juliet");
            names.Add("Romeo");
            Assert.IsTrue(names.Contains("Nina"));
            Assert.IsTrue(names.Contains("Romeo"));
            Assert.IsTrue(names.Contains("Sarah"));
            
            names.Remove("Romeo");
            Assert.IsFalse(names.Contains("Romeo"));
        }

        [TestMethod]
        public void TestAddLinearProbing() {
            HashSetLinearProbing names = new HashSetLinearProbing(13);
            names.Add("Harry");
            names.Add("Sue");
            names.Add("Nina");
            names.Add("Susannah");
            names.Add("Larry");
            names.Add("Eve");
            names.Add("Sarah");
            names.Add("Adam");
            names.Add("Tony");
            names.Add("Katherine");
            names.Add("Juliet");
            names.Add("Romeo");
            Assert.AreEqual(12, names.Size());
        }

        [TestMethod]
        public void TestRemoveLinearProbing() {
            HashSetLinearProbing names = new HashSetLinearProbing(13);
            names.Add("Harry");
            names.Add("Sue");
            names.Add("Nina");
            names.Add("Susannah");
            names.Add("Larry");
            names.Remove("Larry");
            names.Remove("Nina");
            Assert.AreEqual(3, names.Size());
        }

        [TestMethod]
        public void TestContainsLinearProbing() {
            HashSetLinearProbing names = new HashSetLinearProbing(5);
            names.Add("Harry");
            names.Add("Sue");
            names.Add("Nina");
            names.Add("Susannah");
            names.Add("Larry");
            Assert.IsTrue(names.Contains("Nina"));
            Assert.IsTrue(names.Contains("Harry"));
            
            names.Remove("Sue");
            Assert.IsFalse(names.Contains("Sue"));
        }


        [TestMethod]
        public void TestRehash()
        {
            HashSetChaining names = new HashSetChaining(13);
            names.Add("Harry");
            names.Add("Sue");
            names.Add("Nina");
            names.Add("Susannah");
            names.Add("Larry");
            names.Add("Eve");
            names.Add("Sarah");
            names.Add("Adam");
            names.Add("Tony");
            names.Add("Katherine");
            names.Add("Juliet");
            names.Add("Romeo");
            Assert.AreEqual(26, names.Length());
            Assert.IsTrue(names.Contains("Nina"));
            Assert.IsTrue(names.Contains("Harry"));
            Assert.IsTrue(names.Contains("Sue"));
            Assert.IsTrue(names.Contains("Susannah"));
            Assert.IsTrue(names.Contains("Larry"));
            Assert.IsTrue(names.Contains("Eve"));
            Assert.IsTrue(names.Contains("Sarah"));
            Assert.IsTrue(names.Contains("Adam"));
            Assert.IsTrue(names.Contains("Tony"));
            Assert.IsTrue(names.Contains("Katherine"));
            Assert.IsTrue(names.Contains("Juliet"));
            Assert.IsTrue(names.Contains("Romeo"));


        }
    }
}