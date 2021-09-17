namespace NetCoreReactJS.Models
{
    public class ReponseModel
    {
        public ReponseModel()
        {
        
        }
        public ReponseModel(int? statusCode, string msg, dynamic data)
        {
            this.StatusCode = statusCode;
            this.Msg = msg;
            this.Data = data;
        }
        public int? StatusCode { get; set; } = 0;//0 = error, 1 = success
        public string Msg { get; set; } = string.Empty;
        public dynamic Data { get; set; } = null;
    }
}
