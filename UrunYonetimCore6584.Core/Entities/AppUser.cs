using System.ComponentModel.DataAnnotations;

namespace UrunYonetimCore6584.Core.Entities
{
    public class AppUser : IEntity
    {
        public int Id { get; set; }
        [StringLength(50), Display(Name = "Adı"), Required]
        public string Name { get; set; }
        [StringLength(50), Display(Name = "Soyadı")]
        public string Surname { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50), Display(Name = "Kullanıcı Adı")]
        public string? Username { get; set; }
        [StringLength(50), Display(Name = "Şifre")]
        public string Password { get; set; }
        [StringLength(20), Display(Name = "Telefon")]
        public string? Phone { get; set; }
        [Display(Name = "Aktif?")]
        public bool IsActive { get; set; }
        [Display(Name = "Admin?")]
        public bool IsAdmin { get; set; }
        [Display(Name = "Kayıt Tarihi")]
        public DateTime CreateDate { get; set; }
    }
}
