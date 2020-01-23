// <copyright file="IFixtureBindings.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Fixtures.Containers
{
    /// <summary>
    /// Represents an operation to bind common dependencies into the underlying IoC container.
    /// </summary>
    public interface IFixtureBindings
    {
        /// <summary>
        /// Loads the specified bindings into the kernel.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        void Load(IFixtureKernel kernel);
    }
}