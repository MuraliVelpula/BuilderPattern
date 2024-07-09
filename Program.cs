using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// Represents an appointment with a date and service type
public class Appointment
{
    public DateTime Date { get; set; } // Date of the appointment
    public string ServiceType { get; set; } // Type of service for the appointment

    public override string ToString()
    {
        return $"{ServiceType} Appointment on {Date}."; // Formats the appointment details as a string
    }
}

// Interface for building appointments
public interface IAppointmentBuilder
{
    void SetDate(DateTime date); // Sets the date of the appointment
    void SetServiceType(string service); // Sets the type of service for the appointment
    Appointment GetAppointment(); // Retrieves the built appointment object
}

// Concrete implementation of IAppointmentBuilder
public class AppointmentBuilder : IAppointmentBuilder
{
    private Appointment _appointment = new Appointment(); // The appointment instance being built

    public void SetDate(DateTime date)
    {
        _appointment.Date = date; // Sets the date of the appointment
    }

    public void SetServiceType(string service)
    {
        _appointment.ServiceType = service; // Sets the type of service for the appointment
    }

    public Appointment GetAppointment()
    {
        return _appointment; // Returns the built appointment
    }
}

// MainClass to demonstrate the usage of AppointmentBuilder
public class MainClass
{
    static void Main()
    {
        List<Appointment> list = new List<Appointment>(); // List to store appointments

        // Usage of the AppointmentBuilder
        var builder = new AppointmentBuilder();

        builder.SetDate(DateTime.Now.AddDays(1)); // Sets the date of the first appointment (tomorrow)
        builder.SetServiceType("Medical"); // Sets the service type for the first appointment
        Appointment appointment = builder.GetAppointment(); // Retrieves the built appointment
        list.Add(appointment); // Adds the appointment to the list

        builder = new AppointmentBuilder();
        builder.SetDate(DateTime.Now.AddDays(1)); // Sets the date of the second appointment (tomorrow)
        builder.SetServiceType("Haircut"); // Sets the service type for the second appointment
        appointment = builder.GetAppointment(); // Retrieves the built appointment
        list.Add(appointment); // Adds the appointment to the list

        // Using Parallel.ForEach to print each appointment details concurrently
        Parallel.ForEach(list, appointment =>
        {
            Console.WriteLine(appointment); // Prints each appointment's details
        });
    }
}
