using Flurl.Http;
using Polly;
using Polly.Retry;

namespace BffApiParalelismoComChamadasAssincronas.Services.DataService
{
    public abstract class DataServiceBase
    {
        protected AsyncRetryPolicy BuildRetryPolicy()
        {
            var retryPolicy = Policy
               .Handle<FlurlHttpException>(IsTransientError)
               .WaitAndRetryAsync(new[]
               {
                   TimeSpan.FromSeconds(1),
                   TimeSpan.FromSeconds(2),
                   TimeSpan.FromSeconds(3)
               }, (exception, timeSpan, retryCount, context) =>
               {
                   Console.WriteLine("#########");
                   Console.WriteLine($"Exception captada {exception}");
                   Console.WriteLine("#########");
                   Console.WriteLine("");

                   Console.WriteLine($"Tentativa {retryCount} com tempo de espera de {timeSpan} para executar a próxima tentativa");

                   Console.WriteLine("");
                   Console.WriteLine("#########");
                   Console.WriteLine("");
               });

            return retryPolicy;
        }

        private bool IsTransientError(FlurlHttpException exception)
        {
            int[] httpStatusCodesWorthRetrying =
            {
                StatusCodes.Status408RequestTimeout,
                StatusCodes.Status502BadGateway,
                StatusCodes.Status503ServiceUnavailable,
                StatusCodes.Status504GatewayTimeout
            };

            return exception.StatusCode.HasValue && httpStatusCodesWorthRetrying.Contains(exception.StatusCode.Value);
        }
    }
}
