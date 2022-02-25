using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Core.DTO
{
    public class TodoTaskDto : IValidatableObject
    {
        public string Content { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Content))
                yield return new ValidationResult("task content cannot be null or empty");
        }
    }
}