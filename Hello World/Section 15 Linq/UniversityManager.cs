using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMasterClass
{
    class UMProgram
    {
        public static void Main()
        {
            UniversityManager UM = new UniversityManager();
            UM.MaleStudents();
            UM.FemaleStudents();
            UM.SortStudentsByAge();
            UM.StudentAndUniversityName();

            // sorting lists
            /*
            int[] someInts = { 30, 12, 4, 3, 12 };
            IEnumerable<int> sortedInts = from i in someInts orderby i select i;
            IEnumerable<int> reversedInts = sortedInts.Reverse();

            foreach(int i in reversedInts)
            {
                Console.WriteLine(i);
            }

            IEnumerable<int> reversedSortedInts = from i in someInts orderby i descending select i; // ascending is default
            foreach (int i in reversedSortedInts)
            {
                Console.WriteLine(i);
            }
            */

            // Select a list from user input
            /*
            Console.WriteLine("");
            Console.Write("Please enter a University ID: ");

            string input = Console.ReadLine();
            int selection; 
            if(int.TryParse(input, out selection))
            {
                UM.AllStudentsFromUniId(selection);
            }
            return;
            */
        }
    }
    
    class UniversityManager
    {
        public List<University> universities;
        public List<Student> students;

        public UniversityManager()
        {
            universities = new List<University>()
            {
                new University {Id = 1, Name = "Yale"},
                new University {Id = 2, Name = "Beijing Tech"}
            };
            students = new List<Student>()
            {
                new Student {Id = 1, Name = "Carla", Gender = "female", Age = 17, UniversityId = 1},
                new Student {Id = 2, Name = "Toni", Gender = "male", Age = 21, UniversityId = 1},
                new Student {Id = 3, Name = "Leyla", Gender = "female", Age = 19, UniversityId = 2},
                new Student {Id = 4, Name = "James", Gender = "male", Age = 25, UniversityId = 2},
                new Student {Id = 5, Name = "Linda", Gender = "female", Age = 22, UniversityId = 2}
            };
        }

        public void MaleStudents()
        {
            IEnumerable<Student> maleStudents = from student in students where student.Gender == "male" select student;
            Console.WriteLine("Male students:");
            foreach(Student student in maleStudents)
            {
                student.Print();
            }
        }

        public void FemaleStudents()
        {
            IEnumerable<Student> femaleStudents = from student in students where student.Gender == "female" select student;
            Console.WriteLine("Female students:");
            foreach (Student student in femaleStudents)
            {
                student.Print();
            }
        }

        public void OtherStudents()
        {
            IEnumerable<Student> otherStudents = from student in students where student.Gender != "female" && student.Gender != "male" select student;
            Console.WriteLine("Other gender students:");
            foreach (Student student in otherStudents)
            {
                student.Print();
            }
        }

        public void SortStudentsByAge()
        {
            var sortedStudents = from student in students orderby student.Age descending select student;
            Console.WriteLine("Students sorted by Age");
            foreach(Student student in sortedStudents)
            {
                student.Print();
            }
        }

        public void AllStudentsFromBeijing()
        {
            IEnumerable<Student> bjtStudents = from student in students
                                               join university in universities on student.UniversityId equals university.Id
                                               where university.Name == "Beijing Tech"
                                               select student;
            Console.WriteLine("Students from Beijing Tech:");
            foreach(Student student in bjtStudents)
            {
                student.Print();
            }
        }

        public void AllStudentsFromUniId(int uniId)
        {
            IEnumerable<Student> uniStudents = from student in students
                                               // join university in universities on student.UniversityId equals university.Id
                                               where student.UniversityId == uniId
                                               select student;
            var uniName = (from university in universities
                          where university.Id == uniId
                          select university.Name).First();
            Console.WriteLine($"Students from {uniName}:");
            foreach (Student student in uniStudents)
            {
                student.Print();
            }
        }

        public void StudentAndUniversityName()
        {
            var newCollection = from student in students
                                join university in universities on student.UniversityId equals university.Id
                                orderby student.Name
                                select new { StudentName = student.Name, UniversityName = university.Name };

            Console.WriteLine("New Collection: ");
            foreach (var col in newCollection)
            {
                Console.WriteLine($"Student {col.StudentName} from University {col.UniversityName}.");
            }
        }
    }

    class University
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Print()
        {
            Console.WriteLine($"University {Name} with ID {Id}.");
        }
    }

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        // Foreign Key
        public int UniversityId { get; set; }

        public void Print()
        {
            Console.WriteLine($"Student {Name} with ID {Id}, Gender {Gender}, and Age {Age} from University with the ID {UniversityId}");
        }
    }
}
