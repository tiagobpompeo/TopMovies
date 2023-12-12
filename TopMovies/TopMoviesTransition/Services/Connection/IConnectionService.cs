using System.Threading.Tasks;
using Plugin.Connectivity.Abstractions;
using TopMoviesTransition.Models.Responses;

namespace TopMoviesTransition.Services.Connection
{
    public interface IConnectionService
    {
        bool IsConnected { get; }
        event ConnectivityChangedEventHandler ConnectivityChanged;
        Task<ConnectionResponse> CheckConnection();
    }
}
