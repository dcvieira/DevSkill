using DevSkill.Order.API.Messaging;

namespace DevSkill.Order.API
{
    public  static class ApplicationBuilderExtensions
    {
        public static IAzServiceBusConsumer ServiceBusConsumer { get; set; }

        public static IApplicationBuilder UseAzServiceBusConsumer(this IApplicationBuilder app)
        {
            ServiceBusConsumer = app.ApplicationServices.GetService<IAzServiceBusConsumer>();
            var host = app.ApplicationServices.GetService<IHostApplicationLifetime>();

            host.ApplicationStarted.Register(OnStarted);
            host.ApplicationStopping.Register(OnStopping);
            return app;
        }

        public static void OnStarted()
        {
            ServiceBusConsumer.Start();
        }

        public static void OnStopping()
        {
            ServiceBusConsumer.Stop();
        }
    }
}
