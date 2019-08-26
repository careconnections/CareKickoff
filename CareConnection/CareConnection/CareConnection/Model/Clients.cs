using System;

namespace CareConnection.Core.Model
{
    public class Clients
    {
        public int NativeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
    }
}