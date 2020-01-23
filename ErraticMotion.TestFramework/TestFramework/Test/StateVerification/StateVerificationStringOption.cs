// <copyright file="StateVerificationStringOption.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.StateVerification
{
    /// <summary>
    /// Contains the type of state verification to carry out on <see cref="string"/> values.
    /// </summary>
    public enum StateVerificationStringOption
    {
        /// <summary>
        /// The string value being compared must match it's expected state exactly.
        /// </summary>
        Exact,

        /// <summary>
        /// The string value being compared must contain it's expected state.
        /// </summary>
        Contains,

        /// <summary>
        /// The string value being compared after being stripped of any leading
        /// or trailing white space must match it's expected state exactly.
        /// </summary>
        ExactTrimWhiteSpace,
    }
}