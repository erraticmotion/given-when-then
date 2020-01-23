// <copyright file="ITestDoubleInteractionPointFor.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test
{
    /// <summary>
    /// Specifies the test double interaction points dependency interface.
    /// </summary>
    /// <typeparam name="T">The type of interface to be replaced by the interaction point.</typeparam>
    public interface ITestDoubleInteractionPointFor<out T>
        where T : class
    {
        /// <summary>
        /// Gets the test double dependency object that can be injected into the SUT
        /// to replace the production version.
        /// </summary>
        /// <value>
        /// A test double object that supports the <typeparamref name="T"/> interface.
        /// </value>
        T Dependency { get; }
    }
}