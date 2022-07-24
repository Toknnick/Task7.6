using System;
using System.Collections.Generic;
using System.Linq;

namespace Task7._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Barrack barrack = new Barrack();
            barrack.Work();
        }
    }

    class Barrack
    {
        private List<Soldier> _soldiers = new List<Soldier>();

        public Barrack()
        {
            AddSoldiers();
        }

        public void Work()
        {
            ShowAllSoldiers();
            Console.WriteLine();
            IOrderedEnumerable<Soldier> sortedSoldiers = _soldiers.OrderBy(soldier => soldier.Name);
            ShowSortedSoldiers(sortedSoldiers);
        }

        private void ShowAllSoldiers()
        {
            Console.WriteLine("Солдаты в казарме:");

            foreach (Soldier soldier in _soldiers)
                soldier.ShowInfo();
        }

        private void ShowSortedSoldiers(IOrderedEnumerable<Soldier> sortedSoldiers)
        {
            foreach (Soldier soldier in sortedSoldiers)
                soldier.ShowSortedInfo();
        }

        private void AddSoldiers()
        {
            Random random = new Random();
            int countOfSoldiers = 10;
            int maxValue = 12;
            int countOfGuns = 4;
            int countOfRanks = 3;

            for (int i = 0; i < countOfSoldiers; i++)
            {
                int lifeTime = random.Next(maxValue);
                int numberOfGun = random.Next(countOfGuns);
                int numberOfRank = random.Next(countOfRanks);
                _soldiers.Add(new Soldier(SetNameOfsoldier(i), SetGunOfsoldier(numberOfGun), SetRankOfsoldier(numberOfRank), lifeTime));
            }
        }

        private string SetNameOfsoldier(int numberOfName)
        {
            List<string> namesOfsoldiers = new List<string>
            {
            "Анна",
            "Святослав",
            "Марк",
            "Вероника",
            "Матвей",
            "Элина",
            "Таисия",
            "Антон",
            "Арина",
            "Александр",
            "Сафия",
            "Никита",
            "Елизавета",
            "Кира",
            "София",
            "Олег",
            "Марианна",
            "Варвара",
            "Юрий",
            "Георгий"
            };
            string name = namesOfsoldiers[numberOfName];
            return name;
        }

        private string SetGunOfsoldier(int numberOfGun)
        {
            List<string> gunsOfsoldiers = new List<string>
            {
            "пистолет",
            "автомат",
            "РПГ",
            "танк",
            };
            string gun = gunsOfsoldiers[numberOfGun];
            return gun;
        }

        private string SetRankOfsoldier(int numberOfRank)
        {
            List<string> ranksOfsoldiers = new List<string>
            {
            "сержант",
            "капитан",
            "генерал",
            };
            string rank = ranksOfsoldiers[numberOfRank];
            return rank;
        }
    }

    class Soldier
    {
        public string Rank { get; private set; }
        public string Name { get; private set; }

        private string _gun;
        private int _lifeTime;

        public Soldier(string name, string gun, string rank, int lifeTime)
        {
            Name = name;
            _gun = gun;
            Rank = rank;
            _lifeTime = lifeTime;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name}. Оружие: {_gun}. Звание: {Rank}. Срок службы: {_lifeTime} месяцев.");
        }

        public void ShowSortedInfo()
        {
            Console.WriteLine($"{Name}.Звание: {Rank}.");
        }
    }
}
