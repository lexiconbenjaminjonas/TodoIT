using TodoIT.Data;
using TodoIT.Model;
using Xunit;

namespace ToDoITTEsts
{
    public class ToDoItemsTest
    {
        [Fact]
        public void SizeTest()
        {
            //Arrange.
            ToDoItems sut = new ToDoItems();
            //Act.
            int before = sut.Size();
            sut.CreateToDo("Test");
            var after = sut.Size();
            //Assert.
            Assert.Equal(before + 1, after);
        }

        [Fact]
        public void CreateToDoItemsTest()
        {
            //Arrange.
            ToDoItems sut = new ToDoItems();
            //Act.
            ToDo item = sut.CreateToDo("TestToDo");
            //Assert.
            Assert.NotNull(item);
            Assert.Equal("TestToDo", item.description);
        }

        [Fact]
        public void FindAllTest()
        {
            //Arrange.
            ToDoItems sut = new ToDoItems();
            sut.CreateToDo("Test1");
            //Act.
            ToDo[] test = sut.FindAll();
            //Assert.
            Assert.NotNull(test);
            Assert.NotEmpty(test);
        }

        [Fact]
        public void FindByIdTest()
        {
            //Arrange.
            ToDoItems sut = new ToDoItems();
            //Act.
            ToDo item = sut.CreateToDo("TestFindById");
            int itemId = item.todoID;
            ToDo itemReturned = sut.FindById(itemId);
            //Assert.
            Assert.Same(item, itemReturned);
        }

        [Fact]
        public void FindByIdInvalidTest()
        {
            //Arrange.
            ToDoItems sut = new ToDoItems();
            //Act.
            ToDo item = sut.CreateToDo("TestFindById");
            var itemReturned = sut.FindById(-1);
            //Assert.
            Assert.Null(itemReturned);
        }

        [Fact]
        public void ClearTest()
        {
            //Arrange.
            ToDoItems sut = new ToDoItems();
            //Act.
            ToDo item = sut.CreateToDo("TestFindById");
            sut.Clear();
            //Assert.
            Assert.All(sut.FindAll(), a => Assert.Null(a));
        }


        [Fact]

        public void FindByAssignee_Person()
        {
            //Arrange
            Person assignee = new Person(0,"Test", "Testsson");
            ToDoItems sut = new ToDoItems();
            
            sut.Clear();
            ToDoSequencer.reset();

            sut.CreateToDo("Test Todo1", assignee);
            sut.CreateToDo("Test Todo2");
            sut.CreateToDo("Test Todo3", assignee);
            sut.CreateToDo("Test Todo2",new Person(1,"Man","Mannington"));

            //Act
            ToDo[] foundToDos = sut.FindByAssignee(assignee);
            //Assert
            foreach (var toDo in foundToDos)
            {
                Assert.Same(toDo.assignee, assignee);
                Assert.Equal(2,foundToDos.Length);
            }
        }
        
        [Fact]
        public void FindByAssigneeTest()
        {
            //Arrange.
            ToDoItems sut = new ToDoItems();
            sut.Clear();
            Person testPerson = new Person(99, "Testfirst", "Testlast");
            sut.CreateToDo("Test nr 1", testPerson);
            sut.CreateToDo("Test nr 2", testPerson);
            sut.CreateToDo("Test nr 3", new Person(1000, "Wrong", "Guy"));
            sut.CreateToDo("Test nr 4");
            ToDo[] expectedValue = new ToDo[2] { sut.FindAll()[0], sut.FindAll()[1] };
            //Act.
            ToDo[] testArray = sut.FindByAssignee(testPerson);
            //Assert.
            Assert.Equal(expectedValue, testArray);
        }



        [Fact]
        public void FindUnassignedToDoItemsTest()
        {
            //Arrange.
            ToDoItems sut = new ToDoItems();
            Person testPerson = new Person(99, "Testfirst", "Testlast");
            sut.Clear();
            sut.CreateToDo("Test nr 1");
            sut.CreateToDo("Test nr 2");
            sut.CreateToDo("Test nr 3", testPerson);
            ToDo[] expectedValue = new ToDo[2] { sut.FindAll()[0], sut.FindAll()[1] };
            //Act.
            ToDo[] testArray = sut.FindUnassignedTodoItems();
            //Assert.
            Assert.Equal(expectedValue, testArray);
        }

        [Fact]

        public void FindDoneStatusTest()
        {
            //Arrange
            var sut = new ToDoItems();
            sut.CreateToDo("Test");
            sut.CreateToDo("Test");
            var DoneTodo = sut.CreateToDo("DoneTodo");
            DoneTodo.done = true;
            
            //Act
            var doneStatus = sut.FindByDoneStatus(true);
            //Assert
            foreach (var toDo in doneStatus)
            {
                Assert.NotNull(toDo);
                Assert.Equal(new ToDo[1] {DoneTodo},doneStatus);
                Assert.True(toDo.done);
            }
        }

        [Fact]
        public void RemoveTodoTest()
        {
            //Arrange.
            ToDoItems sut = new ToDoItems();
            sut.Clear();
            sut.CreateToDo("Test nr 1");
            sut.CreateToDo("Test nr 2");
            sut.CreateToDo("Test nr 3");
            sut.CreateToDo("Test nr 4");
            //Act.
            ToDo objectToRemove=sut.FindById(1);
            sut.RemoveTodo(objectToRemove);
            //Assert.
            Assert.DoesNotContain<ToDo>(objectToRemove, sut.FindAll());
        }





    }
}
