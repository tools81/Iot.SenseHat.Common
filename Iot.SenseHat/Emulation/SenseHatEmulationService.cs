namespace Iot.SenseHat.Emulation
{
    using System;
    using System.Drawing;
    using Iot.SenseHat.Interfaces;
    using Iot.SenseHat.Models;
    using Iot.Units;

    public class SenseHatEmulationService : ISenseHatService
    {
        public SensorReadings SensorReadings => GetSensorReadings();
        public bool EmulationMode => true;
        public void Fill(Color color) { /* do nothing */ }

        private readonly Random _randomNumberGenerator = new Random();
        private readonly SensorReadingRange _temperatureRange = new SensorReadingRange { Min=20, Max=40 };
        private readonly SensorReadingRange _humidityRange = new SensorReadingRange { Min=0, Max=100 };
        private readonly SensorReadingRange _pressureRange = new SensorReadingRange { Min=1000, Max=1050 };

        private SensorReadings GetSensorReadings()
        {
            return new SensorReadings()
            {
                Temperature = Temperature.FromFahrenheit(GetRandomReading(_temperatureRange)),
                Temperature1 = Temperature.FromFahrenheit(GetRandomReading(_temperatureRange)),
                Humidity = (float) GetRandomReading(_humidityRange),
                Pressure = (float) GetRandomReading(_pressureRange)
            };
        }

        private double GetRandomReading(SensorReadingRange sensorReadingRange)
        {
            var randomValueRescaled = _randomNumberGenerator.NextDouble() * sensorReadingRange.ValueRange();
            return sensorReadingRange.Min + randomValueRescaled;
        }
    }

    public class SensorReadingRange
    {
        public double Min { get; set; }
        public double Max { get; set; }

        public double ValueRange() => Max - Min;
    }
}
