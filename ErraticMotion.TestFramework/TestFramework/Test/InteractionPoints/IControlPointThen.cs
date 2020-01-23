// <copyright file="IControlPointThen.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.InteractionPoints
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Specifies the actions to carry out when a control point matches
    /// an expression.
    /// </summary>
    public interface IControlPointThen
    {
        /// <summary>
        ///  When the control point matches an expression, indicates a failure condition within the SUT.
        /// </summary>
        void Fail();

        /// <summary>
        /// When the control point matches an expression, the exception specified will be raised.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "By design")]
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "By design")]
        void Raise<TException>()
            where TException : Exception;

        /// <summary>
        /// When the control point matches an expression, the exception specified will be raised.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="message">The message.</param>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "By design")]
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "By design")]
        void Raise<TException>(string message)
            where TException : Exception;
    }
}