// <copyright file="IDependency.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Doubles
{
    /// <summary>
    /// SUT dependency to be replaced for testing purposes.
    /// </summary>
    /// <typeparam name="TDependency">The type of the dependency.</typeparam>
    public interface IDependency<out TDependency>
        where TDependency : class
    {
        /// <summary>
        /// Gets the DoC that this object is required to capture indirect outputs from.
        /// </summary>
        /// <value>
        /// The Depended-On Component (DoC).
        /// </value>
        TDependency Dependency { get; }
    }
}