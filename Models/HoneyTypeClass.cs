namespace honey_inventory_practice.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum HoneyTypeClass
    {
        Blossom_Honey = 1,
        Multifolra_Honey = 2,
        Aloe_Honey = 3
    }
}