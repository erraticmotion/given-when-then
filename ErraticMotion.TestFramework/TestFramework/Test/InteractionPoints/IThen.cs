// <copyright file="IThen.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.InteractionPoints
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Specifies a step in a multi-line operation.
    /// </summary>
    /// <typeparam name="T">The next interface that perform some action.</typeparam>
    public interface IThen<out T>
        where T : class
    {
        /// <summary>
        /// Gets and joins actions together to form a human readable sentence of an operation.
        /// </summary>
        /// <value>
        /// The next operation in the sentence.
        /// </value>
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Then", Justification = "Fluent interface")]
        T Then { get; }
    }
}