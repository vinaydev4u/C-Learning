using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WritelogDelegate(string logMessage);

    public class TypeTests
    {
        int count = 0;

        [Fact]
        public void WritelogDelegateCanPointToMethod()
        {
            WritelogDelegate log = ReturnMessage;
             log += IncrementCount;
             log += ReturnMessage;

            var result = log("Hello!");
            Assert.Equal("Hello!", result);
            Assert.Equal(3,count);

        }

        string IncrementCount(string message)
        {
            count++;
            return message.ToLower(); ;
        }

        string ReturnMessage(string message)
        {
            count++;
            return message;
        }

        [Fact]
        public void StringBehaveLikeValueTypes()
        {
            string name = "Vinay";
            var upper = MakeUppercase(name);

            Assert.Equal("Vinay", name);
            Assert.Equal("VINAY", upper);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void ValueTypeAlsoPassByValue()
        {
            var x = GetInit();
            SetInt(ref x);
            Assert.Equal(42, x);
        }

        private int GetInit()
        {
            return 3;
        }

        private void SetInt(ref Int32 z)
        {
            z = 42;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            //Arrange
            var book1 = GetBook("Book 1");
            GetBookSetName(out book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(out InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            //Arrange
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
            book.Name = name;
        }

        [Fact]
        public void CabSetNameFromReference()
        {
            //Arrange
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferntObjects()
        {
            //Arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObjects()
        {
            //Arrange
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(object.ReferenceEquals(book1, book2));

        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
