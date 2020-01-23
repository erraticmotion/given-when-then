// <copyright file="IExpectedStateSpecificationShould.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.StateVerification
{
    /// <summary>
    /// Represents a state verification specification.
    /// </summary>
    /// <typeparam name="TStateVerification">The type of the state verification.</typeparam>
    public interface IExpectedStateSpecificationShould<in TStateVerification>
    {
        /// <summary>
        /// Creates an intermediate step within the expected state verification object.
        /// </summary>
        /// <returns>
        /// An object that supports the <see cref="IExpectedStateBeSpecification{TStateVerification}"/> interface.
        /// </returns>
        IExpectedStateBeSpecification<TStateVerification> Should();
    }
}