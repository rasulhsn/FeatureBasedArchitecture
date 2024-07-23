using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TMOnline.Shared.Core
{
    public static class ObjectValidatorExtensions
    {
        public static bool TryValidate(this object instance, out IEnumerable<string> errorMessages)
        {
            List<ValidationResult> validationResults = new List<ValidationResult>();

            ValidationContext context = new ValidationContext(instance, null, null);
            bool valid = Validator.TryValidateObject(instance, context, validationResults, true);

            if (!valid)
            {
                List<string> internalErrorMessages = new List<string>();

                foreach (ValidationResult validationResult in validationResults)
                    internalErrorMessages.Add(validationResult.ErrorMessage);

                errorMessages = internalErrorMessages;

                return false;
            }
            else
            {
                errorMessages = null;
            }

            return true;
        }
    }
}
