
namespace MilitaryElite.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal interface IPrivate : ISoldier
    {
        decimal Salary { get; set; }
    }
}
