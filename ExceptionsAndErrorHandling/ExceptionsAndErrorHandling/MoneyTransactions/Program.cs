using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyTransactions
{
    public class Program
    {
        static void Main(string[] args)
        {
            var inputAccounts = Console.ReadLine()
                .Split(new char[] { '-', ',' })
                .ToList();

            Dictionary<int, double> accounts = new Dictionary<int, double>();

            for (int i = 0; i < inputAccounts.Count; i+=2)
            {
                int accountnumber = int.Parse(inputAccounts[i]);
                double ballance = double.Parse(inputAccounts[i + 1]);

                accounts.Add(accountnumber, ballance);
            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                try
                {
                    var cmdArgs = command.Split();
                    string cmdType = cmdArgs[0];

                    int accountNumber = int.Parse(cmdArgs[1]);
                    double sum = double.Parse(cmdArgs[2]);

                    if (cmdType == "Deposit")
                    {
                        if (!accounts.ContainsKey(accountNumber))
                        {
                            throw new ArgumentException("Invalid account!");
                        }
                        accounts[accountNumber] += sum;
                    }
                    else if (cmdType == "Withdraw")
                    {
                        if (accounts[accountNumber] < sum)
                        {
                            throw new ArgumentException("Insufficient balance!");
                        }
                        accounts[accountNumber] -= sum;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid command!");
                    }
                    Console.WriteLine($"Account {accountNumber} has new balance: {accounts[accountNumber]:f2}");
                }
                catch (IndexOutOfRangeException iore)
                {
                    Console.WriteLine(iore.Message);
                }
                catch(ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }
    }
}
