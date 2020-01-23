// <copyright file="IExpectedStateSeeSpecification.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.StateVerification
{
    using System.Diagnostics.CodeAnalysis;
    using InteractionPoints;

    /// <summary>
    /// Represents a state verification specification.
    /// </summary>
    /// <typeparam name="TStateVerification">The type of the state verification.</typeparam>
    public interface IExpectedStateSeeSpecification<in TStateVerification>
        : IExpectedStateSpecificationBase
    {
        /// <summary>
        /// Executes a state verification assertion.
        /// </summary>
        /// <param name="expected">The expected state to assert.</param>
        /// <param name="precision">The precision.</param>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Fluent API design decision")]
        void See(TStateVerification expected, Precision precision = Precision.Exact);

        /// <summary>
        /// Executes a state verification assertion.
        /// </summary>
        /// <param name="expected">The expected state to assert.</param>
        /// <param name="message">The message.</param>
        /// <param name="precision">The precision.</param>
        void See(TStateVerification expected, string message, Precision precision);
    }
}