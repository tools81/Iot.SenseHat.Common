namespace Iot.SenseHat.Interfaces
{
    using System.Drawing;
    using Iot.SenseHat.Models;

    public interface ISenseHatService
    {
        SensorReadings SensorReadings { get; }
        bool EmulationMode { get; }
        void Fill(Color color);
    }
}
