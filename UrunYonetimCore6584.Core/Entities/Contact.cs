using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace UrunYonetimCore6584.Core.Entities
{
    public class Contact : IEntity
    {
        public int Id { get; set; }
        [DisplayName("Müşteri Adı"), Required(ErrorMessage = "{0} Boş Geçilemez!")]
        public string Name { get; set; }
        [DisplayName("Müşteri Soyadı")]
        public string? Surname { get; set; }
        [DisplayName("Telefon")]
        public string? Telephone { get; set; }
        [DisplayName("Email"), Required(ErrorMessage = "{0} Boş Geçilemez!")]
        public string Email { get; set; }
        [MinLength(20), DisplayName("Mesaj"), Required]
        public string Message { get; set; }
        [DisplayName("Mesaj Tarihi"), ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
