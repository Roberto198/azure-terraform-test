using System;


namespace VMS.Client.DbModels
{
    public class Van
    {

        public Guid VanId { get; set; }

        public string RegistrationNumber { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public DateTime? MotExpriryDate { get; set; }

        public DateTime? EnteredSystemDate { get; set; }

        public string? Colour { get; set; }

        public string? Size { get; set; }

        public string? DriverClass { get; set; }

    }


}