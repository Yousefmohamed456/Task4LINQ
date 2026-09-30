using System;
using System.Collections.Generic;

namespace HealthCareSystem.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }

        // Navigation Property: Many-to-Many with Doctor through Appointment (M : M)
        public  ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
