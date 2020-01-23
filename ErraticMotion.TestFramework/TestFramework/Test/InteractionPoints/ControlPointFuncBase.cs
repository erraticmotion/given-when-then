// <copyright file="ControlPointFuncBase.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.InteractionPoints
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;

    /// <summary>
    /// Acts as a base control for control points.
    /// </summary>
    /// <typeparam name="T">The type of object that the control point acts upon.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public abstract class ControlPointFuncBase<T, TResult> : ControlPointThenBase<T>
        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ControlPointFuncBase{T, TResult}"/> class.
        /// </summary>
        /// <param name="expression">The expression.</param>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
        protected ControlPointFuncBase(Expression<Func<T, TResult>> expression)
        {
            this.Expression = expression;
        }

        /// <summary>
        /// Gets the expression.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
        protected Expression<Func<T, TResult>> Expression { get; }

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