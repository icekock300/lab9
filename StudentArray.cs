using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_9;

namespace lab_9
{
    public class StudentArray
    {
        static Random rnd = new Random();
        Student[] students;

        //конструктор без параметров
        public StudentArray()
        {
            students = new Student[0];
        }

        //конструктор с параметрами, заполняющий элементы случайными значениями
        public StudentArray(int size)
        {
            students = new Student[size];
            for (int i = 0; i < size; i++)
            {
                students[i] = new Student { Name = "Student" + i, Age = rnd.Next(18, 25), GPA = rnd.NextDouble() * 10 };
            }
        }
        //конструктор с параметрами для заполнения с клавиатуры
        public StudentArray(int size, string[] name, int[] age, double[] gpa)
        {
            students = new Student[size];
            for (int i = 0; i < students.Length; i++)
            {
                Console.Write("Введите имя студента: ");
                string studentName = Console.ReadLine();
                Console.Write("Введите возраст студента: ");
                int studentAge = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите GPA студента: ");
                double studentGpa = Convert.ToDouble(Console.ReadLine());
                students[i] = new Student(studentName, studentAge, studentGpa);
            }
        }
        public int Length
        {
            get => students.Length;
        }
        //Конструктор копирования
        public StudentArray(StudentArray other)
        {
            this.students = new Student[other.Length];
            for (int i = 0; i < other.Length; i++)
            {
                this.students[i] = new Student(other.students[i]);
            }
        }
        // Метод для просмотра элементов массива
        public void ShowArray()
        {
            Console.WriteLine("Информация о студентах:");
            foreach (Student student in students)
            {
                Console.WriteLine($"Имя: {student.name}, Возраст: {student.age}, GPA: {student.gpa}");
            }
        }

        // Индексатор для доступа к элементам коллекции
        public Student this[int index]
        {
            get
            {
                if (index < 0 || index >= students.Length)
                    throw new IndexOutOfRangeException("Не существует студента с таким индексом");
                return students[index];
            }
            set
            {
                if (index < 0 || index >= students.Length)
                    throw new IndexOutOfRangeException("Не существует студента с таким индексом");
                students[index] = value;
            }
        }
    }
}
