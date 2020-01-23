// <copyright file="ThenAttribute.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Fixtures
{
    using System;

    /// <summary>
    /// Syntactic sugar for Give-When-Then test fixtures that use the NUnit Framework.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class ThenAttribute : NUnit.Framework.TestAttribute
    {
    }
}