using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{

    public class Student
    {
        private string? name;
        private string? lastname;
        private string? patron;
        private string? date;
        private string? address;
        private string? phone;
        private List<int> credits = new List<int>();
        private List<int> courseworks = new List<int>();
        private List<int> exams = new List<int>();

        public Student() : this("default", "deafoltov", "deafoltovich", "01.01.01", "North Korea", "haven't")
        {

        }
        public Student(string? name) : this(name, "Karp", "Vladimirovich", "05.09.91", "null", "null")
        {

        }
        public Student(string? name, string? lastname) : this(name, lastname, "Vladimirovich", "05.09.91", "null", "null")
        {

        }
        public Student(string? name, string? lastname, string? patron) : this(name, lastname, patron, "05.09.91", "null", "null")
        {

        }

        public Student(string? name, string? lastname, string? patron, string? date, string? address, string? phone)
        {
            SetName(name);
            SetLastName(lastname);
            SetPatron(patron);
            SetDate(date);
            SetAddress(address);
            SetPhone(phone);
        }


        public void SetName(string? name)
        {
            this.name = name;
        }
        public void SetLastName(string? lastname)
        {
            this.lastname = lastname;
        }
        public void SetPatron(string? patron)
        {
            this.patron = patron;
        }
        public void SetDate(string? date)
        {
            this.date = date;
        }
        public void SetAddress(string? address)
        {
            this.address = address;
        }
        public void SetPhone(string? phone)
        {
            this.phone = phone;
        }


        public string? GetName()
        {
            return name;
        }
        public string? GetLastName()
        {
            return lastname;
        }
        public string? GetPatron()
        {
            return patron;
        }
        public string? GetDate()
        {
            return date;
        }
        public string? GetAddress()
        {
            return address;
        }
        public string? GetPhone()
        {
            return phone;
        }



        public override string ToString()                 // ToString переопределил, но можно было и отдельный метод написать
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Имя: {GetName()}");
            sb.AppendLine($"Фамилия: {GetLastName()}");
            sb.AppendLine($"Отчество: {GetPatron()}");
            sb.AppendLine($"Дата рождения: {GetDate()}"); // тут интерполяцией проще вывести
            sb.AppendLine($"Адрес: {GetAddress()}");
            sb.AppendLine($"Телефон: {GetPhone()}");
            sb.AppendLine("Оценки студента:");

            foreach (var credit in credits)
            {
                sb.AppendLine(credit.ToString());
            }

            sb.AppendLine("Курсовые работы студента:");

            foreach (var coursework in courseworks)
            {
                sb.AppendLine(coursework.ToString());
            }
            sb.AppendLine("Экзамены студента:");

            foreach (var exam in exams)

            {
                sb.AppendLine(exam.ToString());
            }

            return sb.ToString();
        }

        public virtual double GetAverageScore()       // Средний балл успеваемости пришлось сделать
        {
            if (credits.Count == 0 && courseworks.Count == 0 && exams.Count == 0)
            {
                Console.WriteLine("Всё прогулял, без оценок)))))");
                return 0;
            }

            double totalscore = 0;
            int totalgrades = 0;

            foreach (var credit in credits)
            {
                totalscore += credit;
                totalgrades++;
            }

            foreach (var coursework in courseworks)
            {
                totalscore += coursework;
                totalgrades++;
            }

            foreach (var exam in exams)
            {
                totalscore += exam;
                totalgrades++;
            }

            return totalscore / totalgrades;
        }


    }
}
