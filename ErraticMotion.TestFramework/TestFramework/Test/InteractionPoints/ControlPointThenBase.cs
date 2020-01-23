// <copyright file="ControlPointThenBase.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.InteractionPoints
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Moq;

    /// <summary>
    /// Represents a control point.
    /// </summary>
    /// <typeparam name="T">The type of control point.</typeparam>
    public abstract class ControlPointThenBase<T> : IControlPointThen
        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ControlPointThenBase{T}"/> class.
        /// </summary>
        protected ControlPointThenBase()
        {
            this.Mock = new Mock<T>();
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ControlPointThenBase{T}"/> is failed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if failed; otherwise, <c>false</c>.
        /// </value>
        public bool Failed { get; protected set; }

        /// <summary>
        /// Gets the underlying Mock object.
        /// </summary>
        protected Mock<T> Mock { get; }

        /// <summary>
        /// Objects this instance.
        /// </summary>
        /// <returns>An object that supports the <typeparamref name="T"/> interface.</returns>
        public T Object()
        {
            return this.Mock.Object;
        }

        /// <summary>
        /// When the control point matches an expression, indicates a failure condition within the SUT.
        /// </summary>
        public abstract void Fail();

        /// <summary>
        /// When the control point matches an expression, the exception specified will be thrown.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "By design")]
        public void Raise<TException>()
            where TException : Exception
        {
            this.Raise<TException>(string.Empty);
        }

        /// <summary>
        /// When the control point matches an expression, the exception specified will be thrown.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="message">The message.</param>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "By design")]
        public abstract void Raise<TException>(string message)
            where TException : Exception;

        /// <summary>
        /// Called when [failed].
        /// </summary>
        /// <returns>Sets the internal state of this control point to indicate failure.</returns>
        protected Action OnFailed()
        {
            return () => this.Failed = true;
        }

        /// <summary>
        /// Creates the specified message.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="message">The message.</param>
        /// <returns>An exception object.</returns>
        protected TException Create<TException>(string message)
            where TException : Exception
        {
            return Activator.CreateInstance(typeof(TException), message) as TException;
        }
    }
}