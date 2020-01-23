// <copyright file="Should.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using NUnit.Framework;

    /// <summary>
    /// Adds functionality to the MS Test Framework that is missing when compared to NUnit.
    /// </summary>
    /// <remarks>
    /// Replacement for NUnit.Framework.Assert.DoesNotThrow and NUnit.Framework.Assert.Throws.
    /// </remarks>
    public static class Should
    {
        /// <summary>
        /// Verifies that a delegate does not throw an exception.
        /// </summary>
        /// <param name="code">A TestDelegate.</param>
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "code", Justification = "Conditional compilation")]
        public static void NotThrow(TestDelegate code)
        {
            Assert.DoesNotThrow(code);
        }

        /// <summary>
        /// Verifies that a delegate throws a particular exception when called.
        /// </summary>
        /// <typeparam name="T">Type of the expected exception.</typeparam>
        /// <param name="code">A Test Delegate.</param>
        /// <param name="message">The message that will be displayed on failure.</param>
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "code", Justification = "Conditional compilation")]
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "message", Justification = "Conditional compilation")]
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "Conditional compilation")]
        public static void Throw<T>(TestDelegate code, string message)
            where T : Exception
        {
            Assert.Throws<T>(code, message);
        }

        /// <summary>
        /// Verifies that a delegate throws a particular exception when called.
        /// </summary>
        /// <typeparam name="T">Type of the expected exception.</typeparam>
        /// <param name="code">A Test Delegate.</param>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "Conditional compilation")]
        public static void Throw<T>(TestDelegate code)
            where T : Exception
        {
            Throw<T>(code, string.Empty);
        }
    }
}