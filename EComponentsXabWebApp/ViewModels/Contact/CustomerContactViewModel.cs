using System.ComponentModel.DataAnnotations;

namespace EComponentsXabWebApp.ViewModels.Contact
{
    public class CustomerContactViewModel
    {
        [Required(ErrorMessage = "{0} является обязательным параметром")]
        [Display(Name = "Имя")]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "{0} является обязательным параметром")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "{0} не валидный")]
        public string CustomerEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "{0} является обязательным параметром")]
        [Display(Name = "Сообщение")]
        [MaxLength(512, ErrorMessage = "{0} не должно иметь более {1} символов")]
        public string Message { get; set; } = string.Empty;

    }
}
