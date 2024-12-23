using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Group
    {
        private string? groupname;
        private string? groupspecialization;
        private int coursenumber;
        private List<Student> students = new List<Student>();

        public Group()
        {

        }
        public Group(string? groupname, string? groupspecialization, int coursenumber)
        {
            SetGroupName(groupname);
            SetGroupSpecialization(groupspecialization);
            SetCourseNumber(coursenumber);
        }

        public void SetGroupName(string? groupname)
        {
            this.groupname = groupname;
        }
        public void SetCourseNumber(int coursenumber)
        {
            this.coursenumber = coursenumber;
        }
        public void SetGroupSpecialization(string? groupspecialization)
        {
            this.groupspecialization = groupspecialization;
        }


        public string? GetGroupName()
        {
            return groupname;
        }
        public string? GetGroupSpecialization()
        {
            return groupspecialization;
        }
        public int GetCourseNumber()
        {
            return coursenumber;
        }

        
        public void AddStudent(Student student)                     // добавление стундента в список студентов
        {
            students.Add(student);
        }

        public void ShowAllStudents()                              // показ всех студентов из листа
        {
            Console.WriteLine("Все студенты:");               
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine("Номер студента " + (i + 1));  
                Console.WriteLine(GetGroupName());
                Console.WriteLine(GetGroupSpecialization());
                Console.WriteLine(GetCourseNumber());
                students[i].ToString();
            }
        }

        public void RemoveStudent(Student student)                 // удалить студента
        {
            students.Remove(student);
        }

        public void TransferStudent(Student student, Group newgroup)  // перевод студента
        {
            students.Remove(student);
            newgroup.AddStudent(student);                             // наверное так будет. типа из листа в одном экземпляре удалили, в новый экземпляр в лист добавили
        }

        public void KickStudent()                                    // отчислить студента за неуспеваемость
        {
            if (students.Count == 0)
            {
                Console.WriteLine("В группе некого больше отчислять))))");
            }

            Student lowestscoringstudent = students[0];
            double lowestaveragescore = students[0].GetAverageScore();

            foreach (var student in students)
            {
                double averagescore = student.GetAverageScore();
                if (averagescore < lowestaveragescore)
                {
                    lowestscoringstudent = student;
                    lowestaveragescore = averagescore;
                }
            }
            students.Remove(lowestscoringstudent);

            Console.WriteLine("Был исключен");
        }

        public double GetGroupAverageScore()           // вычисляем средний балл у группы
        {
            if (students.Count == 0)
            {
                return 0;
            }

            double totalScore = 0;

            foreach (var student in students)
            {
                totalScore += student.GetAverageScore();
            }

            return totalScore / students.Count;
        }
    }
}

