using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransmissionRemote.RPC.Arguments;

namespace TransmissionRemote.RPC
{
    public class Client
    {
        private string Host { get; set; }
        private string Port { get; set; }
        private string Path { get; set; }
        private int Tag { get; set; }
        private string _SessionId;
        public string SessionId { get { return _SessionId; } }
        public int RpcVersion { get; set; }

        private const string X_SESSION_HEADER = "X-Transmission-Session-Id";
        private string[] _AllFields = new string[] { "activityDate", "addedDate", "bandwidthPriority", "comment", "corruptEver", "creator", "dateCreated", "desiredAvailable", "doneDate", "downloadDir", "downloadedEver", "downloadLimit", "downloadLimited", "error", "errorString", "eta", "etaIdle", "files", "fileStats", "hashString", "haveUnchecked", "haveValid", "honorsSessionLimits", "id", "isFinished", "isPrivate", "isStalled", "leftUntilDone", "magnetLink", "manualAnnounceTime", "maxConnectedPeers", "metadataPercentComplete", "name", "peer-limit", "peers", "peersConnected", "peersFrom", "peersGettingFromUs", "peersSendingToUs", "percentDone", "pieces", "pieceCount", "pieceSize", "priorities", "queuePosition", "rateDownload", "rateUpload", "recheckProgress", "secondsDownloading", "secondsSeeding", "seedIdleLimit", "seedIdleMode", "seedRatioLimit", "seedRatioMode", "sizeWhenDone", "startDate", "status", "trackers", "trackerStats", "totalSize", "torrentFile", "uploadedEver", "uploadLimit", "uploadLimited", "uploadRatio", "wanted", "webseeds", "webseedsSendingToUs" };

        public Client() {
            var rnd = new Random();
            this.Tag = rnd.Next();
        }
        public Client(string Host)
            : this(Host, "9091", "/transmission/rpc") { }
        public Client(string Host, string Port, string Path)
        {
            this.Host = Host;
            this.Port = Port;
            this.Path = Path;

            var rnd = new Random();
            this.Tag = rnd.Next();

        }

        private TransmissionResponse SendRequest(TransmissionRequest data)
        {
            var task = SendRequestAsync(data);
            return task.GetAwaiter().GetResult();

        }
        private async Task<TransmissionResponse> SendRequestAsync(TransmissionRequest data)
        {
#if DEBUG
            using (var client = new HttpClient(new LoggingHandler(new HttpClientHandler())))
#else
            using (var client = new HttpClient())
#endif
            {
                client.BaseAddress = new Uri(String.Format("http://{0}:{1}/", this.Host, this.Port));
                client.Timeout = TimeSpan.FromSeconds(60);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add(X_SESSION_HEADER, _SessionId);
                data.Tag = this.Tag;

                HttpResponseMessage response = await client.PostAsJsonAsync(this.Path, data);

                if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    //Update SessionId and resend;
                    foreach (var item in response.Headers)
                    {
                        if (item.Key == X_SESSION_HEADER)
                        {
                            _SessionId = item.Value.Last();
                            continue;
                        }
                    }

                    return await SendRequestAsync(data);

                }
                else if (response.IsSuccessStatusCode)
                {
                    var jsresult = await response.Content.ReadAsAsync<TransmissionResponse>();
                    return jsresult;
                }

                return null;
            }


        }

        #region -- Session -- 
        public Session GetSession()
        {
            TransmissionRequest request = new TransmissionRequest { Method = "session-get" };
            var result = SendRequest(request);
            return result.Deserialize<Session>();
        }

        public async Task<Session> GetSessionAsync()
        {
            TransmissionRequest request = new TransmissionRequest { Method = "session-get" };
            var result = await SendRequestAsync(request);
            return result.Deserialize<Session>();
        }

        public SessionStatistics GetSessionStats()
        {
            TransmissionRequest request = new TransmissionRequest { Method = "session-stats" };
            var result = SendRequest(request);
            return result.Deserialize<SessionStatistics>();
        }

        public async Task<SessionStatistics> GetSessionStatsAsync()
        {
            TransmissionRequest request = new TransmissionRequest { Method = "session-stats" };
            var result = await SendRequestAsync(request);
            return result.Deserialize<SessionStatistics>();
        }

        public Session SetSession(Session settings)
        {
            throw new NotImplementedException();
        }
        public async Task<Session> SetSessionAsync(Session settings)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
