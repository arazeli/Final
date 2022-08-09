using System;
using System.ComponentModel.DataAnnotations;
using T_Shirt_Store.WebUI.AppCode.infrastructure;

namespace T_Shirt_Store.WebUI.Models.Entities
{
    public class ContactPost : BaseEntity
    {
        [Required(ErrorMessage = "Bosh buraxmaq olmaz")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Bosh buraxmaq olmaz")]
        public string FullName { get; set; }

        [EmailAddress(ErrorMessage = "E-poct adresiniz uygun deyil")]
        [Required(ErrorMessage = "Bosh buraxmaq olmaz")]
        public string Email { get; set; }

        public DateTime? AnswerDate {get; set;}

        public string AnswerMessage { get; set; }
        public int? AnswerById { get; set; }

    }
}
