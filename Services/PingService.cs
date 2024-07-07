using JetBrains.Annotations;
using System.Net.NetworkInformation;

namespace PingApp.Services
{
    public sealed class PingService
    {
        private readonly Ping _pinger = new();

        internal long Ping([CanBeNull]string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                return default;
            }

            try
            {
                return _pinger.Send(address).RoundtripTime;                
            }
            catch (PingException)
            {
                return default;
            }
        }
    }
}
