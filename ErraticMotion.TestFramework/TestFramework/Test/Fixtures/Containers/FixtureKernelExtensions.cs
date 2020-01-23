// <copyright file="FixtureKernelExtensions.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Fixtures.Containers
{
    using System;

    /// <summary>
    /// Contains extension methods for the <see cref="IFixtureKernel"/> interface
    /// that registers types of <see cref="IFixtureBindings"/>
    /// into the underlying IoC container.
    /// </summary>
    public static class FixtureKernelExtensions
    {
        /// <summary>
        /// Loads the specified bindings into the underlying IoC container.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        /// <param name="bindings">The bindings.</param>
        public static void Load(this IFixtureKernel kernel, IFixtureBindings bindings)
        {
            bindings.Load(kernel);
        }

        /// <summary>
        /// Loads the bindings into the underlying IoC container.
        /// </summary>
        /// <typeparam name="TBindings">The bindings.</typeparam>
        /// <param name="kernel">The kernel.</param>
        public static void Load<TBindings>(this IFixtureKernel kernel)
            where TBindings : IFixtureBindings, new()
        {
            Load(kernel, new TBindings());
        }

        /// <summary>
        /// Loads the bindings created by the factory into the underlying IoC container.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        /// <param name="factory">The factory.</param>
        public static void Load(this IFixtureKernel kernel, Func<IFixtureKernel, IFixtureBindings> factory)
        {
            Load(kernel, factory(kernel));
        }
    }
}