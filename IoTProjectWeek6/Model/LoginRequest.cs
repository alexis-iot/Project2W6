using System;

namespace IoTProjectWeek6.Model
{
    public class LoginRequest
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string IpAddress { get; set; }
        public DateTime RequestDate { get; set; }
    }
}