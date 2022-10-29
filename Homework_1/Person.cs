namespace Homework_1
{
    public class Person
    {
        private string _fullName;
        private string _email;
        private int _age;
        private float _scoreProgramming;
        private float _scoreMath;
        private float _scorePhysics;

        public Person(string fullName, string email, int age, float pointProgramming, float pointMath, float pointPhysics)
        {
            _fullName = fullName;
            _email = email;
            _age = age;
            _scoreProgramming = pointProgramming;
            _scoreMath = pointMath;
            _scorePhysics = pointPhysics;
        }

        public string GetInfo()
        {
            return $"Полное имя: {_fullName} \n" +
                   $"Email: {_email} \n" +
                   $"Возраст: {_age} \n" +
                   $"Балл по программированию: {_scoreProgramming} \n" +
                   $"Балл по математике: {_scoreMath} \n" +
                   $"Балл по физике: {_scorePhysics} \n";
        }

        public string GetInfoAvgScore()
        {
            float sumScore = _scoreMath + _scoreMath + _scorePhysics;
            float avgScore = sumScore / 3;

            return $"Средний балл по всем предметам: {avgScore.ToString("#.##")} \n";
        }
    }
}
