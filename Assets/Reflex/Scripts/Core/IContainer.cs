﻿using System;
using UnityEngine;

namespace Reflex.Scripts
{
    public interface IContainer : IDisposable
    {
        void AddDisposable(IDisposable disposable);
        T Instantiate<T>(T original) where T : Component;
        GameObject Instantiate(GameObject original);
        T Construct<T>();
        object Construct(Type concrete);
        BindingContractDefinition<TContract> Bind<TContract>();
        void BindSingleton<TContract>(TContract instance);
        TContract Resolve<TContract>();
        object Resolve(Type contract);
    }
}