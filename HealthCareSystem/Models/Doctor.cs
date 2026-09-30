using System.Collections.Generic;

namespace HealthCareSystem.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;

        // Navigation Property: Many-to-Many with Patient through Appointment (M : M)
        public  ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
