namespace ValidationAttributes.Utilities
{
    using System;
    using System.Linq;
    using System.Reflection;
    using ValidationAttributes.Utilities.Atributes;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType
                .GetProperties()
                .Where(pi => pi.CustomAttributes.Any(a => a.AttributeType.BaseType == typeof(MyValidationAttribute)))
                .ToArray();

            foreach (PropertyInfo property in properties)
            {
                object propValue = property.GetValue(obj);

                foreach (CustomAttributeData customAttrData in property.CustomAttributes)
                {
                    Type customAttrType = customAttrData.AttributeType;
                    object attrInstance = property
                        .GetCustomAttribute(customAttrType);

                    MethodInfo validationMethod = customAttrType
                        .GetMethods()
                        .First(m => m.Name == "IsValid");

                    bool result = (bool)validationMethod
                        .Invoke(attrInstance, new object[] { propValue });

                    if (!result)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
