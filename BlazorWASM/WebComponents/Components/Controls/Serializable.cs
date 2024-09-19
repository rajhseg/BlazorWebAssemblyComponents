using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebComponents.Components.Controls;

  public static class SerializableExtensions
    {
        public static string ConvertToString(this object obj)
        {            
            string json = JsonSerializer.Serialize(obj);

            byte[] bytes = Encoding.UTF8.GetBytes(json);

            return Convert.ToBase64String(bytes);
        }

        public static T? ConvertToObject<T>(this string base64Text)
        {
            byte[] bytes = Convert.FromBase64String(base64Text);

            string json = Encoding.UTF8.GetString(bytes);

            return JsonSerializer.Deserialize<T>(json);
        }

        public static string ConvertToJson(this object obj)
        {
            return JsonSerializer.Serialize(obj);
        }
    }
