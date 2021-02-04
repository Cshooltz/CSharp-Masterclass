using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSMasterClass
{
    class LinqWithXML
    {
        public static void Main()
        {
            string studentsXML =
                @"<Students>
                    <Student>
                        <Name>Toni</Name>
                        <Age>21</Age>
                        <University>Yale</University>
                        <Year>1</Year>
                    </Student>
                    <Student>
                        <Name>Carla</Name>
                        <Age>17</Age>
                        <University>Yale</University>
                        <Year>4</Year>
                    </Student>
                    <Student>
                        <Name>Leyla</Name>
                        <Age>19</Age>
                        <University>Beijing Tech</University>
                        <Year>2</Year>
                    </Student>
                    <Student>
                        <Name>Zack</Name>
                        <Age>30</Age>
                        <University>Beijing Tech</University>
                        <Year>9</Year>
                    </Student>
                </Students>";

            XDocument studentsXDoc = new XDocument();
            studentsXDoc = XDocument.Parse(studentsXML);

            var students = from student in studentsXDoc.Descendants("Student")
                           orderby student.Element("Age").Value ascending
                           select new
                           {
                               Name = student.Element("Name").Value,
                               Age = student.Element("Age").Value,
                               University = student.Element("University").Value,
                               Year = student.Element("Year").Value
                           };

            foreach(var student in students)
            {
                Console.WriteLine($"Student {student.Name} with age {student.Age} is in year {student.Year} at {student.University} University.");
            }
        }
    }
}
