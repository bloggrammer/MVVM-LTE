namespace MVVM.LTE.IoC
{
    public sealed class ServiceLocator
    {
        static ServiceLocator()
        {
        }

        private ServiceLocator()
        {
        }

        public static IServiceProvider Current { get; } = new ServiceProvider();
    }
}
