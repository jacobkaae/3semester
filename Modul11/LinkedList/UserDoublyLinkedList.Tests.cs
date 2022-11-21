using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DoublyLinkedList.Tests
{
    [TestClass]
    public class DoublyLinkedList
    {
        [TestMethod]
        public void TestAddFirst()
        {
            User kristian = new User("Kristian", 1);
            User mads = new User("Mads", 2);
            User torill = new User("Torill", 3);

            UserDoublyLinkedList list = new UserDoublyLinkedList();
            list.AddFirst(kristian);
            list.AddFirst(mads);
            list.AddFirst(torill);

            Assert.AreEqual(torill, list.GetFirst());
        }

        [TestMethod]
        public void TestRemoveFirst()
        {
            User kristian = new User("Kristian", 1);
            User mads = new User("Mads", 2);
            User torill = new User("Torill", 3);

            UserDoublyLinkedList list = new UserDoublyLinkedList();
            list.AddFirst(kristian);
            list.AddFirst(mads);
            list.AddFirst(torill);

            Assert.AreEqual(torill, list.RemoveFirst());
        }


        [TestMethod]
        public void TestAddLast()
        {
            User kristian = new User("Kristian", 1);
            User mads = new User("Mads", 2);
            User torill = new User("Torill", 3);

            UserDoublyLinkedList list = new UserDoublyLinkedList();
            list.AddFirst(kristian);
            list.AddFirst(mads);
            list.AddLast(torill);

            Assert.AreEqual(torill, list.GetLast());
        }

        [TestMethod]
        public void TestRemoveLast()
        {
            User kristian = new User("Kristian", 1);
            User mads = new User("Mads", 2);
            User torill = new User("Torill", 3);

            UserDoublyLinkedList list = new UserDoublyLinkedList();
            list.AddFirst(kristian);
            list.AddFirst(mads);
            list.AddFirst(torill);

            Assert.AreEqual(kristian, list.RemoveLast());
        }
    }
}