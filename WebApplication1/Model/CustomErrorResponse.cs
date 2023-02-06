namespace Sat.Recruiment.Api.Model
{
    public class CustomErrorResponse
    {
        public string Message { get; set; }

        public CustomErrorResponse(string message)
        {
            Message = message;
        }
    }
}
