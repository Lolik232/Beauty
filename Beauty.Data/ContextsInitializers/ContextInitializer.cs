using Beauty.Data.Contexts;
using Beauty.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Beauty.Data.ContextsInitializers
{
    public class ContextInitializer : DropCreateDatabaseIfModelChanges<StandartContext>
    //public class ContextInitializer : DropCreateDatabaseAlways<StandartContext>
    {
        protected override void Seed(StandartContext context)
        {
            context.Positions.AddRange(new List<Position>()
            {
                new Position()
                {
                    Id = 1,
                    Title = "Руководитель"
                },
                new Position()
                {
                    Id = 2,
                    Title = "Администратор"
                },
                new Position()
                {
                    Id = 3,
                    Title = "Косметолог"
                },
                new Position()
                {
                    Id = 4,
                    Title = "Парикмахер"
                },
                new Position()
                {
                    Id = 5,
                    Title = "Маникюрист"
                },
                new Position()
                {
                    Id = 6,
                    Title = "Мастер шугаринга"
                },
                new Position()
                {
                    Id = 7,
                    Title = "Brow-мастер"
                },
                new Position()
                {
                    Id = 8,
                    Title = "Визажист"
                },
                new Position()
                {
                    Id = 9,
                    Title = "Разработчик"
                }
            });

            context.Services.AddRange(new List<Service>()
            {
                new Service()
                {
                    Id = 1,
                    Title = "Детская стрижка волос"
                },
                new Service()
                {
                    Id = 2,
                    Title = "Мужская стрижка волос"
                },
                new Service()
                {
                    Id = 3,
                    Title = "Женская стрижка волос"
                },
                new Service()
                {
                    Id = 4,
                    Title = "Окрашивание волос"
                },
                new Service()
                {
                    Id = 5,
                    Title = "Укладка волос"
                },
                new Service()
                {
                    Id = 6,
                    Title = "Мелирование волос"
                },
                new Service()
                {
                    Id = 7,
                    Title = "Маникюр"
                },
                new Service()
                {
                    Id = 8,
                    Title = "Педикюр"
                },
                new Service()
                {
                    Id = 9,
                    Title = "Снятие лака"
                },
                new Service()
                {
                    Id = 10,
                    Title = "Покрытие лаком"
                },
                new Service()
                {
                    Id = 11,
                    Title = "Покрытие лаком с дизайном"
                },
                new Service()
                {
                    Id = 12,
                    Title = "Шугаринг до колена"
                },
                new Service()
                {
                    Id = 13,
                    Title = "Полный шугаринг"
                },
                new Service()
                {
                    Id = 14,
                    Title = "Шугаринг (бикини классическое)"
                },
                new Service()
                {
                    Id = 15,
                    Title = "Шугаринг (бикини глубокое)"
                },
                new Service()
                {
                    Id = 16,
                    Title = "Шугаринг (подмышки)"
                },
                new Service()
                {
                    Id = 17,
                    Title = "Тридинг"
                },
                new Service()
                {
                    Id = 18,
                    Title = "Уход за лицом"
                },
                new Service()
                {
                    Id = 19,
                    Title = "Чистка лица"
                },
                new Service()
                {
                    Id = 20,
                    Title = "Окрашивание бровей"
                },
                new Service()
                {
                    Id = 21,
                    Title = "Коррекция бровей"
                },
                new Service()
                {
                    Id = 22,
                    Title = "Массаж"
                },
                new Service()
                {
                    Id = 23,
                    Title = "Плетение кос"
                }
            });

            context.PositionServices.AddRange(new List<PositionService>()
            {
                new PositionService()
                {
                    Id = 1,
                    PositionId = 3,
                    ServiceId = 17
                },
                new PositionService()
                {
                    Id = 2,
                    PositionId = 3,
                    ServiceId = 18
                },
                new PositionService()
                {
                    Id = 3,
                    PositionId = 3,
                    ServiceId = 19
                },
                new PositionService()
                {
                    Id = 4,
                    PositionId = 4,
                    ServiceId = 1
                },
                new PositionService()
                {
                    Id = 5,
                    PositionId = 4,
                    ServiceId = 2
                },
                new PositionService()
                {
                    Id = 6,
                    PositionId = 4,
                    ServiceId = 3
                },
                new PositionService()
                {
                    Id = 7,
                    PositionId = 4,
                    ServiceId = 4
                },
                new PositionService()
                {
                    Id = 8,
                    PositionId = 4,
                    ServiceId = 5
                },
                new PositionService()
                {
                    Id = 9,
                    PositionId = 4,
                    ServiceId = 6
                },
                new PositionService()
                {
                    Id = 10,
                    PositionId = 4,
                    ServiceId = 23
                },
                new PositionService()
                {
                    Id = 11,
                    PositionId = 5,
                    ServiceId = 7
                },
                new PositionService()
                {
                    Id = 12,
                    PositionId = 5,
                    ServiceId = 8
                },
                new PositionService()
                {
                    Id = 13,
                    PositionId = 5,
                    ServiceId = 9
                },
                new PositionService()
                {
                    Id = 14,
                    PositionId = 5,
                    ServiceId = 10
                },
                new PositionService()
                {
                    Id = 15,
                    PositionId = 5,
                    ServiceId = 11
                },
                new PositionService()
                {
                    Id = 16,
                    PositionId = 6,
                    ServiceId = 12
                },
                new PositionService()
                {
                    Id = 17,
                    PositionId = 6,
                    ServiceId = 13
                },
                new PositionService()
                {
                    Id = 18,
                    PositionId = 6,
                    ServiceId = 14
                },
                new PositionService()
                {
                    Id = 19,
                    PositionId = 6,
                    ServiceId = 15
                },
                new PositionService()
                {
                    Id = 20,
                    PositionId = 6,
                    ServiceId = 16
                },
                new PositionService()
                {
                    Id = 21,
                    PositionId = 7,
                    ServiceId = 20
                },
                new PositionService()
                {
                    Id = 22,
                    PositionId = 7,
                    ServiceId = 21
                }
            });

            context.Workers.AddRange(new List<Worker>()
            {
                new Worker()
                {
                    Id = 1,
                    Firstname = "Алевтина",
                    Middlename = "Борисовна",
                    PasswordHash = "38f42f81a295a5e3ce2be60f43919cc4"
                },
                new Worker()
                {
                    Id = 2,
                    Firstname = "Оксана",
                    PasswordHash = "21c648508754a68839e370fe75f68af9"
                },
                new Worker()
                {
                    Id = 3,
                    Firstname = "Ольга",
                    PasswordHash = "24c8dc4536563775bf57e22bef3d4a52"
                },
                new Worker()
                {
                    Id = 4,
                    Firstname = "Евгения",
                    PasswordHash = "5a0922d1cf904c3a58c6aca9dda1936b"
                },
                new Worker()
                {
                    Id = 5,
                    Firstname = "Наталья",
                    PasswordHash = "519d457652a58f08fe557ce8d6494137"
                },
                new Worker()
                {
                    Id = 6,
                    Firstname = "Резеда",
                    PasswordHash = "9e9a83ba89fed4be68cd739ffadd8c21"
                },
                new Worker()
                {
                    Id = 7,
                    Firstname = "Юлия",
                    PasswordHash = "7e00a3726d3ddd8bbf65da049fc6f867"
                },
                new Worker()
                {
                    Id = 8,
                    Firstname = "Ирина",
                    PasswordHash = "69d6f3730f71838d860857e9d7df2b34"
                },
                new Worker()
                {
                    Id = 9,
                    Firstname = "Каролина",
                    PasswordHash = "7829a9ce03f4c6e77bab4780555de525"
                },
                new Worker()
                {
                    Id = 10,
                    Lastname = "Наумова",
                    Firstname = "Ольга",
                    PasswordHash = "049e86cc938efcb4e9049d261a5aec9e"
                },
                new Worker()
                {
                    Id = 11,
                    Firstname = "Никита",
                    PasswordHash = "4c92c4dccb672f36108e1dcf467b6c98"
                }
            });

            context.WorkerPositions.AddRange(new List<WorkerPosition>()
            {
                new WorkerPosition()
                {
                    Id = 1,
                    WorkerId = 1,
                    PositionId = 1
                },
                new WorkerPosition()
                {
                    Id = 2,
                    WorkerId = 1,
                    PositionId = 3
                },
                new WorkerPosition()
                {
                    Id = 3,
                    WorkerId = 2,
                    PositionId = 2
                },
                new WorkerPosition()
                {
                    Id = 4,
                    WorkerId = 2,
                    PositionId = 7
                },
                new WorkerPosition()
                {
                    Id = 5,
                    WorkerId = 3,
                    PositionId = 4
                },
                new WorkerPosition()
                {
                    Id = 6,
                    WorkerId = 4,
                    PositionId = 4
                },
                new WorkerPosition()
                {
                    Id = 7,
                    WorkerId = 5,
                    PositionId = 4
                },
                new WorkerPosition()
                {
                    Id = 8,
                    WorkerId = 6,
                    PositionId = 4
                },
                new WorkerPosition()
                {
                    Id = 9,
                    WorkerId = 7,
                    PositionId = 5
                },
                new WorkerPosition()
                {
                    Id = 10,
                    WorkerId = 8,
                    PositionId = 5
                },
                new WorkerPosition()
                {
                    Id = 11,
                    WorkerId = 9,
                    PositionId = 2
                },
                new WorkerPosition()
                {
                    Id = 12,
                    WorkerId = 9,
                    PositionId = 6
                },
                new WorkerPosition()
                {
                    Id = 13,
                    WorkerId = 10,
                    PositionId = 8
                },
                new WorkerPosition()
                {
                    Id = 14,
                    WorkerId = 11,
                    PositionId = 9
                }
            });

            //context.States.AddRange(new List<State>()
            //{
            //    new State()
            //    {
            //        Id = 1,
            //        Title = "Отменен",
            //        HexColorCode = "#FF6F6F"
            //    },
            //    new State()
            //    {
            //        Id = 2,
            //        Title = "Ожидание",
            //        HexColorCode = "#FF9B2A"
            //    },
            //    new State()
            //    {
            //        Id = 3,
            //        Title = "В процессе",
            //        HexColorCode = "#00C5FE"
            //    },
            //    new State()
            //    {
            //        Id = 4,
            //        Title = "Завершен",
            //        HexColorCode = "#94E484"
            //    }
            //});

            //context.DayTypes.AddRange(new List<DayType>()
            //{
            //    new DayType()
            //    {
            //        Id = 1,
            //        Title = "Рабочий день"
            //    },
            //    new DayType()
            //    {
            //        Id = 2,
            //        Title = "Выходной день"
            //    },
            //    new DayType()
            //    {
            //        Id = 3,
            //        Title = "Отпуск"
            //    }
            //});

            var dateTimeNow = DateTime.Now;
            
            context.Enrollments.AddRange(new List<Enrollment>()
            { 
                new Enrollment()
                {
                    Id = 1,
                    ClientFirstname = "Никита",
                    ClientPhoneNumber = "+7 (123) 456-78-90",
                    DateTime = dateTimeNow.AddDays(-1.0),
                    CreationDateTime = dateTimeNow,
                    EditDateTime = dateTimeNow
                },
                new Enrollment()
                {
                    Id = 2,
                    ClientFirstname = "Оксана",
                    ClientPhoneNumber = "+7 (098) 765-43-21",
                    Description = "Здесь описание заявки",
                    DateTime = dateTimeNow,
                    CreationDateTime = dateTimeNow
                }
            });

            context.EnrollmentWorkerServices.AddRange(new List<EnrollmentWorkerService>()
            {
                new EnrollmentWorkerService()
                {
                    EnrollmentId = 1,
                    WorkerId = 4,
                    ServiceId = 2
                },
                new EnrollmentWorkerService()
                {
                    EnrollmentId = 1,
                    WorkerId = 4,
                    ServiceId = 5
                },
                new EnrollmentWorkerService()
                {
                    EnrollmentId = 1,
                    WorkerId = 1,
                    ServiceId = 17
                },
                new EnrollmentWorkerService()
                {
                    EnrollmentId = 1,
                    WorkerId = 4,
                    ServiceId = 6
                },
                new EnrollmentWorkerService()
                {
                    EnrollmentId = 2,
                    WorkerId = 5,
                    ServiceId = 4
                },
                new EnrollmentWorkerService()
                {
                    EnrollmentId = 2,
                    WorkerId = 5,
                    ServiceId = 3
                },
                new EnrollmentWorkerService()
                {
                    EnrollmentId = 2,
                    WorkerId = 2,
                    ServiceId = 17
                },
                new EnrollmentWorkerService()
                {
                    EnrollmentId = 2,
                    WorkerId = 5,
                    ServiceId = 6
                }
            });

            context.SaveChanges();
        }
    }
}
