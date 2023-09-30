using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Chps.Users.Models
{
    public class ChatMessage
    {
        [JsonPropertyName("oMessages")]
        public CMessages OMessages { get; set; }
        [JsonPropertyName("oUsrTkn")]
        public CUsrTkn OUsrTkn { get; set; }
        [JsonPropertyName("oUsrInf")]
        public CUsrInf OUsrInf { get; set; }
        [JsonPropertyName("idChatContext")]
        public string IdChatContext { get; set; }
        [JsonPropertyName("idChatContextRecipient")]
        public string IdChatContextRecipient { get; set; }
        [JsonPropertyName("idStatus")]
        public string IdStatus { get; set; }
        [JsonPropertyName("user")]
        public string User { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("room")]
        public Room Room { get; set; }
    }
    public class ChatMessageCllctn : ObservableCollection<ChatMessage>
    {
        public ChatMessageCllctn() : base() { }
        public ChatMessageCllctn(IEnumerable<ChatMessage> oIE) : base(oIE) { }
    }

    public record CMessages
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
    public class CUsrTkn
    {
        public string id { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }


    public class CUsrInf_Old
    {
        [JsonPropertyName("email")]
        public string U { get; set; }
        [JsonPropertyName("password")]
        public string P { get; set; }
        public string K { get; set; }

        [JsonPropertyName("returnSecureToken")]
        public bool rST { get; set; } = true;
    }


    public class CUsrInf
    {
        [JsonPropertyName("email")]
        public string U { get; set; }
        [JsonPropertyName("password")]
        public string P { get; set; }
        [JsonPropertyName("key")]
        public string K { get; set; }

        [JsonPropertyName("returnSecureToken")]
        public bool rST { get; set; } = true;
        [JsonPropertyName("idWorkerCardMobileDevice")]
        public int IdWCMD { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("idTrabajador")]
        public int IdTrabajador { get; set; }
        [JsonPropertyName("odDepartamento")]
        public int IdDepartamento { get; set; }
        [JsonPropertyName("idDireccion")]
        public int IdDireccion { get; set; }
        [JsonPropertyName("idCategoria")]
        public int IdCategoria { get; set; }
        [JsonPropertyName("idDevice")]
        public string? IdDevice { get; set; }
    }

    public class Room
    {
        public string RoomKey { get; set; }
        public string RoomName { get; set; }
    }

    public class RoomCllctns : ObservableCollection<Room>
    {
        public RoomCllctns() : base() { }
        public RoomCllctns(IEnumerable<Room> OIE) : base(OIE) { }
    }
    /*******************************/

    public class GeoCoordinate
    {
        public double Latitude { get; set; } // Latitud
        public double Longitude { get; set; } // Longitud
        public double Altitude { get; set; } // Altitud
        public double Accuracy { get; set; } // Precisión
        public double Speed { get; set; } // Velocidad
        public double Course { get; set; } // Rumbo

        public DateTime Timestamp { get; set; } // Marca de tiempo

        public GeoCoordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
