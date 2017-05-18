using System.Globalization;
using System.Windows.Controls;

namespace EightQueensPuzzle.ValidationRules
{
    public class NumericTextBoxValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int i;
            if (value != null && int.TryParse(value.ToString(), out i))
                return new ValidationResult(true, null);

            return new ValidationResult(false, "Please enter a valid number value.");
        }
    }
}
