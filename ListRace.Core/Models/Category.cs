using ListRace.Core.Models.Base;

namespace ListRace.Core.Models;

public class Category : BaseEntity
{
    public string Title { get; set; }
    public ICollection<Place> Places { get; set; }
}
