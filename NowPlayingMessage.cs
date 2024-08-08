using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRPMQTTC_
{
    public class NowPlayingInfo
    {
        public string subject { get; set; }
        public Body body { get; set; }
        public string topic { get; set; }
    }

    public class Body
    {
        public string artist_name { get; set; }
        public string track_name { get; set; }
        public string track_artist { get; set; }
        public string album_name { get; set; }
        public string poster_url { get; set; }
        public string title { get; set; }
        public string action { get; set; }
    }

}
