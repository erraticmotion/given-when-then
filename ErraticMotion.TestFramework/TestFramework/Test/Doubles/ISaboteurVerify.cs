// <copyright file="ISaboteurVerify.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Doubles
{
    /// <summary>
    /// Test Double Saboteur with verification capabilities.
    /// </summary>
    /// <typeparam name="TDependency">The type of the DOC.</typeparam>
    public interface ISaboteurVerify<out TDependency> : IDependency<TDependency>
        where TDependency : class
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="ISaboteurVerify{TDependency}"/> has thrown.
        /// </summary>
        /// <value>
        ///   <c>true</c> if thrown; otherwise, <c>false</c>.
        /// </value>
        bool Thrown { get; }
    }
}