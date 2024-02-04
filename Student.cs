using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_9
{
    public class Student
    {

        public string name;
        public int age;
        public double gpa;

        public string Name
        {
            get
            { return name; }
            set
            { name = value; }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if ((value > 0) && (value < 50))
                {
                    age = value;
                }
                else
                {
                    throw new Exception("Возраст не тот");
                }
            }
        }
        public double GPA
        {
            get { return gpa; }
            set
            {
                if ((value > 0) && (value < 10))
                {
                    gpa = value;
                }
                else
                {
                    throw new Exception("GPA не может быть меньше 0 и больше 10");
                }
            }
        }

        public Student() //конструктор без параметров
        {
            name = "Unknown";
            age = 0;
            gpa = 0.0;
        }

        public Student(string name, int age, double gpa) //конструктор с параметрами
        {
            this.Name = name;
            this.Age = age;
            this.GPA = gpa;
        }

        public Student(Student otherStudent) //конструктор копирования
        {
            name = otherStudent.name;
            age = otherStudent.age;
            gpa = otherStudent.gpa;
        }

        public void Show() //метод для вывода информации
        {
            Console.WriteLine("Имя: " + name);
            Console.WriteLine("Возраст: " + age);
            Console.WriteLine("GPA: " + gpa);
        }

        private static int count = 0; //статическая переменная для подсчета количества созданных объектов

        public static void IncrementCount()//статический метод для увеличения счетчика
        {
            count++;
        }

        public static int GetCount()//статический метод для получения количества созданных объектов
        {
            return count;
        }

        public string CompareWith(Student otherStudent) //нестатический метод для сравнивания студентов по их показателям
        {
            string result = name + (age < otherStudent.age ? " младше " : (age > otherStudent.age ? " старше " : " ровесник ")) + otherStudent.name;
            result += ". GPA " + name + (gpa > otherStudent.gpa ? " выше " : (gpa < otherStudent.gpa ? " ниже " : " равен ")) + "GPA " + otherStudent.name;
            return result;
        }

        public static Student operator --(Student a) //унарные операции
        {
            string formattedName = char.ToUpper(a.name[0]) + a.name.Substring(1).ToLower();
            return new Student(formattedName, a.age, a.gpa);
        }
        public static Student operator ++(Student a)
        {
            a.age++;
            return a;
        }

        //операции приведения типа
        public static explicit operator int(Student s)//явная
        {
            if (s.age >= 18 && s.age <= 22)
            {
                return s.age - 17;
            }
            else
            {
                return -1;
            }
        }
        public static implicit operator bool(Student s)
        {
            if (s.gpa < 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Student operator %(Student s, string newName) //бинарные операции
        {
            return new Student(newName, s.age, s.gpa);
        }
        public static Student operator -(Student s, double d)
        {
            double newGpa = s.gpa - d;
            if (newGpa < 0)
            {
                newGpa = 0;
            }
            return new Student(s.name, s.age, newGpa);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Student other = (Student)obj;
            return (name == other.name) && (age == other.age) && (gpa == other.gpa);
        }

    }


}

