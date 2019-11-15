namespace Iot.SenseHat.Helpers
{
    using Iot.SenseHat.Emulation;
    using Iot.SenseHat.Interfaces;
    using Iot.SenseHat.Services;

    public class SenseHatServiceHelper
    {
        public static ISenseHatService GetService(bool emulationMode = false)
        {
            if (emulationMode)
                return new SenseHatEmulationService();
            
            return new SenseHatService();
        }
    }
}
