namespace MVVM.LTE.IoC
{
    public interface IServiceProvider
    {
        TService GetService<TService>();
        TService GetService<TService>(string key);
        TService GetTransientService<TService>();
        TService GetTransientService<TService>(string key);
        TService GetTransientService<TService>(string key, params object[] contructorMembers);
        void AddService<TService>();
        void AddService<TService, TImplementation>();
        void AddService<TService, TImplementation>(string key);
        void AddService<TService>(string key);
        void AddService<TService>(params object[] contructorMembers);
        void AddService<TService, TImplementation>(params object[] contructorMembers);
        void AddService<TService, TImplementation>(string key, params object[] contructorMembers);
        void AddService<TService>(string key, params object[] contructorMembers);
    }
}
