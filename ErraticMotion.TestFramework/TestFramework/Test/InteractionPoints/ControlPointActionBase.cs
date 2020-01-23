// <copyright file="ControlPointActionBase.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.InteractionPoints
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;

    /// <summary>
    /// Represents a Control Point.
    /// </summary>
    /// <typeparam name="T">The type of control point.</typeparam>
    public class ControlPointActionBase<T> : ControlPointThenBase<T>
        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ControlPointActionBase{T}"/> class.
        /// </summary>
        /// <param name="expression">The expression.</param>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
        protected ControlPointActionBase(Expression<Action<T>> expression)
        {
            this.Expression = expression;
        }

        /// <summary>
        /// Gets the expression.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
        protected Expression<Action<T>> Expression { get; }

        /// <summary>
        /// Fails this instance.
        /// </summary>
        public override void Fail()
        {
            this.Mock.Setup(this.Expression).Callback(this.OnFailed());
        }

        /// <summary>
        /// Throws the specified message.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="message">The message.</param>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "By design")]
        public override void Raise<TException>(string message)
        {
            this.Mock.Setup(this.Expression).Throws(this.Create<TException>(message));
        }
    }
}