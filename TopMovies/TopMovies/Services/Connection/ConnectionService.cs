using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AppCenter.Crashes;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using TopMovies.Models.Responses;
using TopMovies.Services.RequestProvider;

namespace TopMovies.Services.Connection
{
    public class ConnectionService : IConnectionService
    {
        private readonly IRequestProvider _requestProvider;

        public bool IsConnected => throw new NotImplementedException();

        public event ConnectivityChangedEventHandler ConnectivityChanged;

        public async Task<ConnectionResponse> CheckConnection()
        {
            try
            {
                if (!CrossConnectivity.Current.IsConnected)
                {
                    return new ConnectionResponse
                    {
                        IsSuccess = false,
                        Message = "Por favor, ligue suas configurações de internet.",
                    };
                }

                var isReachable = await CrossConnectivity.Current.IsRemoteReachable(
                    "google.com");
                if (!isReachable)
                {
                    return new ConnectionResponse
                    {
                        IsSuccess = false,
                        Message = "Verifique sua conexão com a rede.",
                    };
                }

                return new ConnectionResponse
                {
                    IsSuccess = true,
                    Message = "Ok",
                };
            }
            catch (Exception ex)
            {
                var properties = new Dictionary<string, string>
                {
                    {"ConnectionService","CheckConnection"},
                    {"ExceptionConnection","google.com"}

                };

                Crashes.TrackError(ex, properties);

                return new ConnectionResponse
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }

        }
    }
}
