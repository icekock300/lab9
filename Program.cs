using System.Drawing;
using lab_9;

namespace lab_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 часть");
            Student student1 = new Student("алексей", 20, 3.5);
            Student.IncrementCount(); //увеличиваем счетчик объектов
            student1.Show();

            Student student2 = new Student("кирилл", 25, 3.9);
            Student.IncrementCount(); //увеличиваем счетчик объектов
            student2.Show();

            CompareStudents(student1, student2); //вызов функции сравнения студентов по показателям
            student1.CompareWith(student2); //вызов метода сравнения студентов внутри объекта student1
            Console.WriteLine("Число студентов: " + Student.GetCount());

            Console.WriteLine("2 часть");
            //унарные операции
            student1++;
            student1--;
            student2++;
            student2--;
            student1.Show();
            student2.Show();
            //операции приведения типа
            int courseNumberOfStudent1 = (int)student1;
            Console.WriteLine($"Студент {student1.name} учится на {courseNumberOfStudent1} курсе");
            int courseNumberOfStudent2 = (int)student2;
            Console.WriteLine($"Студент {student2.name} учится на {courseNumberOfStudent2} курсе");
            bool isTrue = student1;
            Console.WriteLine($"Студент {student1.name} скорее всего имеет удовлетворительные оценки = {isTrue}");
            isTrue = student2;
            Console.WriteLine($"Студент {student2.name} скорее всего имеет удовлетворительные оценки = {isTrue}");


            bool isSatisfactory = student1;
            isSatisfactory = student2;

            //бинарные операции
            Student student3 = student1 % "Мария";
            Student student4 = student2 - 2.5;
            student3.Show();
            student4.Show();

            Student equals1 = student3;
            Student equals2 = student4;
            Console.WriteLine($"{student3.Equals(student4)}");

            Console.WriteLine("3 часть");
            //создание коллекции разными способами
            Console.WriteLine("Выберите способ создания массива студентов: 1 - ручной ввод, 2 - рандомный");
            int answer = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Сколько студентов?");
            int count = Convert.ToInt32(Console.ReadLine());
            StudentArray studentArray;
            switch (answer)
            {
                case 1:
                    {
                        string[] names = new string[count];
                        int[] ages = new int[count];
                        double[] gpas = new double[count];
                        studentArray = new StudentArray(count, names, ages, gpas);
                        studentArray.ShowArray();
                        break;
                    }
                case 2:
                    {
                        studentArray = new StudentArray(count);
                        studentArray.ShowArray();
                        break;
                    }
            }

            Console.WriteLine("1 коллекция");
            StudentArray collectionOriginal = new StudentArray(4);
            collectionOriginal.ShowArray();
            Console.WriteLine("2 коллекция (copy)");
            StudentArray collectionCopy = new StudentArray(collectionOriginal);
            collectionCopy.ShowArray();

            //проверка работы индексатора
            Console.WriteLine($"Студент с индексом 2:");
            Console.WriteLine(collectionOriginal[2].Name); //получение объекта с существующим индексом
            try
            {
                Console.WriteLine($"Студент с индексом 10:");
                Console.WriteLine(collectionOriginal[10].Name); //получение объекта с несуществующим индексом
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        //статическая функция для сравнения студентов
        static void CompareStudents(Student s1, Student s2)
        {
            string result = s1.Name + (s1.Age < s2.Age ? " младше " : (s1.Age > s2.Age ? " старше " : " ровесник ")) + s2.Name;
            result += ". GPA " + s1.Name + (s1.GPA > s2.GPA ? " выше " : (s1.GPA < s2.GPA ? " ниже " : " равен ")) + "GPA " + s2.Name;
            Console.WriteLine(result);
        }

    }
}
