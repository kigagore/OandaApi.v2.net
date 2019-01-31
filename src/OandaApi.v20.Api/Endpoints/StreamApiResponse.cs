using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OandaApi.v20.Api.Endpoints
{
    public sealed class StreamApiResponse<T> : IDisposable
        where T : class
    {
        private readonly HttpContent _httpContent;
        private readonly JsonConverter _jsonConverter;
        
        public bool IsSuccess { get; private set; }
        public ApiError Error { get; private set; }

        public StreamApiResponse(HttpContent httpContent, JsonConverter converter)
        {
            _httpContent = httpContent;
            _jsonConverter = converter;
            IsSuccess = true;
        }

        public StreamApiResponse(ApiError error)
        {
            IsSuccess = false;
            Error = error;
        }

        public void Dispose()
        {
            _httpContent?.Dispose();
        }

        public async Task StartDataStream(Action<T> onDataReceived, CancellationToken token)
        {
            await Task.Factory.StartNew(() =>
            {
                using (_httpContent)
                {
                    var stream = _httpContent.ReadAsStreamAsync().GetAwaiter().GetResult();
                    var reader = new StreamReader(stream);

                    while (!token.IsCancellationRequested)
                    {
                        var line = reader.ReadLine();
                        var obj = JsonConvert.DeserializeObject<T>(line, Serializing.GetSerializerSettings(_jsonConverter));
                        onDataReceived?.Invoke(obj);
                    }
                }
            }, token);
        }

        public Task StartDataStream(Action<T> onDataReceived)
        {
            return StartDataStream(onDataReceived, CancellationToken.None);
        }
    }
}