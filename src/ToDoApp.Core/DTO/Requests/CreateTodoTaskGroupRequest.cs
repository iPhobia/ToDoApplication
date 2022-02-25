using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Core.DTO.Requests
{
    public class CreateTodoTaskGroupRequest : IValidatableObject
    {
        public string GroupName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(GroupName))
                yield return new ValidationResult("Group name cannot be empty or null");
        }
    }
}