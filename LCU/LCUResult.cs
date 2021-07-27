using System.Net;

namespace AutoAccept.LCU
{
    public class LCUResult
    {
        public string Contect;

        // 404 never die
        public HttpStatusCode Status = HttpStatusCode.NotFound;

        public bool IsValid => Status == HttpStatusCode.OK || 
                               Status == HttpStatusCode.Created ||
                               Status == HttpStatusCode.Accepted;
    }
}
