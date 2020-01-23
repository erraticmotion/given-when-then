// <copyright file="IObservationPointIndirectOutput.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test
{
    using System;
    using System.Collections.Generic;
    using Doubles;

    /// <summary>
    /// Represents an observation point indirect output.
    /// </summary>
    /// <typeparam name="TIndirectOutput">The type of the indirect output.</typeparam>
    public interface IObservationPointIndirectOutput<TIndirectOutput>
        where TIndirectOutput : class
    {
        /// <summary>
        /// Occurs when indirect output is received by this instance.
        /// </summary>
        event EventHandler<IndirectOutputEventArgs<TIndirectOutput>> Received;

        /// <summary>
        /// Gets the collection of indirect outputs received by this instance.
        /// </summary>
        /// <value>
        /// A collection of indirect outputs.
        /// </value>
        IList<TIndirectOutput> IndirectOutput { get; }
    }
}