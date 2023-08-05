using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace UrunYonetimCore6584.Core.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; } // entityframework bu id değerini otomatik olarak primary key ve otomatik artan sayı olarak veritabanında ayarlayacak
        [StringLength(50), DisplayName("Ürün Adı"), Required]
        public string Name { get; set; }
        [DisplayName("Açıklama")]
        public string? Description { get; set; }
        [StringLength(50), DisplayName("Marka")]
        public int BrandId { get; set; }
        [DisplayName("Durum")]
        public bool IsActive { get; set; }
        [DisplayName("Anasayfa")]
        public bool IsHome { get; set; }
        [DisplayName("Stok")]
        public int Stock { get; set; }
        [DisplayName("Ürün Fiyatı")]
        public decimal Price { get; set; }
        [StringLength(100), DisplayName("Resim 1")]
        public string? Image { get; set; }
        [StringLength(100), DisplayName("Resim 2")]
        public string? Image2 { get; set; }
        [StringLength(100), DisplayName("Resim 3")]
        public string? Image3 { get; set; }
        [DisplayName("Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [DisplayName("Kategori")]
        public int CategoryId { get; set; } // entityframework bu ilişkiye bakarak CategoryId property sini foreignkey olrak işaretleyecek
        [DisplayName("Kategori"), ScaffoldColumn(false)]
        public virtual Category? Category { get; set; } // Product ile Category sınıfı arasında 1 e 1 ilişki kurduk. Yani her ürünün 1 kategorisi olacak
        [DisplayName("Marka"), ScaffoldColumn(false)]
        public virtual Brand? Brand { get; set; }
    }
}
