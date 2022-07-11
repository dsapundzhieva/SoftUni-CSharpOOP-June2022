namespace MilitaryElite.Models
{
    using MilitaryElite.Contracts;
    using System;
    public class Soldier : ISoldier
    {
        string id;
        string firstName;
        string lastName;

        public Soldier(string firstName, string lastName, string id)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string Id
        {
            get
            {
                return this.id;
            }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.id = value;
                }
            }
        }
        public string FirstName 
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.firstName = value;
                }
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.lastName = value;
                }
            }
        }
    }
}
