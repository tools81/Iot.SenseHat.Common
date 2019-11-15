using System.Threading.Tasks;

namespace Iot.SenseHat.Console
{
    using System;
    using System.Drawing;
    using Iot.SenseHat.Helpers;
    using Iot.SenseHat.Interfaces;

    class Program
    {
        private static readonly Color[] LedColors = {Color.Red, Color.Blue, Color.Green};
        private const int MsDelayTime = 1000;
        private static int _ledColorIndex;

        static void Main(string[] args)
        {
            var emulationMode = ParseInputArgumentsToSetEmulationMode(args);
            var senseHatService = SenseHatServiceHelper.GetService(emulationMode);

            Console.WriteLine($"Emulation mode: {senseHatService.EmulationMode}");

            while (true)
            {
                Console.WriteLine(senseHatService.SensorReadings);
                ChangeFillColor(senseHatService);
                Task.Delay(MsDelayTime).Wait();
            }
        }

        private static bool ParseInputArgumentsToSetEmulationMode(string[] args)
        {
            return args.Length == 1 && string.Equals(args[0], "Y", StringComparison.OrdinalIgnoreCase);
        }

        private static void ChangeFillColor(ISenseHatService senseHatService)
        {
            if (!senseHatService.EmulationMode)
            {
                senseHatService.Fill(LedColors[_ledColorIndex]);
                _ledColorIndex = ++_ledColorIndex % LedColors.Length;
            }
        }
    }
}
