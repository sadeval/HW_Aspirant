using System;
using System.Collections.Generic;

namespace StudentManagement
{
    class Student
    {
        // Поля для хранения данных
        protected string? name;
        protected string? patronymic;
        protected string? surname;
        private DateTime birthDate;
        private string? address;
        private string? phone;

        // Поля для хранения оценок
        private LinkedList<int> marks = new LinkedList<int>(); // Зачёты
        private LinkedList<int> courseworks = new LinkedList<int>(); // Курсовые работы
        private LinkedList<int> exams = new LinkedList<int>(); // Экзамены
        private double rating; // Рейтинг

        // Конструктор без параметров
        public Student() : this("Unknown", "Unknown", "Unknown", DateTime.MinValue, "Unknown", "Unknown")
        {
            Console.WriteLine("Constructor without parameters");
        }

        // Конструктор с параметрами: имя, отчество, фамилия
        public Student(string name, string patronymic, string surname) : this(name, patronymic, surname, DateTime.MinValue, "Unknown", "Unknown")
        {
            Console.WriteLine("Constructor with name, patronymic, surname");
        }

        // Конструктор с параметрами: имя, отчество, фамилия, адрес
        public Student(string name, string patronymic, string surname, string address) : this(name, patronymic, surname, DateTime.MinValue, address, "Unknown")
        {
            Console.WriteLine("Constructor with name, patronymic, surname, address");
        }

        // Основной конструктор с параметрами: имя, отчество, фамилия, дата рождения, адрес, телефон
        public Student(string name, string patronymic, string surname, DateTime birthDate, string address, string phone)
        {
            SetName(name);
            SetPatronymic(patronymic);
            SetSurname(surname);
            SetBirthDate(birthDate);
            SetAddress(address);
            SetPhone(phone);
            Console.WriteLine("Main constructor with all parameters");
        }

        // Методы для установки полей
        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetPatronymic(string patronymic)
        {
            this.patronymic = patronymic;
        }

        public void SetSurname(string surname)
        {
            this.surname = surname;
        }

        public void SetBirthDate(DateTime birthDate)
        {
            this.birthDate = birthDate;
        }

        public void SetAddress(string address)
        {
            this.address = address;
        }

        public void SetPhone(string phone)
        {
            this.phone = phone;
        }

        // Методы для добавления оценок в зачёты, курсовые работы и экзамены
        public virtual void AddMark(int value)
        {
            if (value < 1 || value > 12) return;
            marks.AddLast(value);
            ResetRating();
        }

        public virtual void AddCoursework(int value)
        {
            if (value < 1 || value > 12) return;
            courseworks.AddLast(value);
            ResetRating();
        }

        public virtual void AddExam(int value)
        {
            if (value < 1 || value > 12) return;
            exams.AddLast(value);
            ResetRating();
        }

        // Показ всех данных о студенте
        public virtual void PrintStudent()
        {
            Console.WriteLine($"Имя: {name}");
            Console.WriteLine($"Отчество: {patronymic}");
            Console.WriteLine($"Фамилия: {surname}");
            Console.WriteLine($"Дата рождения: {birthDate.ToShortDateString()}");
            Console.WriteLine($"Адрес: {address}");
            Console.WriteLine($"Номер телефона: {phone}");
            Console.Write("Оценки по зачётам: ");
            foreach (var mark in marks)
            {
                Console.Write($"{mark} ");
            }
            Console.WriteLine();
            Console.Write("Оценки по курсовым: ");
            foreach (var coursework in courseworks)
            {
                Console.Write($"{coursework} ");
            }
            Console.WriteLine();
            Console.Write("Оценки по экзаменам: ");
            foreach (var exam in exams)
            {
                Console.Write($"{exam} ");
            }
            Console.WriteLine();
            Console.WriteLine($"Рейтинг оценок: {rating:F1}");
        }

        // Метод для пересчета рейтинга
        private void ResetRating()
        {
            int totalGradesCount = marks.Count + courseworks.Count + exams.Count;

            if (totalGradesCount == 0)
            {
                rating = 0;
                return;
            }

            int totalSum = CalculateSum(marks) + CalculateSum(courseworks) + CalculateSum(exams);
            rating = (double)totalSum / totalGradesCount;
        }

        // Метод для вычисления суммы значений
        private int CalculateSum(LinkedList<int> list)
        {
            int sum = 0;
            foreach (var item in list)
            {
                sum += item;
            }
            return sum;
        }

        public virtual void Study()
        {
            Console.WriteLine($"Студент {name} учится.");
        }

        public virtual void TakeExam()
        {
            Console.WriteLine($"Студент {name} сдаёт экзамен.");
        }
    }

    // Класс для Аспиранта
    class Aspirant : Student
    {
        // Дополнительное поле для аспиранта
        private string? thesisTheme; // Тема диссертации

        // Конструкторы
        public Aspirant() : base()
        {
            Console.WriteLine("Aspirant constructor without parameters");
        }

        public Aspirant(string name, string patronymic, string surname) : base(name, patronymic, surname)
        {
            Console.WriteLine("Aspirant constructor with name, patronymic, surname");
        }

        public Aspirant(string name, string patronymic, string surname, string address) : base(name, patronymic, surname, address)
        {
            Console.WriteLine("Aspirant constructor with name, patronymic, surname, address");
        }

        public Aspirant(string name, string patronymic, string surname, DateTime birthDate, string address, string phone, string thesisTheme)
            : base(name, patronymic, surname, birthDate, address, phone)
        {
            this.thesisTheme = thesisTheme;
            Console.WriteLine("Aspirant main constructor with all parameters");
        }

        // Свойство для темы диссертации
        public string? ThesisTheme
        {
            get { return thesisTheme; }
            set { thesisTheme = value; }
        }

        // Методы для аспиранта
        public void DoIntership()
        {
            Console.WriteLine($"Аспирант {name} выполняет стажировку.");
        }

        public void DefendThesis()
        {
            Console.WriteLine($"Аспирант {name} защищает диссертацию на тему: {thesisTheme}");
        }

        // Переопределение метода базового класса для аспиранта
        public override void PrintStudent()
        {
            base.PrintStudent();
            Console.WriteLine($"Тема диссертации: {thesisTheme}");
        }

        // Переопределение метода AddMark для аспиранта
        public override void AddMark(int value)
        {
            if (value < 1 || value > 12)
            {
                Console.WriteLine("Оценка должна быть в диапазоне от 1 до 12.");
                return;
            }

            base.AddMark(value);
            Console.WriteLine($"Аспирант {name} получил оценку за зачёт: {value}");
        }

        // Переопределение метода AddExam для аспиранта
        public override void AddExam(int value)
        {
            if (value < 1 || value > 12)
            {
                Console.WriteLine("Оценка должна быть в диапазоне от 1 до 12.");
                return;
            }

            base.AddExam(value);
            Console.WriteLine($"Аспирант {name} получил оценку за экзамен: {value}");
        }

        // Переопределение метода Study для аспиранта
        public override void Study()
        {
            Console.WriteLine($"Аспирант {name} занимается исследовательской работой.");
        }

        // Переопределение метода TakeExam для аспиранта
        public override void TakeExam()
        {
            Console.WriteLine($"Аспирант {name} сдаёт квалификационный экзамен.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Пример класса Aspirant
            Aspirant aspirant = new Aspirant("Петр", "Иванович", "Васечкин",
                new DateTime(1990, 5, 15), "ул. Парусная, д. 10", "+380955289876", "Исследование алгоритмов машинного обучения");

            aspirant.AddMark(10);
            aspirant.AddCoursework(11);
            aspirant.AddExam(12);

            aspirant.Study();
            aspirant.TakeExam();
            aspirant.DoIntership();
            aspirant.DefendThesis();

            Console.WriteLine();
            aspirant.PrintStudent();
        }
    }
}


