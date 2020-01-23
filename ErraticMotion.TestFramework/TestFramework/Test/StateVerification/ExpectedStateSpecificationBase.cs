// <copyright file="ExpectedStateSpecificationBase.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.StateVerification
{
    using System.Globalization;
    using FluentAssertions;

    /// <summary>
    /// Acts as a base class for test fixture assertion objects.
    /// </summary>
    public abstract class ExpectedStateSpecificationBase : IExpectedStateSpecificationBase
    {
        private readonly object sut;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpectedStateSpecificationBase"/> class.
        /// </summary>
        /// <param name="sut">The SUT.</param>
        protected ExpectedStateSpecificationBase(object sut)
        {
            this.sut = sut;
        }

        /// <summary>
        /// Asserts that the current object has not been initialized yet.
        /// </summary>
        /// <param name="because">A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is pre-pended automatically.</param>
        /// <param name="reasonArgs">Zero or more objects to format using the placeholders in <paramref name="because" />.</param>
        public void BeNull(string because = "", params object[] reasonArgs)
        {
            this.sut.Should().BeNull(because, reasonArgs);
        }

        /// <summary>
        /// Bes the not null.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="reasonArgs">The reason arguments.</param>
        public void BeNotNull(string message = "", params object[] reasonArgs)
        {
            this.sut.Should().NotBeNull(message, reasonArgs);
        }

        /// <summary>
        /// Formats the message.
        /// </summary>
        /// <param name="parentMessage">The parent message.</param>
        /// <param name="message">The message.</param>
        /// <returns>A <see cref="string"/> representation of the message.</returns>
        protected static string FormatMessage(string parentMessage, string message)
        {
            if (string.IsNullOrEmpty(parentMessage))
            {
                return message;
            }

            return string.Format(CultureInfo.InvariantCulture, "{0}.{1}", parentMessage, message);
        }
    }
}