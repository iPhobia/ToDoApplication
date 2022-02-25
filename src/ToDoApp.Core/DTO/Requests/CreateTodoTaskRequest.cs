using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Core.DTO.Requests
{
    public class CreateTodoTaskRequest : IValidatableObject
    {
        public string Content { get; set; }
        public int? GroupId { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Content))
                yield return new ValidationResult("task content cannot be null or empty");
            if (!GroupId.HasValue || GroupId <= 0)
                yield return new ValidationResult("invalid value for group id");
        }
    }
}