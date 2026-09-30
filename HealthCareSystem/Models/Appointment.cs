using System;

namespace HealthCareSystem.Models
{
    public class Appointment
    {
        // Foreign Key & Composite Primary Key Part
        public int PatientId { get; set; }

        // Foreign Key & Composite Primary Key Part
        public int DoctorId { get; set; }

        // Date of Appointment & Composite Primary Key Part
        public DateTime AppointmentDate { get; set; }

        // Navigation Properties
        public  Patient Patient { get; set; } = null!;
        public  Doctor Doctor { get; set; } = null!;
    }
}
