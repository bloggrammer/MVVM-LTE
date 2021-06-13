using System;
using System.Collections.Generic;

namespace MVVM.LTE.IoC
{
    public class ServiceProvider : IServiceProvider
    {
        public void AddService<TService>()
        {
            services[typeof(TService)] = Activator.CreateInstance<TService>();
        }

        public void AddService<TService, TImplementation>()
        {
            services[typeof(TService)] = Activator.CreateInstance<TImplementation>();
        }

        public void AddService<TService, TImplementation>(string key)
        {
            services[$"{typeof(TService).FullName}.{key}"] = Activator.CreateInstance<TImplementation>();
        }

        public void AddService<TService>(string key)
        {
            services[$"{typeof(TService).FullName}.{key}"] = Activator.CreateInstance<TService>();
        }

        public void AddService<TService>(params object[] contructorMembers)
        {
            services[typeof(TService)] = Activator.CreateInstance(typeof(TService), contructorMembers);
        }

        public void AddService<TService, TImplementation>(params object[] contructorMembers)
        {
            services[typeof(TService)] = Activator.CreateInstance(typeof(TImplementation), contructorMembers);
        }

        public void AddService<TService, TImplementation>(string key, params object[] contructorMembers)
        {
            services[$"{typeof(TService).FullName}.{key}"] = Activator.CreateInstance(typeof(TImplementation), contructorMembers);
        }

        public void AddService<TService>(string key, params object[] contructorMembers)
        {
            services[$"{typeof(TService).FullName}.{key}"] = Activator.CreateInstance(typeof(TService), contructorMembers);
        }

        public TService GetService<TService>()
        {
            try
            {
                return (TService)services[typeof(TService)];
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException(
                         string.Format(
                             "The requested service {0} is not registered.", typeof(TService)));
            }
        }

        public TService GetService<TService>(string key)
        {
            try
            {
                var newkey = $"{typeof(TService).FullName}.{key}";
                return (TService)services[newkey];
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException(
                        string.Format(
                            "The requested service {0} is not registered.", typeof(TService)));
            }
        }

        public TService GetTransientService<TService>()
        {
            try
            {
                var obj = services[typeof(TService)];
                Type type = obj.GetType();
                return (TService)Activator.CreateInstance(type);
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException(
                         string.Format(
                             "The requested service {0} is not registered.", typeof(TService)));
            }
        }

        public TService GetTransientService<TService>(string key)
        {
            try
            {
                var newkey = $"{typeof(TService).FullName}.{key}";
                var obj = services[newkey];
                Type type = obj.GetType();
                return (TService)Activator.CreateInstance(type);
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException(
                         string.Format(
                             "The requested service {0} is not registered.", typeof(TService)));
            }
        }
        public TService GetTransientService<TService>(string key, params object[] contructorMembers)
        {
            try
            {
                var newkey = $"{typeof(TService).FullName}.{key}";
                var obj = services[newkey];
                Type type = obj.GetType();
                return (TService)Activator.CreateInstance(type, contructorMembers);
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException(
                         string.Format(
                             "The requested service {0} is not registered.", typeof(TService)));
            }
        }
        private static readonly Dictionary<object, object> services = new Dictionary<object, object>();
    }
}
