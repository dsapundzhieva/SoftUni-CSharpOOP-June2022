
namespace ValidationAttributes.Utilities.Atributes
{
    using System;
    public abstract class MyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object obj);
    }
}
