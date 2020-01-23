// <copyright file="IndirectOutputEventArgs.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Doubles
{
    using System;

    /// <summary>
    /// Event arguments which provide the event data of a specified type.
    /// </summary>
    /// <typeparam name="T">The type of the event value.</typeparam>
    public class IndirectOutputEventArgs<T> : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndirectOutputEventArgs{T}"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        internal IndirectOutputEventArgs(T value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public T Value { get; }

        /// <summary>
        /// Builds the arguments from the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The new argument.</returns>
        internal static IndirectOutputEventArgs<T> Create(T value)
        {
            return new IndirectOutputEventArgs<T>(value);
        }
    }
}