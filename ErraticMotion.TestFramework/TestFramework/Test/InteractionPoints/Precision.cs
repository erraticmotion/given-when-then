// <copyright file="Precision.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.InteractionPoints
{
    /// <summary>
    /// Enumerates the precision values when executing an expected state specification
    /// comparison.
    /// </summary>
    public enum Precision
    {
        /// <summary>
        /// The specification must match exactly.
        /// </summary>
        Exact,

        /// <summary>
        /// Indicates that the expectation when comparing a <see cref="string"/> will
        /// pass if the SUT just contains the value indicated.
        /// </summary>
        Contains,
    }
}