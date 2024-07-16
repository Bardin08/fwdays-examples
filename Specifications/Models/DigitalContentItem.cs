using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using SpecDeck;

namespace Specifications.Models;

[SpecDeckSpec]
public class DigitalContentItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public required string Name { get; init; }
    public required string Designer { get; init; }
    public List<Rating>? Rating { get; init; }
    public ItemFormat Format { get; init; }
    public ItemType Type { get; init; }

    public override string ToString()
    {
        return $"[{Type}] \"{Name}\", {Designer}, {nameof(Rating)}={GetRatingString()}";
    }

    private string GetRatingString()
    {
        return Rating != null
            ? Math.Round(Rating.Average(x => x.Mark), 2).ToString(CultureInfo.InvariantCulture)
            : "???";
    }
}
