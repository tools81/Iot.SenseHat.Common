namespace Iot.SenseHat.Services
{
    using System.Drawing;
    using Iot.Device.SenseHat;
    using Iot.SenseHat.Interfaces;
    using Iot.SenseHat.Models;

    public class SenseHatService : ISenseHatService
    {
        public SensorReadings SensorReadings => GetReadings();
        public bool EmulationMode { get; }
        public void Fill(Color color) => _ledMatrix.Fill(color);

        private readonly SenseHatLedMatrix _ledMatrix;
        private readonly SenseHatPressureAndTemperature _pressureAndTemperature;
        private readonly SenseHatTemperatureAndHumidity _temperatureAndHumidity;

        public SenseHatService()
        {
            _ledMatrix = new SenseHatLedMatrixI2c();
            _pressureAndTemperature = new SenseHatPressureAndTemperature();
            _temperatureAndHumidity = new SenseHatTemperatureAndHumidity();
        }

        private SensorReadings GetReadings()
        {
            return new SensorReadings
            {
                Temperature = _temperatureAndHumidity.Temperature,
                Temperature1 = _pressureAndTemperature.Temperature,
                Humidity = _temperatureAndHumidity.Humidity,
                Pressure = _pressureAndTemperature.Pressure
            };
        }
    }
}
