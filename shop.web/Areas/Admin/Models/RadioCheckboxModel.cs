using shop.web.Data;

namespace shop.web.Areas.Admin.Models
{
    public class RadioCheckboxModel<T> where T : struct, IConvertible
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public RadioCheckboxModel(string name, T enumValue, int? selectedEnumValue)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            FillFields(name, enumValue);

            IsChecked = Value == selectedEnumValue;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public RadioCheckboxModel(string name, T enumValue, List<int>? selectedEnumValues)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            FillFields(name, enumValue);

            IsChecked = selectedEnumValues != null && selectedEnumValues.Contains(Value);
        }

        private void FillFields(string name, T enumValue)
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("Not an enum");

            Name = name;
            DisplayName = enumValue.ToString() ?? "";
            Value = Convert.ToInt32(enumValue);
            Id = name + Value;
        }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public int Value { get; set; }

        public string Id { get; set; }

        public bool IsChecked { get; set; }
    }
}
