﻿
namespace MilitaryElite.Models
{
    using System;

    using MilitaryElite.Models.Contracts;

    public class Spy : Soldier, ISpy
    {
        public Spy(string firstName, string lastName, int id, int codeNumber) 
            : base(firstName, lastName, id)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; }

        public override string ToString()
        {
            return base.ToString() 
                + Environment.NewLine
                + $"Code Number: {this.CodeNumber}";
        }
    }
}
