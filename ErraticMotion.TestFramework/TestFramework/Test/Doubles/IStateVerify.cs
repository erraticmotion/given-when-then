// <copyright file="IStateVerify.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Doubles
{
    using System;

    /// <summary>
    /// Specialization of a Test Double Spy that exposes an interface that naturally
    /// joins with Fluent Assertions.
    /// </summary>
    /// <typeparam name="TDependency">The Depended-On Component (DoC).</typeparam>
    /// <typeparam name="TIndirectOutput">The type of the indirect output that is to be asserted on.</typeparam>
    public interface IStateVerify<TDependency, out TIndirectOutput> : IDependency<TDependency>, IWiretap<TDependency>
        where TDependency : class
        where TIndirectOutput : class
    {
        /// <summary>
        /// Gets the count of indirect outputs that this object has captured.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        int Count { get; }

        /// <summary>
        /// Indicates whether the specified expectation has been met or not.
        /// </summary>
        /// <param name="expectation">The expectation.</param>
        /// <returns><c>true</c> to indicate that the expectation has been met; otherwise <c>false</c>.</returns>
        bool Verify(Func<TIndirectOutput, bool> expectation);
    }
}