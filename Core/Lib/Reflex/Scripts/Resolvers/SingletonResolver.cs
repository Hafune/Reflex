﻿using System;

namespace Reflex
{
    internal class SingletonResolver : IResolver
    {
        private object _instance;
        public Type Concrete { get; }
        public int Resolutions { get; private set; }

        public SingletonResolver(Type concrete)
        {
            Concrete = concrete;
        }

        public void Dispose()
        {
            if (_instance is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }

        public object Resolve(Context context)
        {
            Resolutions++;

            return _instance ??= context.Construct(Concrete);
        }
    }
}