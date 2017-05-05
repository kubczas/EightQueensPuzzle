using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;

namespace BaseReuseServices
{
    public sealed class UnityService : IDisposable
    {
        private static UnityService _instance;
        private readonly IUnityContainer _unityContainer;

        private UnityService()
        {
            _unityContainer = new UnityContainer();
        }

        public static UnityService Instance => _instance ?? (_instance = new UnityService());

        public IUnityContainer Get()
        {
            return _unityContainer;
        }

        public IUnityContainer Register<T,TS>() where T : TS
        {
            _unityContainer.RegisterType<TS, T>();
            return _unityContainer;
        }

        public IUnityContainer RegisterSingleton<TS, T>() where T : TS
        {
            _unityContainer.RegisterType<TS, T>(new ContainerControlledLifetimeManager());
            return _unityContainer;
        }

        public IUnityContainer Register<TS, T>(LifetimeManager lifetimeManager) where T : TS
        {
            _unityContainer.RegisterType<TS, T>(lifetimeManager);
            return _unityContainer;
        }

        public IUnityContainer RegisterInstance<T>(T instance)
        {
            _unityContainer.RegisterInstance(instance);
            return _unityContainer;
        }

        public T Resolve<T>(params ResolverOverride[] overrides)
        {
            return _unityContainer.Resolve<T>(overrides);
        }

        public T Resolve<T>(string name, params ResolverOverride[] overrides)
        {
            return _unityContainer.Resolve<T>(name, overrides);
        }

        public IEnumerable<T> ResolveAll<T>(params ResolverOverride[] overrides)
        {
            return _unityContainer.ResolveAll<T>(overrides);
        }

        public void Dispose()
        {
            //todo
        }
    }
}
