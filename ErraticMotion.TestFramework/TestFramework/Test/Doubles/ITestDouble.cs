// <copyright file="ITestDouble.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Doubles
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;
    using Moq;

    /// <summary>
    /// Provides services to enable the creation of types of Test Doubles.
    /// </summary>
    /// <typeparam name="TDependency">The Depended-On Component (DoC).</typeparam>
    public interface ITestDouble<TDependency>
        where TDependency : class
    {
        /// <summary>
        /// Gets verifiable versions of Test Doubles.
        /// </summary>
        IVerifiable<TDependency> Verifiable { get; }

        /// <summary>
        /// Gets a <see cref="Moq.Mock{T}"/> object.
        /// </summary>
        /// <value>
        /// A Test Double Mock.
        /// </value>
        Mock<TDependency> Mock { get; }

        /// <summary>
        /// Creates and returns a Test Double Dummy.
        /// </summary>
        /// <returns>An Test Double Dummy object.</returns>
        TDependency Dummy();

        /// <summary>
        /// Creates and returns a Test Double Saboteur capable of raising an exception when the specification expression is met.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to be raised if the conditions match the <paramref name="expression"/>.</typeparam>
        /// <param name="expression">The expression which if <c>true</c> will cause the exception to be raised.</param>
        /// <returns>
        /// A Test Double Saboteur object.
        /// </returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "By design")]
        TDependency Saboteur<TException>(Expression<Action<TDependency>> expression)
            where TException : Exception, new();

        /// <summary>
        /// Creates and returns a Test Double Saboteur capable of raising an exception when the specification expression is met.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to be raised if the conditions match the <paramref name="expression" />.</typeparam>
        /// <param name="expression">The expression which if <c>true</c> will cause the exception to be raised.</param>
        /// <param name="message">The value of the <see cref="System.Exception.Message"/> property.</param>
        /// <returns>
        /// A Test Double Saboteur object.
        /// </returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "By design")]
        TDependency Saboteur<TException>(Expression<Action<TDependency>> expression, string message)
            where TException : Exception, new();

        /// <summary>
        /// Creates and returns a Test Double Spy capable of recording the indirect outputs of the SUT.
        /// </summary>
        /// <typeparam name="TIndirectOutput">The type of the indirect output to be recorded.</typeparam>
        /// <param name="expression">
        /// The expression used to select which member of the SUT to be used to record the indirect output.
        /// </param>
        /// <returns>
        /// A Test Double Spy object that supports the <see cref="ITestSpy{T,TIndirectOutput}"/> interface.
        /// </returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "By design")]
        ITestSpy<TDependency, TIndirectOutput> Spy<TIndirectOutput>(Expression<Action<TDependency>> expression)
            where TIndirectOutput : class;

        /// <summary>
        /// Stubs the specified expression.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <param name="value">The value.</param>
        /// <returns>A Test Double Stub.</returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "By design")]
        TDependency Stub<TProperty>(Expression<Func<TDependency, TProperty>> expression, TProperty value);
    }
}