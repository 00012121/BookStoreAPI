using System.Text.Json.Serialization;

namespace BookStoreAPI.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
        [JsonIgnore]
        public ICollection<Book> Books { get; set; }
    }
}
    