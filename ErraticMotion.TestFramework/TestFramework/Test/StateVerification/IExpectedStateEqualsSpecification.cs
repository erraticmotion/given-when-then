// <copyright file="IExpectedStateEqualsSpecification.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.StateVerification
{
    /// <summary>
    /// Represents a state verification specification.
    /// </summary>
    /// <typeparam name="TStateVerification">The type of the state verification.</typeparam>
    public interface IExpectedStateEqualsSpecification<in TStateVerification> :
        IExpectedStateSpecificationBase
    {
        /// <summary>
        /// Executes a state verification assertion.
        /// </summary>
        /// <param name="expected">The expected state to assert.</param>
        /// <remarks>
        /// Used where the state verification specification object does not implement
        /// the same interface as the SUT but can be equality compared.
        /// </remarks>
        void Equal(TStateVerification expected);
    }
}