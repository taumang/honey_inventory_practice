namespace honey_inventory_practice.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum HoneyPriceClass
    {
        R53 = 1,
        R105 = 2,
        R201 = 3
    }
}