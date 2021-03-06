using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTests
    {
        int count = 0;
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncementCount;
            var result = log("Hello!");
            Assert.Equal(3, count);
            
 
        }
          string IncementCount(string message)
        {
            count ++;
            return message;
        }
        string ReturnMessage(string message)
        {
            count ++;
            return message;
        }
        [Fact]
        public void test1()
        {
            //arrange 
            var x = GetInt();
            SetInt(ref x);
            Assert.Equal(42, x);
        }
        private void SetInt(ref int x)
        {
            x = 42;
        }
        private int GetInt()
        {
            return 3;
        }

         [Fact]
        public void CSharpCanPassByRef()
        {
            //arrange 
            var book1 = GetBook("Book 1");
            GetBookSetName(out book1, "New Name");
            //act
             
            //assert
            Assert.Equal("New Name", book1.Name); 
        }
        private void GetBookSetName(out Book book, string name)
        {
           book = new Book(name);   
        }
        [Fact]
        public void CSharpIsPassByValue()
        {
            //arrange 
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");
            //act
             
            //assert
            Assert.Equal("Book 1", book1.Name); 
        }
        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);   
        }
        [Fact]
        public void CanSetFromReference()
        {
            //arrange
            
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");
            //act
             

            //assert
            Assert.Equal("New Name", book1.Name);
            
        }
        private void SetName(Book book, string name)
        {
            book.Name = name;
        }
        [Fact]
        public void StringBehaveLikeValueType()
        {
            string name = "Piotr";
            var upper = MakeUppercase(name);

             Assert.Equal("Piotr", name);
             Assert.Equal("PIOTR", upper);
        }
        private String MakeUppercase(string parameter)
        {
           return parameter.ToUpper();   
        }
        [Fact]
        public void GetBookReturnDifferenstObjects()
        {
            //arrange
            
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2"); 
            //act
             

            //assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }
        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            //arrange
            
            var book1 = GetBook("Book 1");
            var book2 = book1; 
            //act
             

            //assert
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }
        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}