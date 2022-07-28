namespace AuthorProblem
{
    using System;
    internal class AuthorAttribute : Attribute
    {
        public AuthorAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}