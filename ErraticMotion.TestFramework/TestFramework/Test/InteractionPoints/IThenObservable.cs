// <copyright file="IThenObservable.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.InteractionPoints
{
    /// <summary>
    /// Decorates the <see cref="IThen{T}"/> interface to add behaviour to indicate that
    /// the action specified in the <see cref="IThen{T}"/> operation was raised.
    /// </summary>
    /// <typeparam name="T">The next interface that perform some action.</typeparam>
    public interface IThenObservable<out T> : IThen<T>
        where T : class
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="IThenObservable{T}"/> has been raised.
        /// </summary>
        /// <value>
        /// <c>true</c> if raised; otherwise, <c>false</c>.
        /// </value>
        bool Raised { get; }
    }
}