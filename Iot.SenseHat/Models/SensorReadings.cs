namespace Iot.SenseHat.Models
{
    using System;
    using Iot.Units;

    public class SensorReadings
    {
        public Temperature Temperature { get; set; }
        public Temperature Temperature1 { get; set; }
        public float Humidity { get; set; }
        public float Pressure { get; set; }
        public DateTime TimeStamp { get; } = DateTime.UtcNow;

        public override string ToString()
        {
            return $"Temperature: {Temperature.Fahrenheit,5:F2} °F \r\n"
                   + $"Temperature1: {Temperature1.Fahrenheit,5:F2} °F \r\n"
                   + $"Humidity: {Humidity,4:F1} % \r\n"
                   + $"Pressure: {Pressure,6:F1} hPa";
        }
    }
}
