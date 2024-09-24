using CrazyMusicians.Entities.Concrete;

namespace CrazyMusicians.Database
{
    public static class InMemoryDatabase
    {
        public static List<Musician> Musicians { get; set; }

        static InMemoryDatabase()
        {
            Musicians = new List<Musician>()
            {
                new Musician(1, "Ahmet Çalgı", "Ünlü Çalgı Çalar", "Her zaman yanlış nota çalar, ama çok eğlenceli"),
                new Musician(2, "Zeynep Melodi", "Popüler Melodi Yazarı", "Şarkıları yanlış anlaşılır ama çok popüler"),
                new Musician(3, "Cemil Akor", "Çılgın Akorist", "Akorları sık değiştirir, ama şaşırtıcı derecede yetenekli"),
                new Musician(4, "Fatma Nota", "Sürpriz Nota Üreticisi", "Nota üretirken sürekli sürprizler hazırlar"),
                new Musician(5, "Hasan Ritim", "Ritim Canavarı", "Her ritmi kendi tarzında yapar, hiç uymaz ama komiktir")
            };
        }
    }
}
