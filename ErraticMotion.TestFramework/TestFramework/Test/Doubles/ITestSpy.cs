// <copyright file="ITestSpy.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Doubles
{
    /// <summary>
    /// Encapsulates the behaviour supported by types of Test Double Spies.
    /// </summary>
    /// <typeparam name="TDependency">The Depended-On Component (DoC).</typeparam>
    /// <typeparam name="TIndirectOutput">The type of the indirect output that is to be spied on.</typeparam>
    public interface ITestSpy<TDependency, TIndirectOutput> : IWiretap<TDependency>, IObservationPointIndirectOutput<TIndirectOutput>
        where TDependency : class
        where TIndirectOutput : class
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