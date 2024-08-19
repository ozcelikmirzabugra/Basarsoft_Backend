using System.Collections.Generic;

namespace basarsoft.Models
{
    public class Items
    {
        public int Id { get; set; }
        public double Xcoordinate { get; set; }
        public double Ycoordinate { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public int StatusCode { get; set; }
        public object Data { get; set; }  // Items veri listesi
    }
}
