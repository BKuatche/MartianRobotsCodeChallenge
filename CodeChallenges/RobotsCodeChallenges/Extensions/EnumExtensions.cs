using System.Reflection;

namespace RobotsCodeChallenges.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString())!;
            var attributes = (System.ComponentModel.DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);

            return attributes.Length > 0
                ? attributes[0].Description
                : value.ToString();
        }


        public static T FromDescription<T>(string description) where T : struct, Enum
        {
            foreach (var field in typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                var attr = (System.ComponentModel.DescriptionAttribute?)
                    Attribute.GetCustomAttribute(field, typeof(System.ComponentModel.DescriptionAttribute));

                if ((attr != null && attr.Description == description) || field.Name == description)
                    return (T)field.GetValue(null)!;
            }
            throw new ArgumentException($"No {typeof(T).Name} with description '{description}'.");
        }
    }
}
