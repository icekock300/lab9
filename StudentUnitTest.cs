using lab_9;
namespace TestStudent;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestForConsWithPar()
    {
        Student student = new Student("Таня", 20, 5.5);
        Assert.AreEqual("Таня", student.Name);
        Assert.AreEqual(20, student.Age);
        Assert.AreEqual(5.5, student.GPA);

    }
    [TestMethod]
    public void TestForConsWithoutPar()
    {
        Student student = new Student();
        Assert.AreEqual("Unknown", student.Name);
        Assert.AreEqual(0, student.Age);
        Assert.AreEqual(0.0, student.GPA);

    }
    [TestMethod]
    public void TestForOperationsInt()
    {
        Student student = new Student("Таня", 20, 5.5);
        int course = (int)student;
        Assert.AreEqual(3, course);

    }
    [TestMethod]
    public void TestForOperationsIncrement()
    {
        Student student = new Student("Таня", 20, 5.5);
        student++;
        Assert.AreEqual(21, student.Age);
    }
    [TestMethod]
    public void OperatorPercent_ReplacesStudentName()
    {
        // Arrange
        var student = new Student("Alice", 20, 3.5);
        string newName = "Alex";

        // Act
        var newStudent = student % newName;

        // Assert
        Assert.AreEqual(newName, newStudent.Name);
        Assert.AreEqual(student.Age, newStudent.Age);
        Assert.AreEqual(student.GPA, newStudent.GPA);
    }

    [TestMethod]
    public void OperatorSubtract_DecreasesStudentGPA()
    {
        // Arrange
        var student = new Student("Роберт", 21, 4.0);
        double decreaseAmount = 1.5;
        double expectedGpa = 2.5;

        // Act
        var newStudent = student - decreaseAmount;

        // Assert
        Assert.AreEqual(student.Name, newStudent.Name);
        Assert.AreEqual(student.Age, newStudent.Age);
        Assert.AreEqual(expectedGpa, newStudent.GPA);
    }
    [TestMethod]
    public void Equals_OtherStudentWithSameAttributes_IsEqual()
    {
        // Arrange
        var student1 = new Student("Григорий", 20, 3.5);
        var student2 = new Student("Григорий", 20, 3.5);

        // Assert
        Assert.IsTrue(student1.Equals(student2));
    }
    [TestMethod]
    public void Equals_OtherStudentWithDifferentAttributes_IsNotEqual()
    {
        // Arrange
        var student1 = new Student("Григорий", 20, 3.5);
        var student2 = new Student("Роберт", 21, 4.0);

        // Assert
        Assert.IsFalse(student1.Equals(student2));
    }

    [TestMethod]
    public void ConstructorWithoutParams_InitializesWithDefaultValues()
    {
        // Arrange
        var student = new Student();

        // Assert
        Assert.AreEqual("Unknown", student.Name);
        Assert.AreEqual(0, student.Age);
        Assert.AreEqual(0.0, student.GPA);
    }

    [TestMethod]
    public void ConstructorWithParams_InitializesWithGivenValues()
    {
        // Arrange
        var student = new Student("Григорий", 20, 3.5);

        // Assert
        Assert.AreEqual("Григорий", student.Name);
        Assert.AreEqual(20, student.Age);
        Assert.AreEqual(3.5, student.GPA);
    }

    [TestMethod]
    public void CompareWith_ReturnsCorrectComparison()
    {
        // Arrange
        var student1 = new Student("Григорий", 20, 3.5);
        var student2 = new Student("Роберт", 21, 4.0);
        var expectedOutput = "Григорий младше Роберт. GPA Григорий ниже GPA Роберт";

        // Act
        var result = student1.CompareWith(student2);

        // Assert
        Assert.AreEqual(expectedOutput, result);
    }

    [TestMethod]
    public void IncrementCount_CorrectlyIncrementsCount()
    {
        // Arrange
        int initialCount = Student.GetCount();

        // Act
        Student.IncrementCount();

        // Assert
        Assert.AreEqual(initialCount + 1, Student.GetCount());
    }



    [TestMethod]
    public void UnaryOperators_WorkAsExpected()
    {
        // Arrange
        var student = new Student("Джонни", 19, 8.0);

        // Act
        Student result1 = --student;  // Testing decrement
        Student result2 = ++student;  // Testing increment

        // Assert
        Assert.AreEqual("Джонни", result1.Name);
        Assert.AreEqual(20, result2.Age);
    }

    [TestMethod]
    public void TypeConversion_ReturnsExpectedValue()
    {
        // Arrange
        var student1 = new Student("Михаил", 20, 4.0);
        var student2 = new Student("Саша", 23, 6.0);

        // Act & Assert
        Assert.AreEqual(3, (int)student1);  // Testing explicit conversion
        Assert.IsTrue(student1);  // Testing implicit conversion
        Assert.AreEqual(-1, (int)student2);  // Testing explicit conversion
        Assert.IsFalse(student2);  // Testing implicit conversion
    }



}
