namespace Courses.Data.EF
{
    public static class DataDB
    {
        public static void Initialize(CoursesContext coursesContext)
        {
            if (!coursesContext.Courses.Any())
            {
                coursesContext.Courses.AddRange(
                    new Course
                    {
                        Name = "C#",
                        Description = "Курс по C#/.Net предназначен для тех, кто хочет получить перспективную и высокооплачиваемую работу C# разработчика. Задания курса строятся от самых простых (исполняя которые, вы научитесь писать правильный и хорошо структурированный код C#), до супер-востребованных сейчас на рынке WinForms и .Net Core. По завершению курса вы сами сможете решить, какое направление для вас ближе — WinForms или .Net Core разработка."
                    },
                    new Course
                    {
                        Name = "Java",
                        Description = "Мы все знаем, что не достаточно знать язык Java, чтобы найти работу. Требуется знание многих фреймворков и еще масса умений (от умения находить ответ в интернете до умения себя продать). Можно было бы пойти по проторенной дороге и повторять учебные курсы так, как мы и сами когда-то учили. Вместо этого, мы спросили рынок - что ему надо и составили наш курс только из тех вопросов, которые рынок требует, безжалостно исключив из него все, что может пригодитс."
                    },
                    new Course
                    {
                        Name = "JS",
                        Description = "Изучите самый популярный язык разработки и станьте высокооплачиваемым профессионалом. В курсе собраны лишь самые актуальные и востребованные в 2022 году знания по JS – для современной веб-разработки"
                    },
                    new Course
                    {
                        Name = "Python",
                        Description = "Наш курс Python состоит из практических заданий. В процессе обучения вы научитесь писать приложения на таких фреймворках как Flask и Django, получите навыки проектирования структуры баз данных, создадите собственную инфраструктуру с несколькими сервисами и воспользуетесь несколькими фронтенд-инструментами. Также научитесь писать Unit тесты и попробуете разные подходы BDD и TDD, напишете собственные Python пакеты. В результате созданные вами веб - приложения сможете добавить в свое портфолио."
                    }
                    );
                coursesContext.SaveChanges();
            }

            if (!coursesContext.Groups.Any())
            {
                coursesContext.Groups.AddRange(
                    new Group
                    {
                        CourseId = 1,
                        Name = "SR-01"
                    },
                    new Group
                    {
                        CourseId = 2,
                        Name = "SR-02"
                    },
                    new Group
                    {
                        CourseId = 3,
                        Name = "SR-03"
                    },
                    new Group
                    {
                        CourseId = 4,
                        Name = "SR-04",
                    }
                    );
                coursesContext.SaveChanges();
            }

            if (!coursesContext.Students.Any())
            {
                coursesContext.Students.AddRange(
                    new Student
                    {
                        GroupId = 1,
                        FirstName = "Andrey",
                        LastName = "Andreev"
                    },
                    new Student
                    {
                        GroupId = 1,
                        FirstName = "Boris",
                        LastName = "Borisov"
                    },
                    new Student
                    {
                        GroupId = 1,
                        FirstName = "Vladimir",
                        LastName = "Vladimirov"
                    },
                    new Student
                    {
                        GroupId = 1,
                        FirstName = "Grigoriy",
                        LastName = "Grigoriev"
                    },
                    new Student
                    {
                        GroupId = 1,
                        FirstName = "Dmitriy",
                        LastName = "Dmitriev"
                    },
                    new Student
                    {
                        GroupId = 1,
                        FirstName = "Evgeniy",
                        LastName = "Evgeniev"
                    },
                    new Student
                    {
                        GroupId = 1,
                        FirstName = "Zahar",
                        LastName = "Zaharov"
                    },
                    new Student
                    {
                        GroupId = 1,
                        FirstName = "Konstantin",
                        LastName = "Konstantinov"
                    },
                    new Student
                    {
                        GroupId = 1,
                        FirstName = "Leinid",
                        LastName = "Leinidov"
                    },
                    new Student
                    {
                        GroupId = 1,
                        FirstName = "Mihail",
                        LastName = "Mihailov"
                    },
                    new Student
                    {
                        GroupId = 1,
                        FirstName = "Nikita",
                        LastName = "Nikitiev"
                    },
                    new Student
                    {
                        GroupId = 1,
                        FirstName = "Oleg",
                        LastName = "Olegov"
                    },
                    new Student
                    {
                        GroupId = 2,
                        FirstName = "Polina",
                        LastName = "Polinska"
                    },
                    new Student
                    {
                        GroupId = 2,
                        FirstName = "Raisa",
                        LastName = "Raisova"
                    },
                    new Student
                    {
                        GroupId = 3,
                        FirstName = "Timyr",
                        LastName = "Timyridze"
                    },
                    new Student
                    {
                        GroupId = 4,
                        FirstName = "Fabia",
                        LastName = "Fainshtein"
                    },
                    new Student
                    {
                        GroupId = 4,
                        FirstName = "Hoogo",
                        LastName = "Haikes"
                    },
                    new Student
                    {
                        GroupId = 4,
                        FirstName = "Jadviga",
                        LastName = "Jagnish"
                    }
                    );
                coursesContext.SaveChanges();
            }
        }
    }
}