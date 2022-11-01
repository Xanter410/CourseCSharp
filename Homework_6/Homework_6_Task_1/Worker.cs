using System;

namespace Homework_6_Task_1
{
    struct Worker
    {
        public int Id { get; set; }
        public DateTime DateAndTimeOfCreation { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }

        public Worker(int Id,DateTime DateAndTimeOfCreation, string FullName, int Age, int Height, DateTime DateOfBirth, string PlaceOfBirth)
        {
            this.Id = Id;
            this.DateAndTimeOfCreation = DateAndTimeOfCreation;
            this.FullName = FullName;
            this.Age = Age;
            this.Height = Height;
            this.DateOfBirth = DateOfBirth;
            this.PlaceOfBirth = PlaceOfBirth;
        }
        public Worker(DateTime DateAndTimeOfCreation, string FullName, int Age, int Height, DateTime DateOfBirth, string PlaceOfBirth) : 
            this(0, DateAndTimeOfCreation , FullName, Age, Height, DateOfBirth, PlaceOfBirth) {}
        public Worker(string FullName, int Age, int Height, DateTime DateOfBirth, string PlaceOfBirth) :
            this(0, DateTime.Now, FullName, Age, Height, DateOfBirth, PlaceOfBirth)
        { }

        public string Print()
        {
            return $"{Id, 3} {DateAndTimeOfCreation,25} {FullName,35} {Age,10} {Height,7} {DateOfBirth.ToShortDateString(),15} {PlaceOfBirth,20}";
        }
    }
}
