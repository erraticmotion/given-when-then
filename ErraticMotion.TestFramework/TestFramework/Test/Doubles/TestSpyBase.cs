// <copyright file="TestSpyBase.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Doubles
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Acts as a Test Double Test Spy base class.
    /// </summary>
    /// <typeparam name="TIndirectOutput">The type of the indirect output.</typeparam>
    public abstract class TestSpyBase<TIndirectOutput> : IObservationPointIndirectOutput<TIndirectOutput>
        where TIndirectOutput : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestSpyBase{TIndirectOutput}"/> class.
        /// </summary>
        protected TestSpyBase()
        {
            this.IndirectOutput = new List<TIndirectOutput>();
        }

        /// <summary>
        /// Occurs when indirect output is received by this instance.
        /// </summary>
        public event EventHandler<IndirectOutputEventArgs<TIndirectOutput>> Received;

        /// <summary>
        /// Gets the collection of indirect outputs received by this instance.
        /// </summary>
        /// <value>
        /// A collection of indirect outputs.
        /// </value>
        public IList<TIndirectOutput> IndirectOutput { get; }

        /// <summary>
        /// Raises the add indirect output received event.
        /// </summary>
        /// <param name="value">The value.</param>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Used to raise an event")]
        protected virtual void RaiseAddIndirectOutputReceived(TIndirectOutput value)
        {
            this.AddIndirectOutputReceived(value);
            this.RaiseIndirectOutputReceived(value);
        }

        /// <summary>
        /// Adds the indirect output received.
        /// </summary>
        /// <param name="value">The value.</param>
        protected virtual void AddIndirectOutputReceived(TIndirectOutput value)
        {
            this.IndirectOutput.Add(value);
        }

        /// <summary>
        /// Raises the indirect output received.
        /// </summary>
        /// <param name="value">The value.</param>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Used to raise an event")]
        protected virtual void RaiseIndirectOutputReceived(TIndirectOutput value)
        {
            var ev = this.Received;
            ev?.Invoke(this, IndirectOutputEventArgs<TIndirectOutput>.Create(value));
        }
    }
}