using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace UrunYonetimCore6584.Core.Entities
{
    public class Slide : IEntity
    {
        public int Id { get; set; }
        [DisplayName("Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [DisplayName("Başlık")]
        public string? Title { get; set; }
        [DisplayName("Açıklama"), DataType(DataType.MultilineText)]
        public string? Description { get; set; }
        [DisplayName("Resim")]
        public string? Image { get; set; }
    }
}
