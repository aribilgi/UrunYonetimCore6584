using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace UrunYonetimCore6584.Core.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; } // entityframework bu id değerini otomatik olarak primary key ve otomatik artan sayı olarak veritabanında ayarlayacak
        [DisplayName("Ürün Adı"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Name { get; set; }
        [DisplayName("Açıklama")]
        public string? Description { get; set; }
        [DisplayName("Marka")]
        public int BrandId { get; set; }
        [DisplayName("Durum")]
        public bool IsActive { get; set; }
        [DisplayName("Anasayfa")]
        public bool IsHome { get; set; }
        [DisplayName("Stok"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public int Stock { get; set; }
        [DisplayName("Ürün Fiyatı"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public decimal Price { get; set; }
        [DisplayName("Resim 1")]
        public string? Image { get; set; }
        [DisplayName("Resim 2")]
        public string? Image2 { get; set; }
        [DisplayName("Resim 3")]
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
