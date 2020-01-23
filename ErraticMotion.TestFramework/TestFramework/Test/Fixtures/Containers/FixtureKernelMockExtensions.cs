// <copyright file="FixtureKernelMockExtensions.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Fixtures.Containers
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Moq;

    /// <summary>
    /// Contains extension methods for the <see cref="IFixtureKernel"/> interface
    /// that creates Mock objects and registers them into the underlying IoC container.
    /// </summary>
    public static class FixtureKernelMockExtensions
    {
        /// <summary>
        /// Creates and adds a <typeparamref name="T" /> object and returns a <see cref="Mock{T}" />.
        /// </summary>
        /// <typeparam name="T">The type of test double.</typeparam>
        /// <param name="kernel">The IoC kernel object.</param>
        /// <returns>
        /// A <see cref="Mock{T}" /> created from the <typeparamref name="T" />.
        /// </returns>
        /// <remarks>
        /// Test double - Dummy.
        /// </remarks>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "Well understood IoC binding syntax")]
        public static Mock<T> BindMock<T>(this IFixtureKernel kernel)
            where T : class
        {
            var result = new Mock<T>();
            kernel.Bind(result.Object);
            return result;
        }

        /// <summary>
        /// Adds the specified behaviour.
        /// </summary>
        /// <typeparam name="T">The type of test double.</typeparam>
        /// <param name="kernel">The IoC kernel object.</param>
        /// <param name="behaviour">The behaviour that the mock object exhibits.</param>
        /// <returns>
        /// A <see cref="Mock{T}" /> created from the <typeparamref name="T" />.
        /// </returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "Well understood IoC binding syntax")]
        public static Mock<T> BindMock<T>(this IFixtureKernel kernel, Action<Mock<T>> behaviour)
            where T : class
        {
            var result = kernel.BindMock<T>();
            behaviour(result);
            return result;
        }
    }
}