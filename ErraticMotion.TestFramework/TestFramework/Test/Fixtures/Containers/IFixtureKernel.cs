// <copyright file="IFixtureKernel.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Fixtures.Containers
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents the interface that IoC containers must implement
    /// so that it can be used within the Test Automation Framework.
    /// </summary>
    public interface IFixtureKernel : IDisposable
    {
        /// <summary>
        /// Gets an instance of the specified service.
        /// </summary>
        /// <typeparam name="T">The service to resolve.</typeparam>
        /// <returns>An instance of the service.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Get", Justification = "Well understood IoC binding syntax")]
        T Get<T>()
            where T : class;

        /// <summary>
        /// Binds the specified object.
        /// </summary>
        /// <typeparam name="T">The type of the implementation.</typeparam>
        /// <param name="obj">The object.</param>
        void Bind<T>(T obj)
            where T : class;

        /// <summary>
        /// Binds the singleton.
        /// </summary>
        /// <typeparam name="T">The type of the implementation.</typeparam>
        /// <param name="obj">The object.</param>
        void BindSingleton<T>(T obj)
            where T : class;

        /// <summary>
        /// Binds this instance.
        /// </summary>
        /// <typeparam name="T">The type of the interface.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "Well understood IoC binding syntax")]
        void Bind<T, TImplementation>()
            where T : class
            where TImplementation : class, T;

        /// <summary>
        /// Binds the singleton.
        /// </summary>
        /// <typeparam name="T">The type of the interface.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "Well understood IoC binding syntax")]
        void BindSingleton<T, TImplementation>()
            where T : class
            where TImplementation : class, T;
    }
}