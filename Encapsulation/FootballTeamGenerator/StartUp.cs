namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string command;
            List<Team> teams = new List<Team>();

            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    var cmdArgs = command.Split(";", StringSplitOptions.RemoveEmptyEntries);

                    ProcessInput(teams, cmdArgs);
                }

                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine(ErrorMessages.NullOrWhitespaceName);
                }
            }
        }

        private static void ProcessInput(List<Team> teams, string[] cmdArgs)
        {
            string cmdType = cmdArgs[0];
            string teamName = cmdArgs[1];

            if (cmdType == "Team")
            {
                Team team = new Team(teamName);
                teams.Add(team);
            }
            else
            {
                Team team = teams
                   .FirstOrDefault(t => t.Name == teamName);

                if (team == null)
                {
                    throw new InvalidOperationException(
                        String.Format(ErrorMessages.TeamNotExist, teamName));
                }

                if (cmdType == "Add")
                {
                    string playerName = cmdArgs[2];

                    int endurance = int.Parse(cmdArgs[3]);
                    int sprint = int.Parse(cmdArgs[4]);
                    int dribble = int.Parse(cmdArgs[5]);
                    int passing = int.Parse(cmdArgs[6]);
                    int shooting = int.Parse(cmdArgs[7]);

                    Stats stats = new Stats(endurance, sprint, dribble, passing, shooting);
                    Player player = new Player(playerName, stats);
                    team.AddPlayer(player);

                }
                else if (cmdType == "Remove")
                {
                    string playerName = cmdArgs[2];
                    team.RemovePlayer(playerName);

                }
                else if (cmdType == "Rating")
                {
                    Console.WriteLine(team);
                }
            }

        }
    }
}
