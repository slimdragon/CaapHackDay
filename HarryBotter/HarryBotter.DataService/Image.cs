
using System.Collections.Generic;

namespace HarryBotter.DataService
{

    public class ImagesResponse
    {
        public Dictionary<string, Image> images { get; set; }
    }

    public class Image
    {
        public string item_id { get; set; }
        public string correlation_id { get; set; }
        public string cdn_url { get; set; }
        public string file_name { get; set; }
        public string archived { get; set; }
        public string restored { get; set; }

        public MetaData metadata { get; set; }
    }

    public class MetaData
    {
        public string active { get; set; }
        public string creation_date { get; set; }
        public string image_date { get; set; }
        public string image_id { get; set; }
        public string image_sub_type { get; set; }
        public string image_type { get; set; }
        public string lifecycle_end_date { get; set; }
        public string sequence_number { get; set; }
        public string source { get; set; }
        public string stage { get; set; }
        public string transaction_user { get; set; }
        public string visibility { get; set; }

    }
}
