// <copyright file="ITestDoubleBuilder.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Fixtures.Containers
{
    /// <summary>
    /// Represents a GoF Builder pattern that can be used by types of test doubles.
    /// </summary>
    /// <remarks>
    /// Implement this interface for type of test double builder so that they can be injected
    /// into the test fixture IoC mechanism using the
    /// <see cref="FixtureKernelTestDoubleExtensions.BindBuilder{T}"/> member.
    /// </remarks>
    /// <typeparam name="T">The type that the test double is impersonating.</typeparam>
    public interface ITestDoubleBuilder<out T>
        where T : class
    {
        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns>A object of type T.</returns>
        T Build();
    }
}