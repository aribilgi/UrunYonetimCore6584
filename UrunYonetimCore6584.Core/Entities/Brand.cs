using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace UrunYonetimCore6584.Core.Entities
{
    public class Brand : IEntity
    {
        public int Id { get; set; }
        [DisplayName("Marka Adı"), Required]
        public string Name { get; set; }
        [DisplayName("Açıklama")]
        public string? Description { get; set; }
        [DisplayName("Logo")]
        public string? Logo { get; set; }
        [DisplayName("Durum")]
        public bool IsActive { get; set; }
        [DisplayName("Kayıt Tarihi")]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public virtual List<Product>? Products { get; set; }
    }
}
