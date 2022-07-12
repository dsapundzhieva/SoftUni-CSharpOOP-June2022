
namespace MilitaryElite.Core
{
    using System;

    using System.Linq;

    using System.Collections.Generic;

    using MilitaryElite.Contracts;

    using MilitaryElite.Models;
    using MilitaryElite.Enums;
    using MilitaryElite.Models.Contracts;

    public class Engine : IEngine
    {
        private readonly Dictionary<int, ISoldier> soldiers;

        public Engine()
        {
            this.soldiers = new Dictionary<int, ISoldier>();
        }
        public void Start()
        {
            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                try
                {
                    var inputInfo = command
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                  .ToArray();

                    string result = this.Read(inputInfo);

                    Console.WriteLine(result);
                }
                catch (Exception)
                {
                }
            }

        }

        private string Read(string[] inputInfo)
        {
            string soldierType = inputInfo[0];
            int id = int.Parse(inputInfo[1]);
            string firstName = inputInfo[2];
            string lastName = inputInfo[3];

            ISoldier soldier = null;

            if (soldierType == "Private")
            {
                decimal salary = decimal.Parse(inputInfo[4]);
                soldier = new Private(firstName, lastName, id, salary);
            }
            else if (soldierType == "LieutenantGeneral")
            {
                decimal salary = decimal.Parse(inputInfo[4]);
                Dictionary<int, IPrivate> privates = new Dictionary<int, IPrivate>();

                for (int i = 5; i < inputInfo.Length; i++)
                {
                    int soldierId = int.Parse(inputInfo[i]);
                    var currentSoldier = (IPrivate)soldiers[soldierId];
                    privates.Add(soldierId, currentSoldier);
                }

                soldier = new LieutenantGeneral(firstName, lastName, id, salary, privates);
            }
            else if (soldierType == "Engineer")
            {
                decimal salary = decimal.Parse(inputInfo[4]);

                bool isValidCorps = Enum.TryParse<Corps>(inputInfo[5], out Corps corps);

                if (!isValidCorps)
                {
                    throw new Exception();
                }

                ICollection<Repair> repairs = new List<Repair>();

                for (int i = 6; i < inputInfo.Length; i += 2)
                {
                    string currentName = inputInfo[i];
                    int hoursWorked = int.Parse(inputInfo[i + 1]);
                    Repair repair = new Repair(currentName, hoursWorked);

                    repairs.Add(repair);
                }

                soldier = new Engineer(firstName, lastName, id, salary, corps, repairs);
            }
            else if (soldierType == "Commando")
            {
                decimal salary = decimal.Parse(inputInfo[4]);

                bool isValidCorps = Enum.TryParse<Corps>(inputInfo[5], out Corps corps);

                if (!isValidCorps)
                {
                    throw new Exception();
                }

                ICollection<Mission> missions = new List<Mission>();

                for (int i = 6; i < inputInfo.Length; i += 2)
                {
                    string missionName = inputInfo[i];
                    string missionState = inputInfo[i + 1];

                    bool isValidState = Enum.TryParse<State>(missionState, out State state);

                    if (!isValidState)
                    {
                        continue;
                    }

                    Mission mission = new Mission(missionName, state);
                    missions.Add(mission);
                }

                soldier = new Comando(firstName, lastName, id, salary, corps, missions);

            }
            else if (soldierType == "Spy")
            {
                int codeNumber = int.Parse(inputInfo[4]);
                soldier = new Spy(firstName, lastName, id, codeNumber);
            }

            soldiers.Add(id, soldier);

            return soldier.ToString();
        }
    }
}
