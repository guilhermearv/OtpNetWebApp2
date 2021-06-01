using System.ComponentModel.DataAnnotations;

namespace OtpNetWebApp2.Models
{
    public class VerifyAuthViewModel
    {
        [Required(ErrorMessage = "Field required")]
        public string Passcode { get; set; }
    }
}