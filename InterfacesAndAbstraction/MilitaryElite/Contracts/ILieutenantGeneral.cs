
namespace MilitaryElite.Contracts
{
    using System;
    using System.Collections.Generic;

    internal interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyCollection<IPrivate> Privates { get; }
    }
}
