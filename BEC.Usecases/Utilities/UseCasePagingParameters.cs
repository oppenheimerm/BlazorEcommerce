namespace BEC.UseCases.Utilities
{
    public class UseCasePagingParameters : QueryStringParameters
    {
        public UseCasePagingParameters()
        {
            const int maxPageSize = 25;
        }
    }
}