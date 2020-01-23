// <copyright file="IObservableDisposable.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.InteractionPoints
{
    using System;

    /// <summary>
    /// Represents a Test Double Observation Point for interfaces that implement
    /// the <see cref="IDisposable"/> interface.
    /// </summary>
    public interface IObservableDisposable
    {
        /// <summary>
        /// Gets a value indicating whether the Test Double Fake instance has been disposed.
        /// </summary>
        /// <value>
        /// If <c>true</c> the Test Double Fake has been disposed; otherwise, <c>false</c>.
        /// </value>
        bool IsDisposed { get; }
    }
}