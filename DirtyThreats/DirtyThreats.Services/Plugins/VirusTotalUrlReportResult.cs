using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DirtyThreats.Services.Plugins
{
    public class VirusTotalUrlReportResult
    {
        [JsonPropertyName("response_code")]
        public int ResponseCode { get; set; }

        [JsonPropertyName("verbose_msg")]
        public string VerboseMsg { get; set; }

        [JsonPropertyName("scan_id")]
        public string ScanId { get; set; }

        [JsonPropertyName("permalink")]
        public string Permalink { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("scan_date")]
        public string ScanDate { get; set; }

        [JsonPropertyName("filescan_id")]
        public object FilescanId { get; set; }

        [JsonPropertyName("positives")]
        public int Positives { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("scans")]
        public object Scans { get; set; }
    }
}
