using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Mvc.Models
{
    public class StudentViewModel
    {
        [StringLength(32)]
        [Display(Name = "LabelLastName", Prompt = "LabelLastNamePrompt",ResourceType = typeof(Properties.Resources))]
        public required string? LastName { get; init; }

        [StringLength(32)]
        [Display(Name = "LabelFirstName", Prompt = "LabelFirstNamePrompt", ResourceType = typeof(Properties.Resources))]
        public required string? FirstName { get; init; }

        [Required]
        [Display(Name = "LabelEnrollmentDate", Prompt = "LabelEnrollmentDatePrompt", ResourceType = typeof(Properties.Resources))]
        public DateTime EnrollmentDate { get; init; } = DateTime.Now;

        [DataType(DataType.Upload)]
        [Display(Name = "LabelPhotoUri", Prompt = "LabePhotoUriPrompt", ResourceType = typeof(Properties.Resources))]
        public IFormFile? PhotoUri { get; set; }
    }
}
