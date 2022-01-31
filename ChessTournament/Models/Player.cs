using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament
{
    class Player
    {
        //fields
        private int _clarity;
        private int _profficiencyBonus;
        private int _hitPoints;
        private int _age;
        private static Random _rand = new Random();

        //properties
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = NameValidaton(value);
            }
        }
        public int ID { get; set; }
        public DateTime BirthDate { get; set; }
        public int Rating { get; set; }

        public int Mentality { get; set; } = _rand.Next(1, 70);
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = GetAge(BirthDate);
            }
        }
        public int Clarity
        {
            get
            {
                return _clarity;
            }
            set
            {
                _clarity = GetClarity(Age);
            }

        }
        public int ProfficiencyBonus
        {
            get
            {
                return _profficiencyBonus;
            }
            set
            {
                _profficiencyBonus = GetProfBonus(Rating);
            }
        }
        public int HitPoints
        {
            get
            {
                return _hitPoints;
            }
            set
            {
                _hitPoints = GetHitPoints(ProfficiencyBonus, Age);
            }
        }

        //Constructors
        public Player() { }
        public Player(string name, int id, DateTime birthDate, int rating)
        {
            Name = NameValidaton(name);
            ID = id;
            BirthDate = birthDate;
            Rating = rating;
            ProfficiencyBonus = GetProfBonus(rating);
            Age = GetAge(birthDate);
            Clarity = GetClarity(Age);
            HitPoints = GetHitPoints(ProfficiencyBonus, Age);
        }
        //Validation
        private string NameValidaton(string name)
        {
            string result = name.ToLower();
            result = char.ToUpper(name[0]) + name.Substring(1);
            return result;
        }

        //Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append("Player: ")
                sb.Append($" {Name} ");
                //.Append($"ID-{ID}, ")
                //.Append($"Rating-{Rating}, ")
                //.Append($"Day of birth-{BirthDate}, ");
                //.Append($" Mentality {Mentality}, ")
                //.Append($" Prof. Bolnus {ProfficiencyBonus}, ")
                //.Append($" Age {Age}, ")
                //.Append($" Clarity {Clarity}, ");
            return sb.ToString();
        }

        private int GetProfBonus(int rating)
        {

            int profBonus = (rating - 1200) / 15;

            return profBonus;
        }

        private int GetAge(DateTime dob)
        {
            int age = DateTime.Now.Subtract(dob).Days;
            age = age / 365;
            return age;
        }

        private int GetClarity(int age)
        {
            int clarity = 0;
            if (age < 18)
                clarity = 5;
            else if (age >= 18 && age < 40)
                clarity = 30;
            else if (age >= 40 && age < 65)
                clarity = 15;
            else if (age >= 65)
                clarity = 0;
            return clarity;
        }

        public static int GetHitPoints(int profBonus, int age)
        {
            int hitPoints = (profBonus * 100) + (age * 5);
            return hitPoints;
        }

        public override bool Equals(object obj)
        {
            return obj is Player player &&
                   _name == player._name &&
                   Name == player.Name &&
                   ID == player.ID &&
                   BirthDate == player.BirthDate;
        }

        public override int GetHashCode()
        {
            int hashCode = 14256013;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + ID.GetHashCode();
            hashCode = hashCode * -1521134295 + BirthDate.GetHashCode();
            hashCode = hashCode * -1521134295 + Rating.GetHashCode();
            return hashCode;
        }
    }
}
