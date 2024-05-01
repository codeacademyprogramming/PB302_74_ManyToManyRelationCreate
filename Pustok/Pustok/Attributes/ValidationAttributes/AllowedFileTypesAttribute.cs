using System.ComponentModel.DataAnnotations;

namespace Pustok.Attributes.ValidationAttributes
{
    public class AllowedFileTypesAttribute:ValidationAttribute
    {
        private string[] _types;
        public AllowedFileTypesAttribute(params string[] types)
        {
            _types = types;
        }


        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            List<IFormFile> fileList = new List<IFormFile>();

            if (value is List<IFormFile> files) fileList = files;
            else if (value is IFormFile file) fileList.Add(file);

            foreach (var file in fileList)
            {
                if (file != null)
                {
                    if (!_types.Contains(file.ContentType))
                    {
                        string errorMessage = "File must be one of the types: " + String.Join(",", _types);
                        return new ValidationResult(errorMessage);
                    }
                }
            }
           

            return ValidationResult.Success;
        }
    }
}
