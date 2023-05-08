using Polly;
using Polly.Retry;

namespace RequestService.Policies
{
    public class ClientPolicy 
    {
        public AsyncRetryPolicy<HttpResponseMessage> ImmediateHttpRetry { get; set; }
        public AsyncRetryPolicy<HttpResponseMessage> LinearHttpRetry { get; set; }
        public AsyncRetryPolicy<HttpResponseMessage> ExponentialHttpRetry { get; set; }


        public ClientPolicy()
        {
            // send request since get right status or reach the limit
            ImmediateHttpRetry = Policy.HandleResult<HttpResponseMessage>(
                res => !res.IsSuccessStatusCode)
                .RetryAsync(5);

            // send reqest every 3 seconds since get right status code 
            LinearHttpRetry = Policy.HandleResult<HttpResponseMessage>(
                res => !res.IsSuccessStatusCode)
                .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(3));

            // send reqest every power of retryAttempt seconds since get right status code 
            ExponentialHttpRetry = Policy.HandleResult<HttpResponseMessage>(
                res => !res.IsSuccessStatusCode)
                .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

        }
    }
}
