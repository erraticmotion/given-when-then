// <copyright file="TestDouble.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;
    using Doubles;
    using Moq;

    /// <summary>
    /// Entry point to the various types of Test Doubles.
    /// </summary>
    public static class TestDouble
    {
        /// <summary>
        /// Creates and returns a Test Double Spy capable of recording the indirect outputs of the SUT.
        /// </summary>
        /// <typeparam name="TDependency">The Depended-On Component (DoC).</typeparam>
        /// <typeparam name="TIndirectOutput">The type of the indirect output to be recorded.</typeparam>
        /// <param name="expression">The expression used to select which member of the SUT to be used to record the indirect output.</param>
        /// <returns>
        /// A Test Double Spy object that supports the <see cref="ITestSpy{TDependency,TIndirectOutput}" /> interface.
        /// </returns>
        /// <conceptualLink target="929ae0ac-8c2b-4cca-9f36-13f5399cc14c" />
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "By design")]
        public static ITestSpy<TDependency, TIndirectOutput> Spy<TDependency, TIndirectOutput>(Expression<Action<TDependency>> expression)
            where TDependency : class
            where TIndirectOutput : class
        {
            return new TestSpy<TDependency, TIndirectOutput>(expression);
        }

        /// <summary>
        /// Creates and returns a Test Double Saboteur capable of raising an exception when the specification expression is met.
        /// </summary>
        /// <typeparam name="TDependency">The Depended-On Component (DoC).</typeparam>
        /// <typeparam name="TException">The type of the exception to be raised if the conditions match the <paramref name="expression" />.</typeparam>
        /// <param name="expression">The expression which if <c>true</c> will cause the exception to be raised.</param>
        /// <returns>
        /// A Test Double Saboteur object.
        /// </returns>
        /// <conceptualLink target="a7dbf1ab-f8f3-442e-8ad2-b4b4bfe624c6" />
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "By design")]
        public static TDependency Saboteur<TDependency, TException>(Expression<Action<TDependency>> expression)
            where TDependency : class
            where TException : Exception, new()
        {
            return For<TDependency>().Saboteur<TException>(expression);
        }

        /// <summary>
        /// Creates and returns a Test Double Saboteur capable of raising an exception when the specification expression is met.
        /// </summary>
        /// <typeparam name="TDependency">The Depended-On Component (DoC).</typeparam>
        /// <typeparam name="TException">The type of the exception to be raised if the conditions match the <paramref name="expression" />.</typeparam>
        /// <param name="expression">The expression which if <c>true</c> will cause the exception to be raised.</param>
        /// <param name="message">The value of the <see cref="System.Exception.Message"/> property.</param>
        /// <returns>
        /// A Test Double Saboteur object.
        /// </returns>
        /// <conceptualLink target="a7dbf1ab-f8f3-442e-8ad2-b4b4bfe624c6" />
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "By design")]
        public static TDependency Saboteur<TDependency, TException>(Expression<Action<TDependency>> expression, string message)
            where TDependency : class
            where TException : Exception, new()
        {
            return For<TDependency>().Saboteur<TException>(expression, message);
        }

        /// <summary>
        /// Creates and returns a Test Double Dummy.
        /// </summary>
        /// <typeparam name="TDependency">The Depended-On Component (DoC).</typeparam>
        /// <returns>A Test Double Dummy.</returns>
        /// <conceptualLink target="28d5be15-4248-419b-9429-080713e319f3" />
        public static TDependency Dummy<TDependency>()
            where TDependency : class
        {
            return For<TDependency>().Dummy();
        }

        /// <summary>
        /// Creates and returns a Test Double Stub that when called returns the indirect input.
        /// </summary>
        /// <typeparam name="TDependency">The Depended-On Component (DoC).</typeparam>
        /// <param name="indirectInput">The indirect input.</param>
        /// <returns>An object that supports the <typeparamref name="TDependency"/>.</returns>
        /// <remarks>
        /// In reality this is a Test Double Stub specialization called a Responder
        /// (the other Stub specialization is a Saboteur).
        /// Stub is in common usage, Responder is not.
        /// </remarks>
        /// <conceptualLink target="08b31f45-c1b5-454d-a86a-16bc5f49ad22" />
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "By design")]
        public static TDependency Stub<TDependency>(Expression<Func<TDependency, bool>> indirectInput)
            where TDependency : class
        {
            return Mock.Of(indirectInput);
        }

        /// <summary>
        /// Creates and returns an object that supports the <see cref="ITestDouble{TDependency}"/> interface.
        /// </summary>
        /// <typeparam name="TDependency">The Depended-On Component (DoC).</typeparam>
        /// <returns>An object that supports the <see cref="ITestDouble{TDependency}"/> interface.</returns>
        public static ITestDouble<TDependency> For<TDependency>()
            where TDependency : class
        {
            return new TestDoubleCore<TDependency>();
        }
    }
}