using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;

namespace LinqToSQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*
         * There is a lot of work I could do to improve this secion's code.
         * I do not have any desire to do so, though.
         * So I am going to abandon it and preserve it as a reference.
         * It is a good library of operations possible with the LinqToSql system. 
         * 
         * To add or delete a record, you need to use dataContext.InsertOnSubmit(), dataContext.InsertAllOnSubmit(), or dataContext.DeleteOnSubmit()
         * To change a record, you just need to fetch it and make changes.
         * To submit all changes, run dataContext.SubmitChanges(). 
         * 
         * Because of spooky behind the scenes action, linked records (with foreign keys) automatically contain references to their linked records
         * i.e. student.University will get the university record associated with the Id stored on the student record. 
         */
        
        LinqToSqlDataClassesDataContext dataContext;
        public MainWindow()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["LinqToSQL.Properties.Settings.CSMasterClassDBConnectionString"].ConnectionString;
            dataContext = new LinqToSqlDataClassesDataContext(connectionString);

            //InsertStudentLectureAssociations();
            //GetUniversityOfTonie();
            //GetLecturesFromTonie();
            //GetAllStudentsFromYale();
            //GetAllUniversitiesWithFemales();
            //GetAllLecturesFromMIT();
            //UpdateTonie();
            //DeleteJames();
        }

        public void InsertUniversities()
        {
            dataContext.ExecuteCommand("delete from University");

            University MIT = new University();
            MIT.Name = "MIT";
            dataContext.Universities.InsertOnSubmit(MIT);

            University yale = new University();
            yale.Name = "yale";
            dataContext.Universities.InsertOnSubmit(yale);

            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Universities;
        }

        public void InsertStudents()
        {
            dataContext.ExecuteCommand("delete from Student");

            University yale = dataContext.Universities.First(un => un.Name.Equals("Yale"));
            University MIT = dataContext.Universities.First(un => un.Name.Equals("MIT"));

            List<Student> students = new List<Student>();

            students.Add(new Student { Name = "Carla", Gender = "female", UniversityId = yale.Id });
            students.Add(new Student { Name = "Tonie", Gender = "male", University = MIT });
            students.Add(new Student { Name = "Leyla", Gender = "female", University = yale });
            students.Add(new Student { Name = "James", Gender = "male", University = MIT });

            dataContext.Students.InsertAllOnSubmit(students);
            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Students;
        }

        public void InsertLectures()
        {
            dataContext.ExecuteCommand("delete from Lecture");

            dataContext.Lectures.InsertOnSubmit(new Lecture { Name = "Math" });
            dataContext.Lectures.InsertOnSubmit(new Lecture { Name = "History" });
            dataContext.Lectures.InsertOnSubmit(new Lecture { Name = "Chemistry" });
            dataContext.Lectures.InsertOnSubmit(new Lecture { Name = "Physics" });
            dataContext.Lectures.InsertOnSubmit(new Lecture { Name = "Programming" });
            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Lectures;
        }

        public void InsertStudentLectureAssociations()
        {
            dataContext.ExecuteCommand("delete from StudentLecture");

            Student Carla = dataContext.Students.First(st => st.Name.Equals("Carla"));
            Student Tonie = dataContext.Students.First(st => st.Name.Equals("Tonie"));
            Student Leyla = dataContext.Students.First(st => st.Name.Equals("Leyla"));
            Student James = dataContext.Students.First(st => st.Name.Equals("James"));

            Lecture Math = dataContext.Lectures.First(lc => lc.Name.Equals("Math"));
            Lecture History = dataContext.Lectures.First(lc => lc.Name.Equals("History"));
            Lecture Chemistry = dataContext.Lectures.First(lc => lc.Name.Equals("Chemistry"));
            Lecture Physics = dataContext.Lectures.First(lc => lc.Name.Equals("Physics"));
            Lecture Programming = dataContext.Lectures.First(lc => lc.Name.Equals("Programming"));

            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture() { Student = Carla, Lecture = Math });
            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture() { Student = Tonie, Lecture = Math });

            StudentLecture slTonie = new StudentLecture();
            slTonie.Student = Tonie;
            slTonie.LectureId = History.Id;
            dataContext.StudentLectures.InsertOnSubmit(slTonie);

            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture() { Student = Leyla, Lecture = Chemistry });

            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.StudentLectures;
        }

        public void GetUniversityOfTonie()
        {
            Student Tonie = dataContext.Students.First(st => st.Name.Equals("Tonie"));
            University ToniesUniversity = Tonie.University;

            List<University> universities = new List<University>();
            universities.Add(ToniesUniversity);

            MainDataGrid.ItemsSource = universities;
        }

        public void GetLecturesFromTonie()
        {
            Student Tonie = dataContext.Students.First(st => st.Name.Equals("Tonie"));
            var ToniesLectures = from sl in Tonie.StudentLectures select sl.Lecture;

            MainDataGrid.ItemsSource = ToniesLectures;
        }

        public void GetAllStudentsFromYale()
        {
            var studentsFromYale = from student in dataContext.Students
                                   where student.University.Name == "Yale"
                                   select student;
            MainDataGrid.ItemsSource = studentsFromYale;
        }

        public void GetAllUniversitiesWithFemales()
        {
            var femaleUniversities = from student in dataContext.Students
                                     join university in dataContext.Universities
                                     on student.University equals university
                                     where student.Gender == "female"
                                     select university;

            MainDataGrid.ItemsSource = femaleUniversities;
        }

        public void GetAllLecturesFromMIT()
        {
            var lecturesFromMIT = from sl in dataContext.StudentLectures
                                  join student in dataContext.Students
                                  on sl.StudentId equals student.Id
                                  where student.University.Name == "MIT"
                                  select sl.Lecture;

            MainDataGrid.ItemsSource = lecturesFromMIT;
        }

        public void UpdateTonie()
        {
            Student Tonie = dataContext.Students.FirstOrDefault(st => st.Name == "Tonie");
            //Student Tonie = (from student in dataContext.Students
            //                where student.Name == "Tonie"
            //                select student).First();
            Tonie.Name = "Antonio"; // Notice you don't need to do anything other than change the data then submit. 
            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Students;
        }

        public void DeleteJames()
        {
            Student James = dataContext.Students.FirstOrDefault(st => st.Name == "James");
            dataContext.Students.DeleteOnSubmit(James);
            dataContext.SubmitChanges();
            MainDataGrid.ItemsSource = dataContext.Students;
        }
    }
}
