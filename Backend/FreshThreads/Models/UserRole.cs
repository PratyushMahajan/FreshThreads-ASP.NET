using System.Text.Json.Serialization;

namespace FreshThreads.Models
{

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserRole
    {
        ROLE_ADMIN, ROLE_USER, ROLE_SHOP, ROLE_DELIVERY
    }
}
