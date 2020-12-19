using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4_Library
{

    public enum EventType 
    {
        Golf =1,
        Bowling,
        Amusement_Park,
        Concert
    }
    //POCO
    public class Outing
    {
        public EventType EventType { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAttendance { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal CostOfEvent { get; set; }

        public Outing() { }

        public Outing(EventType eventType, DateTime date, decimal totalAttendance, decimal costPerPerson, decimal costOfEvent)
        {
            EventType = eventType;
            Date = date;
            TotalAttendance = totalAttendance;
            CostPerPerson = costPerPerson;
            CostOfEvent = (totalAttendance * costPerPerson);
           
        }
    }
}
