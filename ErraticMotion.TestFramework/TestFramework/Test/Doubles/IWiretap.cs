// <copyright file="IWiretap.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Doubles
{
    /// <summary>
    /// <para>
    /// Point-to-point channels are often used for document messages because they ensure
    /// that exactly one consumer will consume each message. However, for testing, monitoring
    /// or troubleshooting, it may be useful to be able to inspect all messages that travel
    /// across the channel.
    /// </para>
    /// <para>
    /// A wire tap is a fixed recipient list with two output channels.
    /// It consumes messages off the input channel (i.e. SUT) and publishes
    /// the unmodified message to both output channels.
    /// </para>
    /// </summary>
    /// <typeparam name="TDependency">The type of the Dependent-On Component.</typeparam>
    public interface IWiretap<in TDependency>
        where TDependency : class
    {
        /// <summary>
        /// Acts as wire tap for the <paramref name="destination"/>.
        /// </summary>
        /// <param name="destination">The wire tap destination.</param>
        void ActAsWiretapFor(TDependency destination);
    }
}