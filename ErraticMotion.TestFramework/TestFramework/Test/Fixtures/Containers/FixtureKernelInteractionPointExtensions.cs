// <copyright file="FixtureKernelInteractionPointExtensions.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Fixtures.Containers
{
    /// <summary>
    /// Contains extension methods for the <see cref="IFixtureKernel"/> interface
    /// that registers types of <see cref="ITestDoubleInteractionPointFor{T}"/>
    /// into the underlying IoC container.
    /// </summary>
    public static class FixtureKernelInteractionPointExtensions
    {
        /// <summary>
        /// Binds the interception point into the IoC container.
        /// </summary>
        /// <typeparam name="T">The object that is to be faked.</typeparam>
        /// <param name="kernel">The underlying IoC container kernel.</param>
        /// <param name="item">The interaction point.</param>
        /// <remarks>
        /// Will un-register any existing bindings for the <typeparamref name="T" /> and register
        /// the interaction points fake object.
        /// </remarks>
        public static void BindPoint<T>(this IFixtureKernel kernel, ITestDoubleInteractionPointFor<T> item)
            where T : class
        {
            kernel.BindSingleton(item.Dependency);
        }
    }
}