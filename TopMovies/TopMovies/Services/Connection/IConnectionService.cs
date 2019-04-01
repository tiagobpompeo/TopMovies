using System.Threading.Tasks;
using Plugin.Connectivity.Abstractions;
using TopMovies.Models.Responses;

namespace TopMovies.Services.Connection
{
    public interface IConnectionService
    {
        bool IsConnected { get; }
        event ConnectivityChangedEventHandler ConnectivityChanged;
        Task<ConnectionResponse> CheckConnection();
    }
}
