using Core.Utilities.Messages;

namespace Core.Utilities.Responses
{
    public class SuccessApiResponse : ApiResponse
    {
        public SuccessApiResponse(string message, bool success = true, ResultCodes resultCodes = ResultCodes.HTTP_OK, int resultCount = 0)
            : base(message, success, resultCodes, resultCount)
        {
        }
    }
}