using System;
using System.Collections.Generic;
using Reflex.Scripts.Enums;
using Reflex.Scripts.Utilities;
using UnityEngine;

namespace Reflex.Scripts.Extensions
{
    internal static class ComponentExtensions
    {
        private static MonoBehaviour[] empty = Array.Empty<MonoBehaviour>();
        
        internal static MonoBehaviour[] GetInjectables<T>(this T component, MonoInjectionMode injectionMode) where T : Component
        {
            switch (injectionMode)
            {
                case MonoInjectionMode.Single:
                {
                    if (!component.TryGetComponent<MonoBehaviour>(out var mono))
                        return empty;

                    return new[] { mono };
                }
                case MonoInjectionMode.Object: return component.GetComponents<MonoBehaviour>();
                case MonoInjectionMode.Recursive: return component.GetComponentsInChildren<MonoBehaviour>(true);
                default: throw new ArgumentOutOfRangeException(nameof(injectionMode), injectionMode, null);
            }
        }
    }
}