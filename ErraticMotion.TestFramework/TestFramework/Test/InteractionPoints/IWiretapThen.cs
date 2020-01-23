// <copyright file="IWiretapThen.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.InteractionPoints
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Allows the call-back operation to be specified on a wire tap when
    /// a condition has been met.
    /// </summary>
    public interface IWiretapThen
    {
        /// <summary>
        /// Allows the injection of the call-back if the operation specified in the
        /// <see cref="IWiretapFor{TDependency}.When"/> method has matched.
        /// </summary>
        /// <param name="action">The action to perform if the When operation matches.</param>
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Then", Justification = "Fluent interface")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "Fluent interface")]
        void Then(Action<IEnumerable<object>> action);
    }
}