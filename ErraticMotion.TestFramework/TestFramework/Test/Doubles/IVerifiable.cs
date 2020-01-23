// <copyright file="IVerifiable.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Doubles
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;

    /// <summary>
    /// Provides services to enable the creation of specialized types of Test Doubles
    /// concerned with verification of indirect outputs.
    /// </summary>
    /// <typeparam name="TDependency">The Depended-On Component (DoC).</typeparam>
    public interface IVerifiable<TDependency>
        where TDependency : class
    {
        /// <summary>
        /// Creates and returns a Test Double Spy capable of asserting the indirect outputs of the SUT.
        /// </summary>
        /// <typeparam name="TIndirectOutput">The type of the indirect output to be recorded.</typeparam>
        /// <param name="expression">
        /// The expression used to select which member of the SUT to be used to record the indirect output.
        /// </param>
        /// <returns>
        /// A Test Double Spy object that supports the <see cref="IStateVerify{T,TIndirectOutput}"/> interface.
        /// </returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "By design")]
        IStateVerify<TDependency, TIndirectOutput> Spy<TIndirectOutput>(Expression<Action<TDependency>> expression)
            where TIndirectOutput : class;

        /// <summary>
        /// Creates and returns a Test Double Saboteur.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="expression">The expression to select which member to apply the saboteur.</param>
        /// <returns>A Test Double Saboteur.</returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "By design")]
        ISaboteurVerify<TDependency> Saboteur<TException>(Expression<Action<TDependency>> expression)
            where TException : Exception, new();

        /// <summary>
        /// Creates and returns a Test Double Saboteur.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="expression">The expression to select which member to apply the saboteur.</param>
        /// <param name="message">A string representation of the error message.</param>
        /// <returns>A Test Double Saboteur.</returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "By design")]
        ISaboteurVerify<TDependency> Saboteur<TException>(Expression<Action<TDependency>> expression, string message)
            where TException : Exception, new();
    }
}