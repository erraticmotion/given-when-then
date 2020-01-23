// <copyright file="StateVerificationString.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.StateVerification
{
    using FluentAssertions;

    /// <summary>
    /// Responsible for state verification of <see cref="string"/> values.
    /// </summary>
    public abstract class StateVerificationString
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StateVerificationString"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        protected StateVerificationString(string value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the value that is to be compared with the expected value.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Creates the specified option.
        /// </summary>
        /// <param name="option">The option.</param>
        /// <param name="value">The value.</param>
        /// <returns>
        /// An object that supports the <see cref="StateVerificationString" /> abstraction.
        /// </returns>
        public static StateVerificationString Create(StateVerificationStringOption option, string value)
        {
            switch (option)
            {
                case StateVerificationStringOption.Exact:
                    return new Exact(value);
                case StateVerificationStringOption.Contains:
                    return new Contains(value);
                default:
                    return new ExactStripWhitespace(value);
            }
        }

        /// <summary>
        /// Compares the specified expected value.
        /// </summary>
        /// <param name="expected">The expected.</param>
        /// <param name="because">The description.</param>
        public abstract void Compare(string expected, string because = "");

        private class Exact : StateVerificationString
        {
            public Exact(string value)
                : base(value)
            {
            }

            public override void Compare(string expected, string because = "")
            {
                this.Value.Should().Be(expected, because);
            }
        }

        private class Contains : StateVerificationString
        {
            public Contains(string value)
                : base(value)
            {
            }

            public override void Compare(string expected, string because = "")
            {
                this.Value.Should().Contain(expected, because);
            }
        }

        private class ExactStripWhitespace : Exact
        {
            public ExactStripWhitespace(string value)
                : base(value.TrimStart(' ').TrimEnd(' '))
            {
            }
        }
    }
}