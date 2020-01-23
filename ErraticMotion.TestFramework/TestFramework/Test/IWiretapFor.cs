// <copyright file="IWiretapFor.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;
    using InteractionPoints;

    /// <summary>
    /// Test Double Wire Tap.
    /// </summary>
    /// <typeparam name="T">The type of object to Wire Tap.</typeparam>
    public interface IWiretapFor<T>
        where T : class
    {
        /// <summary>
        /// Gets the Wire Tap source object.
        /// </summary>
        T Source { get; }

        /// <summary>
        /// Injects the specified source into the wire tap.
        /// </summary>
        /// <param name="source">The source, the object that is to be wire tapped.</param>
        void Inject(T source);

        /// <summary>
        /// Allows the wire tap to select an operation that it wants to receive messages for.
        /// </summary>
        /// <param name="selector">The expression that matches an operation on the wire tap source.</param>
        /// <returns>An object that supports the <see cref="IWiretapThen"/> interface.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "When", Justification = "Fluent interface")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "Fluent interface")]
        IWiretapThen When(Expression<Action<T>> selector);
    }
}