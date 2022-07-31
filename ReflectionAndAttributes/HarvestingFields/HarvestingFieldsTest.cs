namespace P01.HarvestingFields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var fieldsInfo = new List<FieldInfo>();

            string command;

            while ((command = Console.ReadLine()) != "HARVEST")
            {
                fieldsInfo.AddRange(GetCurrentFields(command));
            }

            foreach (FieldInfo fieldInfo in fieldsInfo)
            {
                Console.WriteLine($"{GetModifier(fieldInfo)} {fieldInfo.FieldType.Name} {fieldInfo.Name}");
            }
        }

        private static string GetModifier(FieldInfo fieldInfo)
        {
            if (fieldInfo.IsPublic)
            {
                return "public";
            }
            if (fieldInfo.IsFamily)
            {
                return "protected";
            }
            if (fieldInfo.IsPrivate)
            {
                return "private";
            }
            return "";
        }

        private static IEnumerable<FieldInfo> GetCurrentFields(string command)
        {
            Type type = Type.GetType("P01.HarvestingFields.HarvestingFields");
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            switch (command)
            {
                case "private":
                    fields = fields.Where(f => f.IsPrivate).ToArray();
                    break;
                case "protected":
                    fields = fields.Where(f => f.IsFamily).ToArray();
                    break;
                case "public":
                    fields = fields.Where(f => f.IsPublic).ToArray();
                    break;
            }
            return fields;
        }
    }
}
