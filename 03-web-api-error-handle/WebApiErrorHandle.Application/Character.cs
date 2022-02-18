using Newtonsoft.Json;

namespace WebApiErrorHandle.Application
{
    public class Character
    {
        public int Id { get; set; }
        [JsonProperty("name")]
        public string NomeDoPersonagem { get; set; }
        public string Status { get; set; }
        public string Species { get; set; }
        public string Gender { get; set; }
    }
}
