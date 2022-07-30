namespace ValidationAttributes.Utilities.Atributes
{
    using System;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            if (obj is string result)
            {
                return !string.IsNullOrEmpty(result);
            }

            return obj != null;
        }
    }
}
