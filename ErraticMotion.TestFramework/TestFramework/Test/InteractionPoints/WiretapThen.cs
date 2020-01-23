// <copyright file="WiretapThen.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.InteractionPoints
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;
    using Moq;

    /// <summary>
    /// Represents a Wire tap base class.
    /// </summary>
    /// <typeparam name="T">The type of object to perform a wire tap on.</typeparam>
    public class WiretapThen<T> : IWiretapThen
        where T : class
    {
        private readonly Mock<T> mock;
        private Action<IEnumerable<object>> onMatch;

        /// <summary>
        /// Initializes a new instance of the <see cref="WiretapThen{T}"/> class.
        /// </summary>
        /// <param name="selector">The selector.</param>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
        public WiretapThen(Expression<Action<T>> selector)
        {
            this.mock = new Mock<T>();
            this.mock.Setup(selector).Callback(() =>
            {
                this.Matches = true;
            });
        }

        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <value>
        /// The object.
        /// </value>
        public T Object => this.mock.Object;

        /// <summary>
        /// Gets a value indicating whether this <see cref="WiretapThen{T}"/> is matches.
        /// </summary>
        /// <value>
        ///   <c>true</c> if matches; otherwise, <c>false</c>.
        /// </value>
        public bool Matches { get; private set; }

        /// <summary>
        /// Call backs the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Callback(params object[] value)
        {
            this.onMatch?.Invoke(value);
            this.Matches = false;
        }

        /// <summary>
        /// Allows the injection of the call-back if the operation specified in the
        /// <see cref="IWiretapFor{TDependency}.When" /> method has matched.
        /// </summary>
        /// <param name="action">The action to perform if the When operation matches.</param>
        public void Then(Action<IEnumerable<object>> action)
        {
            this.onMatch = action;
        }
    }
}