using System.Runtime.Serialization;

namespace IoTProjectWeek6.ViewModel
{
    [DataContract]
    public class LoginRequestViewModel
    {
        [DataMember(Name = "username")]
        public string Username { get; set; }
        [DataMember(Name = "password")]
        public string Password { get; set; }
    }
}