// <copyright file="IExpectedStateSpecificationBase.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.StateVerification
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents a state verification specification base interface that contains common
    /// test assertions.
    /// </summary>
    public interface IExpectedStateSpecificationBase
    {
        /// <summary>
        /// Asserts that the current object has not been initialized yet.
        /// </summary>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])"/> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is pre-pended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="because"/>.
        /// </param>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Fluent API design decision")]
        void BeNull(string because = "", params object[] reasonArgs);

        /// <summary>
        /// Asserts that the current object has been initialized.
        /// </summary>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])"/> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is pre-pended automatically.
        /// </param>
        /// <param name="reasonArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Fluent API design decision")]
        void BeNotNull(string because = "", params object[] reasonArgs);
    }
}