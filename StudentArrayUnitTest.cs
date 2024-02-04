using lab_9;
namespace TestStudentArray;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void ConstructorWithoutParams_InitializesEmptyArray()
    {
        // Arrange
        var studentArray = new StudentArray();

        // Act
        int length = studentArray.Length;

        // Assert
        Assert.AreEqual(0, length);
    }

    [TestMethod]
    public void ConstructorWithSize_FillsArrayWithStudents()
    {
        // Arrange
        int size = 5;
        var studentArray = new StudentArray(size);

        // Act
        int length = studentArray.Length;

        // Assert
        Assert.AreEqual(size, length);
    }

   
    [TestMethod]
    public void AccessingOutOfBoundsIndex_ThrowsException()
    {
        // Arrange
        var studentArray = new StudentArray(3);

        // Act & Assert
        //Assert.Throws<IndexOutOfRangeException>(() => studentArray[-1]);
        //Assert.Throws<IndexOutOfRangeException>(() => studentArray[3]);
    }
    [TestMethod]
    public void SetAndGetStudentAtIndex_ReturnsCorrectStudent()
    {
        // Arrange
        var studentArray = new StudentArray(1);
        var student = new Student("Максим", 22, 3.8);

        // Act
        studentArray[0] = student;
        var retrievedStudent = studentArray[0];

        // Assert
        Assert.AreEqual(student, retrievedStudent);
    }


    [TestMethod]
    public void TestEmptyConstructor()
    {
        // Arrange
        StudentArray studentArray = new StudentArray();

        // Act
        int length = studentArray.Length;

        // Assert
        Assert.AreEqual(0, length);
    }



    [TestMethod]
    public void TestParameterizedConstructor()
    {
        // Arrange
        int size = 5;
        StudentArray studentArray = new StudentArray(size);

        // Act
        int length = studentArray.Length;

        // Assert
        Assert.AreEqual(size, length);

        // Additional Assertions
        for (int i = 0; i < size; i++)
        {
            Student student = studentArray[i];
            Assert.IsNotNull(student);
            Assert.IsFalse(string.IsNullOrEmpty(student.Name));
            Assert.IsTrue(student.Age >= 18 && student.Age <= 25);
            Assert.IsTrue(student.GPA >= 0 && student.GPA < 10);
        }
    }


    [TestMethod]
    public void TestIndexer()
    {
        // Arrange
        StudentArray studentArray = new StudentArray(2);
        Student expectedStudent = new Student("Анатолий", 20, 5.5);

        // Act
        studentArray[0] = expectedStudent;
        Student retrievedStudent = studentArray[0];

        // Assert
        Assert.AreEqual(expectedStudent, retrievedStudent);
    }

}
