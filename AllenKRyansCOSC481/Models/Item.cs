using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace AllenKRyansCOSC481.Models
{
    public enum ItemType
    {
        [Description("Party Packs")]
        PARTY_PACK,
        [Description("Buckets")]
        BUCKET,
        [Description("Chicken")]
        CHICKEN_ALONE,
        [Description("Ribs")]
        RIBS_ALONE,
        [Description("Mixed Chicken")]
        MIXED_CHICKEN,
        [Description("Appetizers")]
        APPETIZER_SIDE,
        [Description("Salads")]
        SALAD,
        [Description("Sandwiches")]
        SANDWICH_BURGER,
        [Description("Chicken & Ribs")]
        CHICKEN_RIBS,
        [Description("Combinations")]
        COMBO,
        [Description("Other")]
        OTHER,
        [Description("Bad Data")]
        BAD_DATA
    }

    public class Item
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();
        public double Price { get; set; }
        public ItemType Type { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public static class EnumHelper
    {
        // Allows us to get the description of an enum
        // Came from here: https://stackoverflow.com/questions/479410/enum-tostring-with-user-friendly-strings
        public static string GetDescription<T>(this T enumerationValue) where T : struct
        {
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            }

            //Tries to find a DescriptionAttribute for a potential friendly name
            //for the enum
            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    //Pull out the description value
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            //If we have no description attribute, just return the ToString of the enum
            return enumerationValue.ToString();
        }
    }

}